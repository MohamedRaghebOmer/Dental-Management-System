using Dental.Domain.Repositories.Views.Visits;
using Dental.Domain.Views.Visit;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Dental.Infrastructure.Repositories.Views.Visit;

public class VisitSummaryRepository : IVisitSummaryRepository
{
    private readonly DentalDbContext _dbContext;

    public VisitSummaryRepository(DentalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<VisitsSummaryView> GetAsync(
        DateTime? dateTime,
        CancellationToken cancellationToken = default)
    {
        const string sql = @"
        SELECT
            (SELECT COUNT(*)
             FROM Visits v
             WHERE (@DateTime IS NULL OR v.VisitDateTime >= @DateTime))
                AS TotalVisitsCount,

            (SELECT COALESCE(SUM(v.PaidAmount), 0)
             FROM Visits v
             WHERE (@DateTime IS NULL OR v.VisitDateTime >= @DateTime))
                AS TotalVisitsPaidAmount,

            (SELECT COALESCE(SUM(v.DiscountAmount), 0)
             FROM Visits v
             WHERE (@DateTime IS NULL OR v.VisitDateTime >= @DateTime))
                AS TotalVisitsDiscountAmount,

            (SELECT COALESCE(SUM(t.Price), 0)
             FROM Visits v
             INNER JOIN VisitTreatments vt ON vt.VisitId = v.Id
             INNER JOIN Treatments t ON t.Id = vt.TreatmentId
             WHERE (@DateTime IS NULL OR v.VisitDateTime >= @DateTime))
                AS TotalVisitsTotalAmount;";

        var connection = _dbContext.Database.GetDbConnection();
        var wasClosed = connection.State != ConnectionState.Open;
        if (wasClosed)
            await connection.OpenAsync(cancellationToken);

        try
        {
            await using var command = connection.CreateCommand();
            command.CommandText = sql;

            var parameter = command.CreateParameter();
            parameter.ParameterName = "@DateTime";
            parameter.Value = dateTime == null ? DBNull.Value : dateTime;
            command.Parameters.Add(parameter);

            await using var reader = await command.ExecuteReaderAsync(
                CommandBehavior.SingleRow, cancellationToken);

            if (!await reader.ReadAsync(cancellationToken))
            {
                return new VisitsSummaryView
                {
                    TotalVisitsCount = 0,
                    TotalVisitsTotalAmount = 0,
                    TotalVisitsPaidAmount = 0,
                    TotalVisitsDiscountAmount = 0,
                    TotalVisitsRemainedAmount = 0
                };
            }

            var count = reader.GetInt32(reader.GetOrdinal("TotalVisitsCount"));
            var paid = reader.GetDecimal(reader.GetOrdinal("TotalVisitsPaidAmount"));
            var discount = reader.GetDecimal(reader.GetOrdinal("TotalVisitsDiscountAmount"));
            var totalAmount = reader.GetDecimal(reader.GetOrdinal("TotalVisitsTotalAmount"));

            return new VisitsSummaryView
            {
                TotalVisitsCount = count,
                TotalVisitsTotalAmount = totalAmount,
                TotalVisitsPaidAmount = paid,
                TotalVisitsDiscountAmount = discount,
                TotalVisitsRemainedAmount = totalAmount - paid - discount
            };
        }
        finally
        {
            if (wasClosed)
                await connection.CloseAsync();
        }
    }
}
