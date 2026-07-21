using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureVisitsToAppointmentsCompositeKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UX_Visits_AppointmentId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "UX_Visits_PatientName",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "Visits");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Appointments_Id_PatientId",
                table: "Appointments",
                columns: new[] { "Id", "PatientId" });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_AppointmentId",
                table: "Visits",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Visits_PatientId",
                table: "Visits",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Patients_PatientId",
                table: "Visits",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Patients_PatientId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_AppointmentId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "UX_Visits_PatientId",
                table: "Visits");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Appointments_Id_PatientId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Visits");

            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "Visits",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "UX_Visits_AppointmentId",
                table: "Visits",
                column: "AppointmentId",
                unique: true,
                filter: "[AppointmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UX_Visits_PatientName",
                table: "Visits",
                column: "PatientName");
        }
    }
}
