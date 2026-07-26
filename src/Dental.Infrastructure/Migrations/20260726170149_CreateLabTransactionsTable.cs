using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateLabTransactionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LabName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TranDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Treatments = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTransactions", x => x.Id);
                    table.CheckConstraint("CK_LabTransaction_PaidAmount", "[PaidAmount] >= 0");
                    table.CheckConstraint("CK_LabTransaction_TotalAmount", "[TotalAmount] >= 0");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabTransaction_LabName",
                table: "LabTransactions",
                column: "LabName");

            migrationBuilder.CreateIndex(
                name: "IX_LabTransaction_TransactionDateTime",
                table: "LabTransactions",
                column: "TranDateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabTransactions");
        }
    }
}
