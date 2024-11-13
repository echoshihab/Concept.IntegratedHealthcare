using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proto.PatientRecordSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceRequestProcedureDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProcedureDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RequestSignedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    IntentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProcedureDetailId = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequesterId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Concepts_IntentId",
                        column: x => x.IntentId,
                        principalTable: "Concepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Concepts_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Concepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_PatientPractitioners_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "PatientPractitioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_ProcedureDetails_ProcedureDetailId",
                        column: x => x.ProcedureDetailId,
                        principalTable: "ProcedureDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_IntentId",
                table: "ServiceRequests",
                column: "IntentId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_PatientId",
                table: "ServiceRequests",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_ProcedureDetailId",
                table: "ServiceRequests",
                column: "ProcedureDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_RequesterId",
                table: "ServiceRequests",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_StatusId",
                table: "ServiceRequests",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceRequests");

            migrationBuilder.DropTable(
                name: "ProcedureDetails");
        }
    }
}
