using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concept.PatientRecordSystem.Migrations
{
    /// <inheritdoc />
    public partial class RemovePractitionerForeignKeyFromAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Practitioners_PractitionerId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_PractitionerId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PractitionerId",
                table: "Addresses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PractitionerId",
                table: "Addresses",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PractitionerId",
                table: "Addresses",
                column: "PractitionerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Practitioners_PractitionerId",
                table: "Addresses",
                column: "PractitionerId",
                principalTable: "Practitioners",
                principalColumn: "Id");
        }
    }
}
