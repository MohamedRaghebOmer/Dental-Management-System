using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveHasDataFromDentalInfoConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DentalInfo",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DentalInfo",
                columns: new[] { "Id", "DentalDescription", "DentalName", "DentalPicturePath", "DoctorName", "DoctorPicturePath", "PhoneNumber" },
                values: new object[] { 1, "طب الفم والأسنان", "إبتسامه", null, "د/ كريم فتوح", null, "+20100619816" });
        }
    }
}
