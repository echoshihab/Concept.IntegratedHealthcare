using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concept.PatientRecordSystem.Migrations
{
    /// <inheritdoc />
    public partial class addGenderRelationToPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Patients_GenderConceptId",
                table: "Patients",
                column: "GenderConceptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Concepts_GenderConceptId",
                table: "Patients",
                column: "GenderConceptId",
                principalTable: "Concepts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Concepts_GenderConceptId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_GenderConceptId",
                table: "Patients");
        }
    }
}
