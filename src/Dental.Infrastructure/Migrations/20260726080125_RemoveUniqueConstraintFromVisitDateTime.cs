using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUniqueConstraintFromVisitDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UX_Visits_VisitDateTime",
                table: "Visits");

            migrationBuilder.RenameIndex(
                name: "UX_Visits_PatientId",
                table: "Visits",
                newName: "IX_Visits_PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_VisitDateTime",
                table: "Visits",
                column: "VisitDateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Visits_VisitDateTime",
                table: "Visits");

            migrationBuilder.RenameIndex(
                name: "IX_Visits_PatientId",
                table: "Visits",
                newName: "UX_Visits_PatientId");

            migrationBuilder.CreateIndex(
                name: "UX_Visits_VisitDateTime",
                table: "Visits",
                column: "VisitDateTime",
                unique: true);
        }
    }
}
