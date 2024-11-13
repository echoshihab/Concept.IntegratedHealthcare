using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proto.PatientRecordSystem.Migrations
{
    /// <inheritdoc />
    public partial class addModalityProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Display",
                table: "ProcedureDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModalityId",
                table: "ProcedureDetails",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Modalities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Display = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureDetails_ModalityId",
                table: "ProcedureDetails",
                column: "ModalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedureDetails_Modalities_ModalityId",
                table: "ProcedureDetails",
                column: "ModalityId",
                principalTable: "Modalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcedureDetails_Modalities_ModalityId",
                table: "ProcedureDetails");

            migrationBuilder.DropTable(
                name: "Modalities");

            migrationBuilder.DropIndex(
                name: "IX_ProcedureDetails_ModalityId",
                table: "ProcedureDetails");

            migrationBuilder.DropColumn(
                name: "Display",
                table: "ProcedureDetails");

            migrationBuilder.DropColumn(
                name: "ModalityId",
                table: "ProcedureDetails");
        }
    }
}
