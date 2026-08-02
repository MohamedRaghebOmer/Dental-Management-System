using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovePaidAmountFromVisits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Visits_PaidAmount_NotNegative",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "PaidAmount",
                table: "Visits");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PaidAmount",
                table: "Visits",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Visits_PaidAmount_NotNegative",
                table: "Visits",
                sql: "[PaidAmount] >= 0");
        }
    }
}
