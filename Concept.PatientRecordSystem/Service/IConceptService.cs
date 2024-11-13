

using Proto.PatientRecordSystem.Persistence.Models;

namespace Proto.PatientRecordSystem.Service
{
    public interface IConceptService
    {
        public Task<Concept?> RetreiveConceptAsync(string value);

    }
}
