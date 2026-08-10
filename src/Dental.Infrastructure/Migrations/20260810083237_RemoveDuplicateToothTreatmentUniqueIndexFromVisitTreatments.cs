using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDuplicateToothTreatmentUniqueIndexFromVisitTreatments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UX_VisitTreatments_ToothNumber_VisitId_TreatmentId",
                table: "VisitTreatments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "UX_VisitTreatments_ToothNumber_VisitId_TreatmentId",
                table: "VisitTreatments",
                columns: new[] { "ToothNumber", "VisitId", "TreatmentId" },
                unique: true);
        }
    }
}
