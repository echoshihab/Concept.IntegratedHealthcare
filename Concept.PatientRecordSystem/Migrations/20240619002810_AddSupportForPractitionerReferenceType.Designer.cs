﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Concept.PatientRecordSystem.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Concept.PatientRecordSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240619002810_AddSupportForPractitionerReferenceType")]
    partial class AddSupportForPractitionerReferenceType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AddressUseConceptId")
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<Guid>("IndividualId")
                        .HasColumnType("uuid");

                    b.Property<List<string>>("Lines")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("PostalCode")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressUseConceptId");

                    b.HasIndex("IndividualId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.Concept", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Display")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Concepts");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.ConceptConceptSet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ConceptId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ConceptSetId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ConceptId");

                    b.HasIndex("ConceptSetId");

                    b.ToTable("ConceptConceptSet");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.ConceptSet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ConceptSets");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.Identifier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IndividualId")
                        .HasColumnType("uuid");

                    b.Property<string>("System")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IndividualId");

                    b.ToTable("Identifier");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.Individual", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IndividualTypeConceptId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("IndividualTypeConceptId");

                    b.ToTable("Individuals");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.NamePart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IndividualId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("NameTypeConceptId")
                        .HasColumnType("uuid");

                    b.Property<short>("Order")
                        .HasColumnType("smallint");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IndividualId");

                    b.ToTable("NameParts");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("BirthDay")
                        .HasColumnType("integer");

                    b.Property<int>("BirthMonth")
                        .HasColumnType("integer");

                    b.Property<int>("BirthYear")
                        .HasColumnType("integer");

                    b.Property<Guid>("GenderConceptId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IndividualId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GenderConceptId");

                    b.HasIndex("IndividualId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.PatientLanguage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("LanguageConceptId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LanguageConceptId");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientLanguages");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.PatientPractitioner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PractitionerReferenceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PractitionerReferenceTypeConceptId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PractitionerReferenceTypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("PractitionerReferenceTypeConceptId");

                    b.ToTable("PatientPractitioners");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.PatientTelecom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ContactPointUseConceptId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ContactSystemConceptId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ContactPointUseConceptId");

                    b.HasIndex("ContactSystemConceptId");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientTelecoms");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.Practitioner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IndividualId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("IndividualId");

                    b.ToTable("Practitioners");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.PractitionerTelecom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ContactPointUseConceptId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ContactSystemConceptId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PractitionerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ContactPointUseConceptId");

                    b.HasIndex("ContactSystemConceptId");

                    b.HasIndex("PractitionerId");

                    b.ToTable("PractitionerTelecoms");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.Address", b =>
                {
                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Concept", "AddressUseConcept")
                        .WithMany()
                        .HasForeignKey("AddressUseConceptId");

                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Individual", "Individual")
                        .WithMany("Addresses")
                        .HasForeignKey("IndividualId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddressUseConcept");

                    b.Navigation("Individual");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.ConceptConceptSet", b =>
                {
                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Concept", "Concept")
                        .WithMany("ConceptConceptSets")
                        .HasForeignKey("ConceptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.ConceptSet", "ConceptSet")
                        .WithMany("ConceptConceptSets")
                        .HasForeignKey("ConceptSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concept");

                    b.Navigation("ConceptSet");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.Identifier", b =>
                {
                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Individual", "Individual")
                        .WithMany("Identifiers")
                        .HasForeignKey("IndividualId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Individual");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.Individual", b =>
                {
                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Concept", "IndividualTypeConcept")
                        .WithMany()
                        .HasForeignKey("IndividualTypeConceptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IndividualTypeConcept");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.NamePart", b =>
                {
                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Individual", "Individual")
                        .WithMany("NameParts")
                        .HasForeignKey("IndividualId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Individual");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.Patient", b =>
                {
                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Concept", "GenderConcept")
                        .WithMany()
                        .HasForeignKey("GenderConceptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Individual", "Individual")
                        .WithMany()
                        .HasForeignKey("IndividualId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GenderConcept");

                    b.Navigation("Individual");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.PatientLanguage", b =>
                {
                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Concept", "LanguageConcept")
                        .WithMany()
                        .HasForeignKey("LanguageConceptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Patient", "Patient")
                        .WithMany("Languages")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LanguageConcept");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.PatientPractitioner", b =>
                {
                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Patient", "Patient")
                        .WithMany("PatientPractitioners")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Concept", "PractitionerReferenceTypeConcept")
                        .WithMany()
                        .HasForeignKey("PractitionerReferenceTypeConceptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("PractitionerReferenceTypeConcept");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.PatientTelecom", b =>
                {
                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Concept", "ContactPointUseConcept")
                        .WithMany()
                        .HasForeignKey("ContactPointUseConceptId");

                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Concept", "ContactSystemConcept")
                        .WithMany()
                        .HasForeignKey("ContactSystemConceptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Patient", "Patient")
                        .WithMany("Telecoms")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactPointUseConcept");

                    b.Navigation("ContactSystemConcept");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.Practitioner", b =>
                {
                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Individual", "Individual")
                        .WithMany()
                        .HasForeignKey("IndividualId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Individual");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.PractitionerTelecom", b =>
                {
                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Concept", "ContactPointUseConcept")
                        .WithMany()
                        .HasForeignKey("ContactPointUseConceptId");

                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Concept", "ContactSystemConcept")
                        .WithMany()
                        .HasForeignKey("ContactSystemConceptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Practitioner", "Practitioner")
                        .WithMany("Telecoms")
                        .HasForeignKey("PractitionerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactPointUseConcept");

                    b.Navigation("ContactSystemConcept");

                    b.Navigation("Practitioner");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.Concept", b =>
                {
                    b.Navigation("ConceptConceptSets");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.ConceptSet", b =>
                {
                    b.Navigation("ConceptConceptSets");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.Individual", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Identifiers");

                    b.Navigation("NameParts");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.Patient", b =>
                {
                    b.Navigation("Languages");

                    b.Navigation("PatientPractitioners");

                    b.Navigation("Telecoms");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.Practitioner", b =>
                {
                    b.Navigation("Telecoms");
                });
#pragma warning restore 612, 618
        }
    }
}
