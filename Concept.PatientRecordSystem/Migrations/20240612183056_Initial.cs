using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proto.PatientRecordSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConceptSets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConceptSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Concepts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Display = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concepts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConceptConceptSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConceptId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConceptSetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConceptConceptSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConceptConceptSet_ConceptSets_ConceptSetId",
                        column: x => x.ConceptSetId,
                        principalTable: "ConceptSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConceptConceptSet_Concepts_ConceptId",
                        column: x => x.ConceptId,
                        principalTable: "Concepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Individuals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IndividualTypeConceptId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individuals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Individuals_Concepts_IndividualTypeConceptId",
                        column: x => x.IndividualTypeConceptId,
                        principalTable: "Concepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Identifier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    System = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: false),
                    IndividualId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identifier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Identifier_Individuals_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NameParts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Order = table.Column<short>(type: "smallint", nullable: false),
                    NameTypeConceptId = table.Column<Guid>(type: "uuid", nullable: false),
                    IndividualId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NameParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NameParts_Individuals_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GenderConceptId = table.Column<Guid>(type: "uuid", nullable: false),
                    BirthYear = table.Column<int>(type: "integer", nullable: false),
                    BirthMonth = table.Column<int>(type: "integer", nullable: false),
                    BirthDay = table.Column<int>(type: "integer", nullable: false),
                    IndividualId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Concepts_GenderConceptId",
                        column: x => x.GenderConceptId,
                        principalTable: "Concepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_Individuals_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Practitioners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IndividualId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practitioners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Practitioners_Individuals_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientLanguages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LanguageConceptId = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientLanguages_Concepts_LanguageConceptId",
                        column: x => x.LanguageConceptId,
                        principalTable: "Concepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientLanguages_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientTelecoms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactSystemConceptId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactPointUseConceptId = table.Column<Guid>(type: "uuid", nullable: true),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTelecoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientTelecoms_Concepts_ContactPointUseConceptId",
                        column: x => x.ContactPointUseConceptId,
                        principalTable: "Concepts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientTelecoms_Concepts_ContactSystemConceptId",
                        column: x => x.ContactSystemConceptId,
                        principalTable: "Concepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientTelecoms_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IndividualId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressUseConceptId = table.Column<Guid>(type: "uuid", nullable: true),
                    Lines = table.Column<List<string>>(type: "text[]", nullable: false),
                    City = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    PractitionerId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Concepts_AddressUseConceptId",
                        column: x => x.AddressUseConceptId,
                        principalTable: "Concepts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_Individuals_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Practitioners_PractitionerId",
                        column: x => x.PractitionerId,
                        principalTable: "Practitioners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PractitionerTelecoms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactSystemConceptId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactPointUseConceptId = table.Column<Guid>(type: "uuid", nullable: true),
                    PractitionerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PractitionerTelecoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PractitionerTelecoms_Concepts_ContactPointUseConceptId",
                        column: x => x.ContactPointUseConceptId,
                        principalTable: "Concepts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PractitionerTelecoms_Concepts_ContactSystemConceptId",
                        column: x => x.ContactSystemConceptId,
                        principalTable: "Concepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PractitionerTelecoms_Practitioners_PractitionerId",
                        column: x => x.PractitionerId,
                        principalTable: "Practitioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressUseConceptId",
                table: "Addresses",
                column: "AddressUseConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_IndividualId",
                table: "Addresses",
                column: "IndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PractitionerId",
                table: "Addresses",
                column: "PractitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptConceptSet_ConceptId",
                table: "ConceptConceptSet",
                column: "ConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptConceptSet_ConceptSetId",
                table: "ConceptConceptSet",
                column: "ConceptSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Identifier_IndividualId",
                table: "Identifier",
                column: "IndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_Individuals_IndividualTypeConceptId",
                table: "Individuals",
                column: "IndividualTypeConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_NameParts_IndividualId",
                table: "NameParts",
                column: "IndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientLanguages_LanguageConceptId",
                table: "PatientLanguages",
                column: "LanguageConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientLanguages_PatientId",
                table: "PatientLanguages",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTelecoms_ContactPointUseConceptId",
                table: "PatientTelecoms",
                column: "ContactPointUseConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTelecoms_ContactSystemConceptId",
                table: "PatientTelecoms",
                column: "ContactSystemConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTelecoms_PatientId",
                table: "PatientTelecoms",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_GenderConceptId",
                table: "Patients",
                column: "GenderConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_IndividualId",
                table: "Patients",
                column: "IndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_PractitionerTelecoms_ContactPointUseConceptId",
                table: "PractitionerTelecoms",
                column: "ContactPointUseConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_PractitionerTelecoms_ContactSystemConceptId",
                table: "PractitionerTelecoms",
                column: "ContactSystemConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_PractitionerTelecoms_PractitionerId",
                table: "PractitionerTelecoms",
                column: "PractitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_Practitioners_IndividualId",
                table: "Practitioners",
                column: "IndividualId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ConceptConceptSet");

            migrationBuilder.DropTable(
                name: "Identifier");

            migrationBuilder.DropTable(
                name: "NameParts");

            migrationBuilder.DropTable(
                name: "PatientLanguages");

            migrationBuilder.DropTable(
                name: "PatientTelecoms");

            migrationBuilder.DropTable(
                name: "PractitionerTelecoms");

            migrationBuilder.DropTable(
                name: "ConceptSets");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Practitioners");

            migrationBuilder.DropTable(
                name: "Individuals");

            migrationBuilder.DropTable(
                name: "Concepts");
        }
    }
}
