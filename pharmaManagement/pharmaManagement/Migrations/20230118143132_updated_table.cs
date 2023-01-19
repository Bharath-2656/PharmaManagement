using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pharmaManagement.Migrations
{
    public partial class updated_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientRecords_Medicines_medicineId",
                table: "PatientRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientRecords_Patients_patientId",
                table: "PatientRecords");

            migrationBuilder.DropIndex(
                name: "IX_PatientRecords_medicineId",
                table: "PatientRecords");

            migrationBuilder.DropIndex(
                name: "IX_PatientRecords_patientId",
                table: "PatientRecords");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PatientRecords_medicineId",
                table: "PatientRecords",
                column: "medicineId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRecords_patientId",
                table: "PatientRecords",
                column: "patientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientRecords_Medicines_medicineId",
                table: "PatientRecords",
                column: "medicineId",
                principalTable: "Medicines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientRecords_Patients_patientId",
                table: "PatientRecords",
                column: "patientId",
                principalTable: "Patients",
                principalColumn: "patientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
