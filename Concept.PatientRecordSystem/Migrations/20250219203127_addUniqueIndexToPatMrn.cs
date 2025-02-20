using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proto.PatientRecordSystem.Migrations
{
    /// <inheritdoc />
    public partial class addUniqueIndexToPatMrn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Patients_Mrn",
                table: "Patients",
                column: "Mrn",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_Mrn",
                table: "Patients");
        }
    }
}
