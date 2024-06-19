using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concept.PatientRecordSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddSupportForPractitionerReferenceType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientPractitioners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    PractitionerReferenceId = table.Column<Guid>(type: "uuid", nullable: false),
                    PractitionerReferenceTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    PractitionerReferenceTypeConceptId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientPractitioners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientPractitioners_Concepts_PractitionerReferenceTypeConc~",
                        column: x => x.PractitionerReferenceTypeConceptId,
                        principalTable: "Concepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientPractitioners_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientPractitioners_PatientId",
                table: "PatientPractitioners",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientPractitioners_PractitionerReferenceTypeConceptId",
                table: "PatientPractitioners",
                column: "PractitionerReferenceTypeConceptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientPractitioners");
        }
    }
}
