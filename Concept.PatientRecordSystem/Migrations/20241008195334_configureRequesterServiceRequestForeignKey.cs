using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proto.PatientRecordSystem.Migrations
{
    /// <inheritdoc />
    public partial class configureRequesterServiceRequestForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequests_PatientPractitioners_RequesterId",
                table: "ServiceRequests");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PatientPractitioners_PractitionerReferenceId",
                table: "PatientPractitioners",
                column: "PractitionerReferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequests_PatientPractitioners_RequesterId",
                table: "ServiceRequests",
                column: "RequesterId",
                principalTable: "PatientPractitioners",
                principalColumn: "PractitionerReferenceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequests_PatientPractitioners_RequesterId",
                table: "ServiceRequests");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_PatientPractitioners_PractitionerReferenceId",
                table: "PatientPractitioners");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequests_PatientPractitioners_RequesterId",
                table: "ServiceRequests",
                column: "RequesterId",
                principalTable: "PatientPractitioners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
