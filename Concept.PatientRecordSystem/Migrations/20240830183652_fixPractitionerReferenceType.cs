using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concept.PatientRecordSystem.Migrations
{
    /// <inheritdoc />
    public partial class fixPractitionerReferenceType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PractitionerReferenceTypeId",
                table: "PatientPractitioners");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PractitionerReferenceTypeId",
                table: "PatientPractitioners",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
