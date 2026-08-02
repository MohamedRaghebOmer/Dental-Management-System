using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MovePaidAmountFromVisitsToVisitPayments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO VisitPayments (VisitId, PaidAmount, PaymentDateTime)
                SELECT 
                    Id,
                    PaidAmount,
                    VisitDateTime
                FROM Visits
                WHERE PaidAmount IS NOT NULL;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                UPDATE Visits
                SET PaidAmount = (
                    SELECT vp.PaidAmount
                    FROM VisitPayments vp
                    WHERE vp.VisitId = Visits.Id
                    ORDER BY vp.PaymentDateTime DESC
                    LIMIT 1
                );
            ");

            migrationBuilder.Sql(@"
                DELETE FROM VisitPayments
                WHERE VisitId IN (SELECT Id FROM Visits);
            ");
        }
    }
}
