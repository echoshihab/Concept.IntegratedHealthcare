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
    [Migration("20240409021719_addGenderRelationToPatient")]
    partial class addGenderRelationToPatient
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

                    b.Property<Guid>("AddressUseConceptId")
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<List<string>>("Lines")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<string>("PostalCode")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressUseConceptId");

                    b.HasIndex("PatientId");

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

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<string>("System")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Identifier");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.NamePart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("NameTypeConceptId")
                        .HasColumnType("uuid");

                    b.Property<short>("Order")
                        .HasColumnType("smallint");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("NameParts");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("GenderConceptId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GenderConceptId");

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

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.PatientTelecom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ContactPointUseConceptId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ContactSystemConceptId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ContactPointUseConceptId");

                    b.HasIndex("ContactSystemConceptId");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientTelecoms");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.Address", b =>
                {
                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Concept", "AddressUseConcept")
                        .WithMany()
                        .HasForeignKey("AddressUseConceptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Patient", "Patient")
                        .WithMany("Addresses")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddressUseConcept");

                    b.Navigation("Patient");
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
                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Patient", "Patient")
                        .WithMany("Identifiers")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.NamePart", b =>
                {
                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Patient", "Patient")
                        .WithMany("NameParts")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.Patient", b =>
                {
                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Concept", "GenderConcept")
                        .WithMany()
                        .HasForeignKey("GenderConceptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GenderConcept");
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

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.PatientTelecom", b =>
                {
                    b.HasOne("Concept.PatientRecordSystem.Persistence.Models.Concept", "ContactPointUseConcept")
                        .WithMany()
                        .HasForeignKey("ContactPointUseConceptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.Concept", b =>
                {
                    b.Navigation("ConceptConceptSets");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.ConceptSet", b =>
                {
                    b.Navigation("ConceptConceptSets");
                });

            modelBuilder.Entity("Concept.PatientRecordSystem.Persistence.Models.Patient", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Identifiers");

                    b.Navigation("Languages");

                    b.Navigation("NameParts");

                    b.Navigation("Telecoms");
                });
#pragma warning restore 612, 618
        }
    }
}
