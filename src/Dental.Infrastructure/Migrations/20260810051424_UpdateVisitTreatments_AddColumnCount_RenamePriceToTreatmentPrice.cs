using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVisitTreatments_AddColumnCount_RenamePriceToTreatmentPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_VisitTreatments_Price_NonNegative",
                table: "VisitTreatments");

            migrationBuilder.DropCheckConstraint(
                name: "CK_VisitTreatments_ToothNumber_Range",
                table: "VisitTreatments");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "VisitTreatments",
                newName: "TreatmentPrice");

            migrationBuilder.AlterColumn<byte>(
                name: "ToothNumber",
                table: "VisitTreatments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "VisitTreatments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddCheckConstraint(
                name: "CK_VisitTreatments_Count_Positive",
                table: "VisitTreatments",
                sql: "[Count] > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_VisitTreatments_Price_NonNegative",
                table: "VisitTreatments",
                sql: "[TreatmentPrice] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_VisitTreatments_ToothNumber_Range",
                table: "VisitTreatments",
                sql: "[ToothNumber] = NULL OR [ToothNumber] BETWEEN 1 AND 32");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_VisitTreatments_Count_Positive",
                table: "VisitTreatments");

            migrationBuilder.DropCheckConstraint(
                name: "CK_VisitTreatments_Price_NonNegative",
                table: "VisitTreatments");

            migrationBuilder.DropCheckConstraint(
                name: "CK_VisitTreatments_ToothNumber_Range",
                table: "VisitTreatments");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "VisitTreatments");

            migrationBuilder.RenameColumn(
                name: "TreatmentPrice",
                table: "VisitTreatments",
                newName: "Price");

            migrationBuilder.AlterColumn<byte>(
                name: "ToothNumber",
                table: "VisitTreatments",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_VisitTreatments_Price_NonNegative",
                table: "VisitTreatments",
                sql: "[Price] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_VisitTreatments_ToothNumber_Range",
                table: "VisitTreatments",
                sql: "[ToothNumber] >= 1 AND [ToothNumber] <= 32");
        }
    }
}
