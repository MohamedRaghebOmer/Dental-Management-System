using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureVisitsToAppointmentsCompositeKey2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Appointments_AppointmentId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_AppointmentId",
                table: "Visits");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_AppointmentId_PatientId",
                table: "Visits",
                columns: new[] { "AppointmentId", "PatientId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Appointments_AppointmentId_PatientId",
                table: "Visits",
                columns: new[] { "AppointmentId", "PatientId" },
                principalTable: "Appointments",
                principalColumns: new[] { "Id", "PatientId" },
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Appointments_AppointmentId_PatientId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_AppointmentId_PatientId",
                table: "Visits");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_AppointmentId",
                table: "Visits",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Appointments_AppointmentId",
                table: "Visits",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
