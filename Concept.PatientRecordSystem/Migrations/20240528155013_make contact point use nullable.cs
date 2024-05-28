using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concept.PatientRecordSystem.Migrations
{
    /// <inheritdoc />
    public partial class makecontactpointusenullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientTelecoms_Concepts_ContactPointUseConceptId",
                table: "PatientTelecoms");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "PatientTelecoms",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ContactPointUseConceptId",
                table: "PatientTelecoms",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientTelecoms_Concepts_ContactPointUseConceptId",
                table: "PatientTelecoms",
                column: "ContactPointUseConceptId",
                principalTable: "Concepts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientTelecoms_Concepts_ContactPointUseConceptId",
                table: "PatientTelecoms");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "PatientTelecoms",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "ContactPointUseConceptId",
                table: "PatientTelecoms",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientTelecoms_Concepts_ContactPointUseConceptId",
                table: "PatientTelecoms",
                column: "ContactPointUseConceptId",
                principalTable: "Concepts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
