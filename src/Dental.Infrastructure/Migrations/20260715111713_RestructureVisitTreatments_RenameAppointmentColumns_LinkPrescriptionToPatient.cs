using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RestructureVisitTreatments_RenameAppointmentColumns_LinkPrescriptionToPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionItems_Prescriptions_PrescriptionId",
                table: "PrescriptionItems");

            migrationBuilder.DropTable(
                name: "VisitToothTreatments");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_VisitId",
                table: "Prescriptions");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Patient_Gender",
                table: "Patients");

            migrationBuilder.RenameIndex(
                name: "UX_Visits_DateTime",
                table: "Visits",
                newName: "UX_Visits_VisitDateTime");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Appointments",
                newName: "ScheduledVisitDateTime");

            migrationBuilder.RenameColumn(
                name: "CompletedAt",
                table: "Appointments",
                newName: "ActualVisitDateTime");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Prescriptions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Appointments",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "DATETIME('now', 'localtime')");

            migrationBuilder.CreateTable(
                name: "VisitTreatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ToothNumber = table.Column<byte>(type: "INTEGER", nullable: false),
                    VisitId = table.Column<int>(type: "INTEGER", nullable: false),
                    TreatmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitTreatments", x => x.Id);
                    table.CheckConstraint("CK_VisitTreatments_Price_NonNegative", "[Price] >= 0");
                    table.CheckConstraint("CK_VisitTreatments_ToothNumber_Range", "[ToothNumber] >= 1 AND [ToothNumber] <= 32");
                    table.ForeignKey(
                        name: "FK_VisitTreatments_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VisitTreatments_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 260.00m);

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 450.00m);

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 130.00m);

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 120.00m);

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 730.00m);

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 1530.00m);

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 7,
                column: "Price",
                value: 204.00m);

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 8,
                column: "Price",
                value: 143.00m);

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 9,
                column: "Price",
                value: 138.00m);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Suppliers_PhoneNumberLengthEqualTo11",
                table: "Suppliers",
                sql: "length(PhoneNumber) = 11");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescriptions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "UX_Prescriptions_VisitId",
                table: "Prescriptions",
                column: "VisitId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_PrescriptionItems_PrescriptionId_MedicineName",
                table: "PrescriptionItems",
                columns: new[] { "PrescriptionId", "MedicineName" },
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Patients_Gender",
                table: "Patients",
                sql: "Gender IN (1, 2)");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Patients_PhoneNumberLengthEqualTo11",
                table: "Patients",
                sql: "length(PhoneNumber) = 11");

            migrationBuilder.CreateIndex(
                name: "IX_VisitTreatments_TreatmentId",
                table: "VisitTreatments",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitTreatments_VisitId",
                table: "VisitTreatments",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "UX_VisitTreatments_ToothNumber_VisitId_TreatmentId",
                table: "VisitTreatments",
                columns: new[] { "ToothNumber", "VisitId", "TreatmentId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionItems_Prescriptions_PrescriptionId",
                table: "PrescriptionItems",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Patients_PatientId",
                table: "Prescriptions",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionItems_Prescriptions_PrescriptionId",
                table: "PrescriptionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Patients_PatientId",
                table: "Prescriptions");

            migrationBuilder.DropTable(
                name: "VisitTreatments");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Suppliers_PhoneNumberLengthEqualTo11",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "UX_Prescriptions_VisitId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "UX_PrescriptionItems_PrescriptionId_MedicineName",
                table: "PrescriptionItems");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Patients_Gender",
                table: "Patients");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Patients_PhoneNumberLengthEqualTo11",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Appointments");

            migrationBuilder.RenameIndex(
                name: "UX_Visits_VisitDateTime",
                table: "Visits",
                newName: "UX_Visits_DateTime");

            migrationBuilder.RenameColumn(
                name: "ScheduledVisitDateTime",
                table: "Appointments",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "ActualVisitDateTime",
                table: "Appointments",
                newName: "CompletedAt");

            migrationBuilder.CreateTable(
                name: "VisitToothTreatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TreatmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    VisitId = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    ToothNumber = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitToothTreatments", x => x.Id);
                    table.CheckConstraint("CK_VisitToothTreatments_Price_NonNegative", "[Price] >= 0");
                    table.CheckConstraint("CK_VisitToothTreatments_ToothNumber_Range", "[ToothNumber] >= 1 AND [ToothNumber] <= 32");
                    table.ForeignKey(
                        name: "FK_VisitToothTreatments_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VisitToothTreatments_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 100.00m);

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 100.00m);

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 100.00m);

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 100.00m);

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 100.00m);

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 100.00m);

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 7,
                column: "Price",
                value: 100.00m);

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 8,
                column: "Price",
                value: 100.00m);

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 9,
                column: "Price",
                value: 100.00m);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_VisitId",
                table: "Prescriptions",
                column: "VisitId");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Patient_Gender",
                table: "Patients",
                sql: "Gender IN (1, 2)");

            migrationBuilder.CreateIndex(
                name: "IX_VisitToothTreatments_ToothNumber",
                table: "VisitToothTreatments",
                column: "ToothNumber");

            migrationBuilder.CreateIndex(
                name: "IX_VisitToothTreatments_TreatmentId",
                table: "VisitToothTreatments",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitToothTreatments_VisitId",
                table: "VisitToothTreatments",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "UX_VisitToothTreatments_ToothNumber_VisitId_TreatmentId",
                table: "VisitToothTreatments",
                columns: new[] { "ToothNumber", "VisitId", "TreatmentId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionItems_Prescriptions_PrescriptionId",
                table: "PrescriptionItems",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
