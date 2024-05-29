using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concept.PatientRecordSystem.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAddressUseConceptToNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Concepts_AddressUseConceptId",
                table: "Addresses");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressUseConceptId",
                table: "Addresses",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Concepts_AddressUseConceptId",
                table: "Addresses",
                column: "AddressUseConceptId",
                principalTable: "Concepts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Concepts_AddressUseConceptId",
                table: "Addresses");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressUseConceptId",
                table: "Addresses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Concepts_AddressUseConceptId",
                table: "Addresses",
                column: "AddressUseConceptId",
                principalTable: "Concepts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
