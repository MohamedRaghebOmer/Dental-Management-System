using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientGenderConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Patients_Gender",
                table: "Patients");

            migrationBuilder.AlterColumn<byte>(
                name: "Gender",
                table: "Patients",
                type: "TINYINT",
                nullable: false,
                comment: "Male = 0, Female = 1",
                oldClrType: typeof(byte),
                oldType: "TINYINT",
                oldComment: "Male = 1, Female = 2");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Patients_Gender",
                table: "Patients",
                sql: "Gender IN (0, 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Patients_Gender",
                table: "Patients");

            migrationBuilder.AlterColumn<byte>(
                name: "Gender",
                table: "Patients",
                type: "TINYINT",
                nullable: false,
                comment: "Male = 1, Female = 2",
                oldClrType: typeof(byte),
                oldType: "TINYINT",
                oldComment: "Male = 0, Female = 1");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Patients_Gender",
                table: "Patients",
                sql: "Gender IN (1, 2)");
        }
    }
}
