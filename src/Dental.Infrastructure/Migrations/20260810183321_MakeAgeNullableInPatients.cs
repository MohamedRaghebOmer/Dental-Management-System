using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeAgeNullableInPatients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Patients_AgeRange",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Patients",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Patients_AgeRange",
                table: "Patients",
                sql: "[Age] IS NULL OR [Age] BETWEEN 0 AND 99");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Patients_AgeRange",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Patients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Patients_AgeRange",
                table: "Patients",
                sql: "Age BETWEEN 0 AND 99");
        }
    }
}
