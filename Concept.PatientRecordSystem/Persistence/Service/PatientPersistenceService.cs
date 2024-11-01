using Concept.PatientRecordSystem.Persistence.Models;

namespace Concept.PatientRecordSystem.Persistence.Service
{
    public class PatientPersistenceService : PersistenceServiceBase<Patient>
    {
        public PatientPersistenceService(ApplicationDbContext context): base(context)
        {
            
        }

        public override Task<Patient> CreateAsync(Patient resource)
        {

            return base.CreateAsync(resource);
        }
    }

    
}
