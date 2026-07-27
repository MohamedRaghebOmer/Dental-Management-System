using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableMaterials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Suppliers_SupplierId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_SupplierId",
                table: "Materials");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Material_BuyingPrice",
                table: "Materials");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Material_Quantity",
                table: "Materials");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Material_ReorderLevel",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Materials");

            migrationBuilder.RenameColumn(
                name: "BuyingPrice",
                table: "Materials",
                newName: "Price");

            migrationBuilder.AlterColumn<decimal>(
                name: "ReorderLevel",
                table: "Materials",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "Materials",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ReorderLevel",
                table: "Materials",
                column: "ReorderLevel");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Materials_Price",
                table: "Materials",
                sql: "[Price] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Materials_Quantity",
                table: "Materials",
                sql: "[Quantity] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Materials_ReorderLevel",
                table: "Materials",
                sql: "[ReorderLevel] >= 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Materials_ReorderLevel",
                table: "Materials");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Materials_Price",
                table: "Materials");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Materials_Quantity",
                table: "Materials");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Materials_ReorderLevel",
                table: "Materials");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Materials",
                newName: "BuyingPrice");

            migrationBuilder.AlterColumn<int>(
                name: "ReorderLevel",
                table: "Materials",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Materials",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Materials",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Materials",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_SupplierId",
                table: "Materials",
                column: "SupplierId");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Material_BuyingPrice",
                table: "Materials",
                sql: "[BuyingPrice] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Material_Quantity",
                table: "Materials",
                sql: "[Quantity] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Material_ReorderLevel",
                table: "Materials",
                sql: "[ReorderLevel] >= 0");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Suppliers_SupplierId",
                table: "Materials",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
