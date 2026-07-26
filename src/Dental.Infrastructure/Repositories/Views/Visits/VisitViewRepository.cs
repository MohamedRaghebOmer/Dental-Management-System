using Dental.Domain.Repositories.Views.Visits;
using Dental.Domain.Views.Visit;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace Dental.Infrastructure.Repositories.Views.Visit;

public class VisitViewRepository : IVisitViewRepository
{
    private readonly DentalDbContext _dbContext;

    public VisitViewRepository(DentalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<VisitView>> GetAsync(
        VisitView? filterDTO,
        CancellationToken cancellationToken = default)
    {
        var sw = Stopwatch.StartNew();

        var whereClauses = new List<string>();
        var havingClauses = new List<string>();
        var parameters = new List<(string Name, object Value)>();

        if (filterDTO is not null)
        {
            if (filterDTO.VisitId is { } visitId)
            {
                whereClauses.Add("v.Id = @VisitId");
                parameters.Add(("@VisitId", visitId));
            }

            if (filterDTO.AppointmentId is { } appointmentId)
            {
                whereClauses.Add("v.AppointmentId = @AppointmentId");
                parameters.Add(("@AppointmentId", appointmentId));
            }

            if (filterDTO.PatientId is { } patientId)
            {
                whereClauses.Add("v.PatientId = @PatientId");
                parameters.Add(("@PatientId", patientId));
            }

            if (!string.IsNullOrWhiteSpace(filterDTO.PatientName))
            {
                // Smart search: match anywhere within the full "First Last" name.
                whereClauses.Add("p.Name LIKE @PatientName ESCAPE '\\'");
                parameters.Add(("@PatientName", $"%{EscapeLike(filterDTO.PatientName)}%"));
            }


            if (filterDTO.VisitDateTime is { } visitDateTime)
            {
                // Match the whole day, not an exact timestamp
                whereClauses.Add("v.VisitDateTime >= @VisitDateFrom AND v.VisitDateTime < @VisitDateTo");
                parameters.Add(("@VisitDateFrom", visitDateTime.Date));
                parameters.Add(("@VisitDateTo", visitDateTime.Date.AddDays(1)));
            }
            else if (filterDTO.GetViewsAfterDateTime is { } getViewsAfterDateTime)
            {
                // Compare by calendar date only — strip time-of-day so that
                // visits earlier "today" are still included when the cutoff is today.
                whereClauses.Add("v.VisitDateTime >= @GetViewsAfterDateTime");
                parameters.Add(("@GetViewsAfterDateTime", getViewsAfterDateTime.Date));
            }

            if (filterDTO.PaidAmount is { } paidAmount)
            {
                whereClauses.Add("v.PaidAmount = @PaidAmount");
                parameters.Add(("@PaidAmount", paidAmount));
            }

            if (filterDTO.DiscountAmount is { } discountAmount)
            {
                whereClauses.Add("v.DiscountAmount = @DiscountAmount");
                parameters.Add(("@DiscountAmount", discountAmount));
            }

            if (!string.IsNullOrWhiteSpace(filterDTO.VisitTreatmentsNames))
            {
                // Each independent treatment name (separated by ' ') must be present
                // somewhere within the fully concatenated TreatmentsNames result.
                var treatmentNames = filterDTO.VisitTreatmentsNames.Split(
                    ' ',
                    StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                for (var i = 0; i < treatmentNames.Length; i++)
                {
                    var paramName = $"@TreatmentName{i}";
                    havingClauses.Add($"COALESCE(GROUP_CONCAT(t.Name, '، '), '') LIKE {paramName} ESCAPE '\\'");
                    parameters.Add((paramName, $"%{EscapeLike(treatmentNames[i])}%"));
                }
            }

            if (filterDTO.TotalAmount is { } totalAmount)
            {
                havingClauses.Add("ABS(COALESCE(SUM(CAST(t.Price AS REAL)), 0) - CAST(@TotalAmount AS REAL)) < 0.005");
                parameters.Add(("@TotalAmount", totalAmount));
            }

            if (filterDTO.RemainedAmount is { } remainedAmount)
            {
                havingClauses.Add(@"
                ABS(
                    (COALESCE(SUM(CAST(t.Price AS REAL)), 0)
                     - (CAST(v.PaidAmount AS REAL) + CAST(v.DiscountAmount AS REAL)))
                    - CAST(@RemainedAmount AS REAL)
                ) < 0.005");
                parameters.Add(("@RemainedAmount", remainedAmount));
            }
        }

        var sql = new StringBuilder(@"
        SELECT
            v.Id             AS VisitId,
            v.AppointmentId  AS AppointmentId,
            v.PatientId      AS PatientId,
            p.Name           AS PatientName,
            v.VisitDateTime  AS VisitDateTime,
            v.PaidAmount     AS PaidAmount,
            v.DiscountAmount AS DiscountAmount,
            COALESCE(GROUP_CONCAT(t.Name, '، '), '') AS TreatmentsNames,
            COALESCE(SUM(t.Price), 0)                AS TotalAmount
        FROM Visits v
        INNER JOIN Patients p        ON p.Id = v.PatientId
        LEFT JOIN VisitTreatments vt ON vt.VisitId = v.Id
        LEFT JOIN Treatments t       ON t.Id = vt.TreatmentId");

        if (whereClauses.Count > 0)
            sql.Append(" WHERE ").Append(string.Join(" AND ", whereClauses));

        sql.Append(" GROUP BY v.Id");

        if (havingClauses.Count > 0)
            sql.Append(" HAVING ").Append(string.Join(" AND ", havingClauses));

        sql.Append(" ORDER BY v.VisitDateTime DESC;");

        var results = new List<VisitView>();
        var connection = _dbContext.Database.GetDbConnection();
        var wasClosed = connection.State != ConnectionState.Open;
        if (wasClosed)
            await connection.OpenAsync(cancellationToken);

        try
        {
            await using var command = connection.CreateCommand();
            command.CommandText = sql.ToString();

            foreach (var (name, value) in parameters)
            {
                var p = command.CreateParameter();
                p.ParameterName = name;
                p.Value = value;
                command.Parameters.Add(p);
            }

            await using var reader = await command.ExecuteReaderAsync(
                CommandBehavior.SequentialAccess, cancellationToken);

            int oVisitId = reader.GetOrdinal("VisitId");
            int oAppointmentId = reader.GetOrdinal("AppointmentId");
            int oPatientId = reader.GetOrdinal("PatientId");
            int oPatientName = reader.GetOrdinal("PatientName");
            int oVisitDateTime = reader.GetOrdinal("VisitDateTime");
            int oPaidAmount = reader.GetOrdinal("PaidAmount");
            int oDiscountAmount = reader.GetOrdinal("DiscountAmount");
            int oTreatmentsNames = reader.GetOrdinal("TreatmentsNames");
            int oTotalAmount = reader.GetOrdinal("TotalAmount");

            while (await reader.ReadAsync(cancellationToken))
            {
                var paid = reader.GetDecimal(oPaidAmount);
                var discount = reader.GetDecimal(oDiscountAmount);
                var total = reader.GetDecimal(oTotalAmount);

                results.Add(new VisitView
                {
                    VisitId = reader.GetInt32(oVisitId),
                    AppointmentId = reader.IsDBNull(oAppointmentId) ? null : reader.GetInt32(oAppointmentId),
                    PatientId = reader.GetInt32(oPatientId),
                    PatientName = reader.GetString(oPatientName),
                    VisitDateTime = reader.GetDateTime(oVisitDateTime),
                    VisitTreatmentsNames = reader.GetString(oTreatmentsNames),
                    TotalAmount = total,
                    PaidAmount = paid,
                    DiscountAmount = discount,
                    RemainedAmount = total - (paid + discount)
                });
            }
        }
        finally
        {
            if (wasClosed)
                await connection.CloseAsync();
        }

        Debug.WriteLine(sw.ElapsedMilliseconds);

        return results;
    }

    private static string EscapeLike(string input) =>
        input.Replace("\\", "\\\\").Replace("%", "\\%").Replace("_", "\\_");
}
