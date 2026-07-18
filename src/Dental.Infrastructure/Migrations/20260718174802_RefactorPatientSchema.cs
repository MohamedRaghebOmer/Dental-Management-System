using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorPatientSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Patients_PhoneNumberLengthEqualTo11",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Patients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "UX_Visits_PatientName",
                table: "Visits",
                column: "PatientName");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_FirstName",
                table: "Patients",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_LastName",
                table: "Patients",
                column: "LastName");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Patients_AgeRange",
                table: "Patients",
                sql: "Age BETWEEN 0 AND 99");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Patients_PhoneNumberLength",
                table: "Patients",
                sql: "length(PhoneNumber) = 11");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UX_Visits_PatientName",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Patients_FirstName",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_LastName",
                table: "Patients");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Patients_AgeRange",
                table: "Patients");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Patients_PhoneNumberLength",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Patients");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Patients",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Patients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Patients_PhoneNumberLengthEqualTo11",
                table: "Patients",
                sql: "length(PhoneNumber) = 11");
        }
    }
}
