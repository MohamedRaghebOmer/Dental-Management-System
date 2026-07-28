using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DentalInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DoctorName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    DoctorPicturePath = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    DentalName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    DentalDescription = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    DentalPicturePath = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DentalInfo", x => x.Id);
                    table.CheckConstraint("CK_DentalInfo_OnlyOneRecord", "[Id] = 1");
                });

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

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Quantity = table.Column<decimal>(type: "TEXT", nullable: false),
                    ReorderLevel = table.Column<decimal>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.CheckConstraint("CK_Materials_Price", "[Price] >= 0");
                    table.CheckConstraint("CK_Materials_Quantity", "[Quantity] >= 0");
                    table.CheckConstraint("CK_Materials_ReorderLevel", "[ReorderLevel] >= 0");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<byte>(type: "TINYINT", nullable: false, comment: "Male = 0, Female = 1"),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.CheckConstraint("CK_Patients_AgeRange", "Age BETWEEN 0 AND 99");
                    table.CheckConstraint("CK_Patients_Gender", "Gender IN (0, 1)");
                    table.CheckConstraint("CK_Patients_PhoneNumberLength", "length(PhoneNumber) = 11");
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.CheckConstraint("CK_Suppliers_PhoneNumberLengthEqualTo11", "length(PhoneNumber) = 11");
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                    table.CheckConstraint("CK_Treatments_Price", "Price >= 0");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now', 'localtime')"),
                    ScheduledVisitDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualVisitDateTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<byte>(type: "TINYINT", nullable: false, comment: "Pending = 1, Canceled = 2, Completed = 3, Missed = 4"),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.UniqueConstraint("AK_Appointments_Id_PatientId", x => new { x.Id, x.PatientId });
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AppointmentId = table.Column<int>(type: "INTEGER", nullable: true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    VisitDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.CheckConstraint("CK_Visits_DiscountAmount_NotNegative", "[DiscountAmount] >= 0");
                    table.CheckConstraint("CK_Visits_PaidAmount_NotNegative", "[PaidAmount] >= 0");
                    table.ForeignKey(
                        name: "FK_Visits_Appointments_AppointmentId_PatientId",
                        columns: x => new { x.AppointmentId, x.PatientId },
                        principalTable: "Appointments",
                        principalColumns: new[] { "Id", "PatientId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visits_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: true),
                    VisitId = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "PrescriptionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrescriptionId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicineName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Dosage = table.Column<decimal>(type: "TEXT", nullable: false),
                    MedicineFrequency = table.Column<int>(type: "INTEGER", nullable: false),
                    Period = table.Column<byte>(type: "INTEGER", nullable: false),
                    Instructions = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionItems", x => x.Id);
                    table.CheckConstraint("CK_PrescriptionItems_Dosage", "[Dosage] > 0");
                    table.CheckConstraint("CK_PrescriptionItems_Period", "[Period] BETWEEN 1 AND 3");
                    table.ForeignKey(
                        name: "FK_PrescriptionItems_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DentalInfo",
                columns: new[] { "Id", "DentalDescription", "DentalName", "DentalPicturePath", "DoctorName", "DoctorPicturePath", "PhoneNumber" },
                values: new object[] { 1, "طب الفم والأسنان", "إبتسامه", null, "د/ كريم فتوح", null, "01006169816" });

            migrationBuilder.InsertData(
                table: "Treatments",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, null, "حشو عصب", 260.00m },
                    { 2, null, "حشو ليزر", 450.00m },
                    { 3, null, "تركيبات", 130.00m },
                    { 4, null, "خلع", 120.00m },
                    { 5, null, "زراعه", 730.00m },
                    { 6, null, "تقويم", 1530.00m },
                    { 7, null, "تنظيف جير", 204.00m },
                    { 8, null, "تلميع", 143.00m },
                    { 9, null, "تبيض", 138.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTransaction_LabName",
                table: "LabTransactions",
                column: "LabName");

            migrationBuilder.CreateIndex(
                name: "IX_LabTransaction_TransactionDateTime",
                table: "LabTransactions",
                column: "TranDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_Name",
                table: "Materials",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_Quantity",
                table: "Materials",
                column: "Quantity");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ReorderLevel",
                table: "Materials",
                column: "ReorderLevel");

            migrationBuilder.CreateIndex(
                name: "UX_Patients_Name",
                table: "Patients",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionItems_PrescriptionId",
                table: "PrescriptionItems",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "UX_PrescriptionItems_PrescriptionId_MedicineName",
                table: "PrescriptionItems",
                columns: new[] { "PrescriptionId", "MedicineName" },
                unique: true);

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
                name: "UX_Supplier_Name",
                table: "Suppliers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Supplier_PhoneNumber",
                table: "Suppliers",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UX_Treatments_Name",
                table: "Treatments",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_AppointmentId_PatientId",
                table: "Visits",
                columns: new[] { "AppointmentId", "PatientId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PatientId",
                table: "Visits",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_VisitDateTime",
                table: "Visits",
                column: "VisitDateTime");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DentalInfo");

            migrationBuilder.DropTable(
                name: "LabTransactions");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "PrescriptionItems");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "VisitTreatments");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
