using Dental.Domain.Repositories.Views.Visits;
using Dental.Domain.Views.Visit;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Dental.Infrastructure.Repositories.Views.Visits;

public sealed class VisitViewRepository : IVisitViewRepository
{
    private readonly DentalDbContext _dbContext;

    public VisitViewRepository(DentalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<VisitView>> GetAsync(
        VisitView? filterDto,
        CancellationToken cancellationToken = default)
    {
        var visitWhereClauses = new List<string>();
        var resultWhereClauses = new List<string>();
        var parameters = new List<(string Name, object Value)>();

        if (filterDto is not null)
        {
            AddVisitIdFilter(filterDto, visitWhereClauses, parameters);
            AddAppointmentIdFilter(filterDto, visitWhereClauses, parameters);
            AddPatientIdFilter(filterDto, visitWhereClauses, parameters);
            AddPatientNameFilter(filterDto, visitWhereClauses, parameters);
            AddVisitDateFilter(filterDto, visitWhereClauses, parameters);
            AddDiscountAmountFilter(filterDto, visitWhereClauses, parameters);

            AddTreatmentNamesFilter(filterDto, resultWhereClauses, parameters);
            AddTotalAmountFilter(filterDto, resultWhereClauses, parameters);
            AddSumOfPaidAmountsFilter(filterDto, resultWhereClauses, parameters);
            AddRemainedAmountFilter(filterDto, resultWhereClauses, parameters);
        }

        var sql = BuildSql(visitWhereClauses, resultWhereClauses);

        var results = new List<VisitView>();
        var connection = _dbContext.Database.GetDbConnection();
        var shouldCloseConnection = connection.State != ConnectionState.Open;

        if (shouldCloseConnection)
            await connection.OpenAsync(cancellationToken);

        try
        {
            await using var command = connection.CreateCommand();
            command.CommandText = sql;

            foreach (var (name, value) in parameters)
            {
                var parameter = command.CreateParameter();
                parameter.ParameterName = name;
                parameter.Value = value;
                command.Parameters.Add(parameter);
            }

            await using var reader = await command.ExecuteReaderAsync(
                CommandBehavior.SequentialAccess,
                cancellationToken);

            var oVisitId = reader.GetOrdinal("VisitId");
            var oAppointmentId = reader.GetOrdinal("AppointmentId");
            var oPatientId = reader.GetOrdinal("PatientId");
            var oPatientName = reader.GetOrdinal("PatientName");
            var oVisitDateTime = reader.GetOrdinal("VisitDateTime");
            var oDiscountAmount = reader.GetOrdinal("DiscountAmount");
            var oTreatmentsNames = reader.GetOrdinal("TreatmentsNames");
            var oTotalAmount = reader.GetOrdinal("TotalAmount");
            var oSumOfPaidAmounts = reader.GetOrdinal("SumOfPaidAmounts");

            while (await reader.ReadAsync(cancellationToken))
            {
                var totalAmount = reader.GetDecimal(oTotalAmount);
                var paidAmount = reader.GetDecimal(oSumOfPaidAmounts);
                var discountAmount = reader.GetDecimal(oDiscountAmount);

                results.Add(new VisitView
                {
                    VisitId = reader.GetInt32(oVisitId),

                    AppointmentId = reader.IsDBNull(oAppointmentId)
                    ? null
                    : reader.GetInt32(oAppointmentId),

                    PatientId = reader.GetInt32(oPatientId),
                    PatientName = reader.GetString(oPatientName),
                    VisitDateTime = reader.GetDateTime(oVisitDateTime),
                    DiscountAmount = discountAmount,

                    VisitTreatmentsNames = reader.IsDBNull(oTreatmentsNames)
                    ? string.Empty
                    : reader.GetString(oTreatmentsNames),

                    TotalAmount = totalAmount,
                    SumOfPaidAmounts = paidAmount,
                    RemainedAmount = totalAmount - (paidAmount + discountAmount)
                });
            }
        }
        finally
        {
            if (shouldCloseConnection)
                await connection.CloseAsync();
        }

        return results;
    }

    private static string BuildSql(
        IReadOnlyList<string> visitWhereClauses,
        IReadOnlyList<string> resultWhereClauses)
    {
        var sql = new StringBuilder();

        sql.AppendLine("""
            WITH FilteredVisits AS
            (
                SELECT
                    v.Id AS VisitId,
                    v.AppointmentId AS AppointmentId,
                    v.PatientId AS PatientId,
                    p.Name AS PatientName,
                    v.VisitDateTime AS VisitDateTime,
                    COALESCE(v.DiscountAmount, 0) AS DiscountAmount
                FROM Visits AS v
                INNER JOIN Patients AS p ON p.Id = v.PatientId
            """);

        if (visitWhereClauses.Count > 0)
        {
            sql.AppendLine("    WHERE");
            sql.AppendLine("        " + string.Join("\n        AND ", visitWhereClauses));
        }

        sql.AppendLine("""
            ),
            TreatmentAgg AS
            (
                SELECT
                    vt.VisitId AS VisitId,
                    COALESCE(GROUP_CONCAT(t.Name, '، '), '') AS TreatmentsNames,
                    COALESCE(SUM(vt.TreatmentPrice * vt.Count), 0) AS TotalAmount
                FROM VisitTreatments AS vt
                INNER JOIN FilteredVisits AS fv ON fv.VisitId = vt.VisitId
                INNER JOIN Treatments AS t ON t.Id = vt.TreatmentId
                GROUP BY vt.VisitId
            ),
            PaymentAgg AS
            (
                SELECT
                    vp.VisitId AS VisitId,
                    COALESCE(SUM(vp.PaidAmount), 0) AS SumOfPaidAmounts
                FROM VisitPayments AS vp
                INNER JOIN FilteredVisits AS fv ON fv.VisitId = vp.VisitId
                GROUP BY vp.VisitId
            )
            SELECT
                fv.VisitId,
                fv.AppointmentId,
                fv.PatientId,
                fv.PatientName,
                fv.VisitDateTime,
                fv.DiscountAmount,
                COALESCE(ta.TreatmentsNames, '') AS TreatmentsNames,
                COALESCE(ta.TotalAmount, 0) AS TotalAmount,
                COALESCE(pa.SumOfPaidAmounts, 0) AS SumOfPaidAmounts
            FROM FilteredVisits AS fv
            LEFT JOIN TreatmentAgg AS ta ON ta.VisitId = fv.VisitId
            LEFT JOIN PaymentAgg AS pa ON pa.VisitId = fv.VisitId
            """);

        if (resultWhereClauses.Count > 0)
        {
            sql.AppendLine("WHERE");
            sql.AppendLine("    " + string.Join("\n    AND ", resultWhereClauses));
        }

        sql.AppendLine("ORDER BY fv.VisitDateTime DESC, fv.VisitId DESC;");

        return sql.ToString();
    }

    private static void AddVisitIdFilter(
        VisitView filterDto,
        ICollection<string> whereClauses,
        ICollection<(string Name, object Value)> parameters)
    {
        if (filterDto.VisitId is not null)
        {
            whereClauses.Add("fv.VisitId = @VisitId");
            parameters.Add(("@VisitId", filterDto.VisitId.Value));
        }
    }

    private static void AddAppointmentIdFilter(
        VisitView filterDto,
        ICollection<string> whereClauses,
        ICollection<(string Name, object Value)> parameters)
    {
        if (filterDto.AppointmentId is not null)
        {
            whereClauses.Add("fv.AppointmentId = @AppointmentId");
            parameters.Add(("@AppointmentId", filterDto.AppointmentId.Value));
        }
    }

    private static void AddPatientIdFilter(
        VisitView filterDto,
        ICollection<string> whereClauses,
        ICollection<(string Name, object Value)> parameters)
    {
        if (filterDto.PatientId is not null)
        {
            whereClauses.Add("fv.PatientId = @PatientId");
            parameters.Add(("@PatientId", filterDto.PatientId.Value));
        }
    }

    private static void AddPatientNameFilter(
        VisitView filterDto,
        ICollection<string> whereClauses,
        ICollection<(string Name, object Value)> parameters)
    {
        if (!string.IsNullOrWhiteSpace(filterDto.PatientName))
        {
            whereClauses.Add("p.Name LIKE @PatientName ESCAPE '\\'");
            parameters.Add(("@PatientName", $"%{EscapeLike(filterDto.PatientName)}%"));
        }
    }

    private static void AddVisitDateFilter(
        VisitView filterDto,
        ICollection<string> whereClauses,
        ICollection<(string Name, object Value)> parameters)
    {
        if (filterDto.VisitDateTime is { } visitDateTime)
        {
            whereClauses.Add("v.VisitDateTime >= @VisitDateFrom AND v.VisitDateTime < @VisitDateTo");
            parameters.Add(("@VisitDateFrom", visitDateTime.Date));
            parameters.Add(("@VisitDateTo", visitDateTime.Date.AddDays(1)));
        }
        else if (filterDto.GetViewsAfterDateTime is { } getViewsAfterDateTime)
        {
            whereClauses.Add("v.VisitDateTime >= @GetViewsAfterDateTime");
            parameters.Add(("@GetViewsAfterDateTime", getViewsAfterDateTime.Date));
        }
    }

    private static void AddDiscountAmountFilter(
        VisitView filterDto,
        ICollection<string> whereClauses,
        ICollection<(string Name, object Value)> parameters)
    {
        if (filterDto.DiscountAmount is not null)
        {
            whereClauses.Add("fv.DiscountAmount = @DiscountAmount");
            parameters.Add(("@DiscountAmount", filterDto.DiscountAmount.Value));
        }
    }

    private static void AddTreatmentNamesFilter(
        VisitView filterDto,
        ICollection<string> whereClauses,
        ICollection<(string Name, object Value)> parameters)
    {
        if (string.IsNullOrWhiteSpace(filterDto.VisitTreatmentsNames))
            return;

        var treatmentNames = filterDto.VisitTreatmentsNames.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        for (var i = 0; i < treatmentNames.Length; i++)
        {
            var parameterName = $"@TreatmentName{i}";
            whereClauses.Add($"COALESCE(ta.TreatmentsNames, '') LIKE {parameterName} ESCAPE '\\'");
            parameters.Add((parameterName, $"%{EscapeLike(treatmentNames[i])}%"));
        }
    }

    private static void AddTotalAmountFilter(
        VisitView filterDto,
        ICollection<string> whereClauses,
        ICollection<(string Name, object Value)> parameters)
    {
        if (filterDto.TotalAmount is not null)
        {
            whereClauses.Add("ABS(COALESCE(ta.TotalAmount, 0) - @TotalAmount) < 0.005");
            parameters.Add(("@TotalAmount", filterDto.TotalAmount.Value));
        }
    }

    private static void AddSumOfPaidAmountsFilter(
        VisitView filterDto,
        ICollection<string> whereClauses,
        ICollection<(string Name, object Value)> parameters)
    {
        if (filterDto.SumOfPaidAmounts is not null)
        {
            whereClauses.Add("ABS(COALESCE(pa.SumOfPaidAmounts, 0) - @SumOfPaidAmounts) < 0.005");
            parameters.Add(("@SumOfPaidAmounts", filterDto.SumOfPaidAmounts.Value));
        }
    }

    private static void AddRemainedAmountFilter(
        VisitView filterDto,
        ICollection<string> whereClauses,
        ICollection<(string Name, object Value)> parameters)
    {
        if (filterDto.RemainedAmount is not null)
        {
            whereClauses.Add("""
                ABS(
                    (COALESCE(ta.TotalAmount, 0) - (COALESCE(pa.SumOfPaidAmounts, 0) + COALESCE(fv.DiscountAmount, 0)))
                    - @RemainedAmount
                ) < 0.005
                """);
            parameters.Add(("@RemainedAmount", filterDto.RemainedAmount.Value));
        }
    }

    private static void AddParameter(
        DbCommand command,
        string name,
        object value)
    {
        var parameter = command.CreateParameter();
        parameter.ParameterName = name;
        parameter.Value = value;
        command.Parameters.Add(parameter);
    }

    private static string EscapeLike(string input) =>
        input.Replace("\\", "\\\\").Replace("%", "\\%").Replace("_", "\\_");
}