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

            context.SaveChanges();
        }
    }
}
