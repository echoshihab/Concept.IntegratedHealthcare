using Concept.PatientRecordSystem.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Concept.PatientRecordSystem.Persistence
{
    public class DbInitializer
    {
        public static void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            SeedData(scope.ServiceProvider.GetService<ApplicationDbContext>() ?? throw new ArgumentNullException("DbContext is null"));
        }

        private static void SeedData(ApplicationDbContext context)
        {
            context.Database.Migrate();           
               
            if (!context.Modalities.Any())
            {
                var usModalityId = Guid.Parse("b845624f-ed94-4d10-9e2a-49ccacfe125f");
                var crModalityId = Guid.Parse("892f8d2a-ae9a-432e-bc98-dfd9f0455d4c");
                var drModalityId = Guid.Parse("933b6442-c5b4-48c4-a4d0-aff72e6da249");

                // Seed modalities and procedure detail
                var modalities = new List<Modality>()
                {
                    new Modality()
                    {
                        Id = usModalityId,
                        Display = "Ultrasound",
                        Code = "US",
                        Active = true
                    },
                    new Modality()
                    {
                        Id = crModalityId,
                        Display = "Computed Radiography",
                        Code = "CR",
                        Active = true
                    },
                    new Modality()
                    {
                        Id = drModalityId,
                        Display = "Digital Radiography",
                        Code = "DX",
                        Active = true
                    }
                };
                context.Modalities.AddRange(modalities);

                var procedureDetails  = new List<ProcedureDetail>()
                {
                    new ProcedureDetail()
                    {
                        Description = "XR Ankle - bilateral Single view",
                        Display = "BIANKL1V",
                        Code = "103424-8",
                        Active = true,
                        ModalityId = crModalityId
                    },
                    new ProcedureDetail()
                    {
                        Description = "XR Ankle - bilateral Single view",
                        Display = "BIANKL1V",
                        Code = "103424-8",
                        Active = true,
                        ModalityId = drModalityId
                    },
                    new ProcedureDetail()
                    {
                        Description = "US Liver",
                        Display = "LIV",
                        Code = "28614-6",
                        Active = true,
                        ModalityId = usModalityId
                    }               
                };

                context.ProcedureDetails.AddRange(procedureDetails);
            }


            // seed Practitioners, patient and service request
            if (!context.Practitioners.Any())
            {
                var individualTypePractitionerId = Guid.Parse("4297af86-e72d-4768-89c6-dfb9af9f84d0");
                var givenNameConceptId = Guid.Parse("05646cc6-b67f-4caa-be05-67b3e0bd6fe9");
                var familyNameConceptId = Guid.Parse("166daa19-2148-4d4d-991d-f6f9e83203c0");
                var workConactUseConceptId = Guid.Parse("b39b2467-fc53-42ba-a737-712e2c045d82");
                var phoneContactSystemConceptId = Guid.Parse("140076a0-a8e0-4323-a144-bc1ac83b6340");
                var practitionerId1 = Guid.Parse("c452abfa-9a7b-420f-a664-92abf8429531");
                var practitionerId2 = Guid.Parse("1ac1e797-666a-4679-9e30-92a9727dc627");
                var practitionerReferenceTypeConceptId = Guid.Parse("77f1f45b-861f-4183-9f4f-e8529e45b38f");

                var practitionerIndividual1 = new Individual()
                {
                    IndividualTypeConceptId = individualTypePractitionerId,
                    NameParts = new List<NamePart>()
                    {
                        new() { NameTypeConceptId = givenNameConceptId, Value = "John", Order = 0 },
                        new() { NameTypeConceptId = familyNameConceptId, Value = "Johnson" }
                    },
                    Identifiers = new List<Identifier>()
                    {
                        new() { System = "http://hl7.org/fhir/sid/us-npi", Value = "1942902853" }
                    }
                };

                var practitionerIndividual2 = new Individual()
                {
                    IndividualTypeConceptId = individualTypePractitionerId,
                    NameParts = new List<NamePart>()
                    {
                        new() { NameTypeConceptId = givenNameConceptId, Value = "Obrien", Order = 0 },
                        new() { NameTypeConceptId = familyNameConceptId, Value = "McDonald" }
                    },
                    Identifiers = new List<Identifier>()
                    {
                        new() { System = "http://hl7.org/fhir/sid/us-npi", Value = "9942902853" }
                    }
                };

                var practitionerTelecom1 = new PractitionerTelecom()
                {
                    ContactPointUseConceptId = workConactUseConceptId,
                    ContactSystemConceptId = phoneContactSystemConceptId,
                    Value = "666-5858"
                };

                var practitionerTelecom2 = new PractitionerTelecom()
                {
                    ContactPointUseConceptId = workConactUseConceptId,
                    ContactSystemConceptId = phoneContactSystemConceptId,
                    Value = "111-5858"
                };

                context.Practitioners.Add(new Practitioner()
                {
                    Id = practitionerId1,
                    Individual = practitionerIndividual1,
                    Telecoms = new List<PractitionerTelecom>() { practitionerTelecom1 },
                });

                context.Practitioners.Add(new Practitioner()
                {
                    Id = practitionerId2,
                    Individual = practitionerIndividual2,
                    Telecoms = new List<PractitionerTelecom>() { practitionerTelecom2 },
                });

                var patientId = Guid.Parse("1de30c99-53b5-4a35-844f-0b6ea035c171");
                var genderConceptId = Guid.Parse("8021552e-5980-45b1-bd8d-9b30d57e67e9");

                var PatientIndividual = new Individual()
                {
                    IndividualTypeConceptId = Guid.Parse("0582e424-c9c0-4e6b-a922-0dd16fb68aea"),
                    NameParts = new List<NamePart>()
                    {
                        new() { NameTypeConceptId = givenNameConceptId, Value = "James", Order = 0 },
                        new() { NameTypeConceptId = familyNameConceptId, Value = "Drogo" }
                    },
                    Identifiers = new List<Identifier>()
                    {
                        new() { System = "http://hl7.org/fhir/sid/us-npi", Value = "9942902853" }
                    }
                };

                var patientLanguage = new PatientLanguage()
                {
                    LanguageConceptId = Guid.Parse("9df86d35-0b98-4392-a4ac-dfb571140e1e"),
                };

                var patientTelecom = new PatientTelecom()
                {
                    ContactSystemConceptId = phoneContactSystemConceptId,
                    Value = "915-999-9191"
                };

                var patientPractitioner = new PatientPractitioner()
                {
                    PractitionerReferenceId = practitionerId1,
                    PractitionerReferenceTypeConceptId = practitionerReferenceTypeConceptId
                };

                context.Patients.Add(new Patient()
                {
                    Id = patientId,
                    BirthDay = 5,
                    BirthMonth = 5,
                    BirthYear = 1990,
                    GenderConceptId = genderConceptId,
                    Individual = PatientIndividual,
                    Languages = new List<PatientLanguage>() { patientLanguage },
                    Telecoms = new List<PatientTelecom>() { patientTelecom },
                    PatientPractitioners = new List<PatientPractitioner> { patientPractitioner }
                });
            }

            context.SaveChanges();
        }
    }
}
