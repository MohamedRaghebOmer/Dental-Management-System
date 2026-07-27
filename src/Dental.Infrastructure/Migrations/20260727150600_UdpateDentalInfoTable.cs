using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UdpateDentalInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "DentalInfo");

            migrationBuilder.AddColumn<string>(
                name: "DentalName",
                table: "DentalInfo",
                type: "TEXT",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DentalPicturePath",
                table: "DentalInfo",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorPicturePath",
                table: "DentalInfo",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DentalInfo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DentalName", "DentalPicturePath", "DoctorPicturePath" },
                values: new object[] { "إبتسامه", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DentalName",
                table: "DentalInfo");

            migrationBuilder.DropColumn(
                name: "DentalPicturePath",
                table: "DentalInfo");

            migrationBuilder.DropColumn(
                name: "DoctorPicturePath",
                table: "DentalInfo");

            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "DentalInfo",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DentalInfo",
                keyColumn: "Id",
                keyValue: 1,
                column: "PicturePath",
                value: null);
        }
    }
}
