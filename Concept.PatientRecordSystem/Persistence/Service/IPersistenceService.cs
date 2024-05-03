using Concept.PatientRecordSystem.Persistence.Models;

namespace Concept.PatientRecordSystem.Persistence.Service
{
    public interface IPersistenceService<TResource> where TResource : IdentifiedData
    {
        TResource CreateAsync(TResource resource);
    }
}
