using Proto.PatientRecordSystem.DTOs;
using Proto.PatientRecordSystem.Persistence.Models;

namespace Proto.PatientRecordSystem.Persistence.Service
{
    public class PatientPersistenceService : PersistenceServiceBase<Patient>
    {
        private IQuery queryParams = new PatientQuery();

        public PatientPersistenceService(ApplicationDbContext context): base(context)
        {
            
        }

        public override Task<Patient> CreateAsync(Patient resource)
        {
            return base.CreateAsync(resource);
        }

        public override Task<IEnumerable<Patient>> QueryAsync(Dictionary<string, string> queryParams)
        {
            // TODO: map query params to PatientQuery and query db accordingly
            // TODO: Implement convenience method in PatientQuery() that returns a built query expression
        }
    }

    
}
