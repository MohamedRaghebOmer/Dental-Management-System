using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixVisitAppointmentConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_VisitTreatments_ToothNumber_Range",
                table: "VisitTreatments");

            migrationBuilder.AddCheckConstraint(
                name: "CK_VisitTreatments_ToothNumber_Range",
                table: "VisitTreatments",
                sql: "[ToothNumber] IS NULL OR [ToothNumber] BETWEEN 1 AND 32");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_VisitTreatments_ToothNumber_Range",
                table: "VisitTreatments");

            migrationBuilder.AddCheckConstraint(
                name: "CK_VisitTreatments_ToothNumber_Range",
                table: "VisitTreatments",
                sql: "[ToothNumber] = NULL OR [ToothNumber] BETWEEN 1 AND 32");
        }
    }
}
