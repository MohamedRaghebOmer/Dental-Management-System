using Dental.Domain.Repositories.Views;
using Dental.Domain.Views;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text;

namespace Dental.Infrastructure.Repositories.Views;

public class VisitViewRepository : IVisitViewRepository
{
    private readonly DentalDbContext _dbContext;

    public VisitViewRepository(DentalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    //public async Task<List<VisitView>> GetAsync(CancellationToken cancellationToken = default)
    //{
    //    // ── Query 1: Visits table only, no joins, no correlated subqueries ──────────
    //    var visits = await _dbContext.Visits
    //        .AsNoTracking()
    //        .OrderByDescending(v => v.VisitDateTime)
    //        .Select(v => new
    //        {
    //            Id = v.Id,
    //            VisitId = v.Id.Value,
    //            AppointmentId = v.AppointmentId != null ? v.AppointmentId.Value : (int?)null,
    //            v.PatientName,
    //            v.VisitDateTime,
    //            PaidAmount = v.PaidAmount.Value,
    //            DiscountAmount = v.DiscountAmount.Value,
    //        })
    //        .ToListAsync(cancellationToken);

    //    if (visits.Count == 0)
    //        return [];

    //    // ── Query 2: One flat JOIN across all visits, no correlated subqueries ──────
    //    var visitIds = visits.Select(v => v.Id).ToList();

    //    var treatments = await _dbContext.VisitTreatments
    //        .AsNoTracking()
    //        .Where(vt => visitIds.Contains(vt.VisitId))
    //        .Select(vt => new
    //        {
    //            VisitId = vt.VisitId,
    //            Name = vt.Treatment.Name,
    //            Price = vt.Treatment.Price.Value   // ✅ flat projection, no correlated Sum
    //        })
    //        .ToListAsync(cancellationToken);

    //    // ── In-memory assembly: O(n) dictionary lookup, zero extra DB calls ─────────
    //    var grouped = treatments
    //        .GroupBy(t => t.VisitId)
    //        .ToDictionary(g => g.Key, g => g.ToList());

    //    var result = visits.Select(v =>
    //    {
    //        var vTreatments = grouped.GetValueOrDefault(v.Id) ?? [];
    //        var totalAmount = vTreatments.Sum(t => t.Price);

    //        return new VisitView
    //        {
    //            VisitId = v.VisitId,
    //            AppointmentId = v.AppointmentId,
    //            PatientName = v.PatientName,
    //            VisitDateTime = v.VisitDateTime,
    //            VisitTreatmentsNames = string.Join("، ", vTreatments.Select(v => v.Name)),
    //            TotalAmount = totalAmount,
    //            PaidAmount = v.PaidAmount,
    //            DiscountAmount = v.DiscountAmount,
    //            RemainedAmount = totalAmount - (v.PaidAmount + v.DiscountAmount)
    //        };
    //    }).ToList();

    //    return result;
    //}

    //public async Task<List<VisitView>> GetAsync(
    //    VisitView? filterDTO,
    //    CancellationToken cancellationToken = default)
    //{
    //    const string sql = @"
    //        SELECT
    //            v.Id            AS VisitId,
    //            v.AppointmentId AS AppointmentId,
    //            v.PatientName   AS PatientName,
    //            v.VisitDateTime AS VisitDateTime,
    //            v.PaidAmount    AS PaidAmount,
    //            v.DiscountAmount AS DiscountAmount,
    //            COALESCE(GROUP_CONCAT(t.Name, '، '), '') AS TreatmentsNames,
    //            COALESCE(SUM(t.Price), 0)                AS TotalAmount
    //        FROM Visits v
    //        LEFT JOIN VisitTreatments vt ON vt.VisitId = v.Id
    //        LEFT JOIN Treatments t       ON t.Id = vt.TreatmentId
    //        GROUP BY v.Id
    //        ORDER BY v.VisitDateTime DESC;";

    //    var results = new List<VisitView>();
    //    var connection = _dbContext.Database.GetDbConnection();
    //    var wasClosed = connection.State != ConnectionState.Open;
    //    if (wasClosed)
    //        await connection.OpenAsync(cancellationToken);

    //    try
    //    {
    //        await using var command = connection.CreateCommand();
    //        command.CommandText = sql;

    //        await using var reader = await command.ExecuteReaderAsync(
    //            CommandBehavior.SequentialAccess, cancellationToken);

    //        int oVisitId = reader.GetOrdinal("VisitId");
    //        int oAppointmentId = reader.GetOrdinal("AppointmentId");
    //        int oPatientName = reader.GetOrdinal("PatientName");
    //        int oVisitDateTime = reader.GetOrdinal("VisitDateTime");
    //        int oPaidAmount = reader.GetOrdinal("PaidAmount");
    //        int oDiscountAmount = reader.GetOrdinal("DiscountAmount");
    //        int oTreatmentsNames = reader.GetOrdinal("TreatmentsNames");
    //        int oTotalAmount = reader.GetOrdinal("TotalAmount");

    //        while (await reader.ReadAsync(cancellationToken))
    //        {
    //            var paid = reader.GetDecimal(oPaidAmount);
    //            var discount = reader.GetDecimal(oDiscountAmount);
    //            var total = reader.GetDecimal(oTotalAmount);

    //            results.Add(new VisitView
    //            {
    //                VisitId = reader.GetInt32(oVisitId),
    //                AppointmentId = reader.IsDBNull(oAppointmentId) ? null : reader.GetInt32(oAppointmentId),
    //                PatientName = reader.IsDBNull(oPatientName) ? null : reader.GetString(oPatientName),
    //                VisitDateTime = reader.GetDateTime(oVisitDateTime),
    //                VisitTreatmentsNames = reader.GetString(oTreatmentsNames),
    //                TotalAmount = total,
    //                PaidAmount = paid,
    //                DiscountAmount = discount,
    //                RemainedAmount = total - (paid + discount)
    //            });
    //        }
    //    }
    //    finally
    //    {
    //        if (wasClosed)
    //            await connection.CloseAsync();
    //    }

    //    return results;
    //}

    public async Task<List<VisitView>> GetAsync(
        VisitView? filterDTO,
        CancellationToken cancellationToken = default)
    {
        var whereClauses = new List<string>();
        var havingClauses = new List<string>();
        var parameters = new List<(string Name, object Value)>();

        if (filterDTO is not null)
        {
            if (filterDTO.VisitId is int visitId)
            {
                whereClauses.Add("v.Id = @VisitId");
                parameters.Add(("@VisitId", visitId));
            }

            if (filterDTO.AppointmentId is int appointmentId)
            {
                whereClauses.Add("v.AppointmentId = @AppointmentId");
                parameters.Add(("@AppointmentId", appointmentId));
            }

            if (!string.IsNullOrWhiteSpace(filterDTO.PatientName))
            {
                whereClauses.Add("v.PatientName LIKE @PatientName ESCAPE '\\'");
                parameters.Add(("@PatientName", $"%{EscapeLike(filterDTO.PatientName)}%"));
            }

            if (filterDTO.VisitDateTime is DateTime visitDateTime)
            {
                // Match the whole day, not an exact timestamp
                whereClauses.Add("v.VisitDateTime >= @VisitDateFrom AND v.VisitDateTime < @VisitDateTo");
                parameters.Add(("@VisitDateFrom", visitDateTime.Date));
                parameters.Add(("@VisitDateTo", visitDateTime.Date.AddDays(1)));
            }

            if (filterDTO.PaidAmount is decimal paidAmount)
            {
                whereClauses.Add("v.PaidAmount = @PaidAmount");
                parameters.Add(("@PaidAmount", paidAmount));
            }

            if (filterDTO.DiscountAmount is decimal discountAmount)
            {
                whereClauses.Add("v.DiscountAmount = @DiscountAmount");
                parameters.Add(("@DiscountAmount", discountAmount));
            }

            if (!string.IsNullOrWhiteSpace(filterDTO.VisitTreatmentsNames))
            {
                // EXISTS runs before GROUP BY, so it prunes rows early instead of
                // filtering the concatenated string after aggregation
                whereClauses.Add(@"EXISTS (
                    SELECT 1
                    FROM VisitTreatments vtf
                    INNER JOIN Treatments tf ON tf.Id = vtf.TreatmentId
                    WHERE vtf.VisitId = v.Id
                      AND tf.Name LIKE @TreatmentName ESCAPE '\')");
                parameters.Add(("@TreatmentName", $"%{EscapeLike(filterDTO.VisitTreatmentsNames)}%"));
            }

            if (filterDTO.TotalAmount is decimal totalAmount)
            {
                havingClauses.Add("ABS(COALESCE(SUM(CAST(t.Price AS REAL)), 0) - CAST(@TotalAmount AS REAL)) < 0.005");
                parameters.Add(("@TotalAmount", totalAmount));
            }

            if (filterDTO.RemainedAmount is decimal remainedAmount)
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
                v.Id            AS VisitId,
                v.AppointmentId AS AppointmentId,
                v.PatientName   AS PatientName,
                v.VisitDateTime AS VisitDateTime,
                v.PaidAmount    AS PaidAmount,
                v.DiscountAmount AS DiscountAmount,
                COALESCE(GROUP_CONCAT(t.Name, '، '), '') AS TreatmentsNames,
                COALESCE(SUM(t.Price), 0)                AS TotalAmount
            FROM Visits v
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
                    PatientName = reader.IsDBNull(oPatientName) ? null : reader.GetString(oPatientName),
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

        return results;
    }

    private static string EscapeLike(string input) =>
        input.Replace("\\", "\\\\").Replace("%", "\\%").Replace("_", "\\_");
}
