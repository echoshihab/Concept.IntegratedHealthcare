using Concept.PatientRecordSystem.Persistence.Models;

namespace Concept.PatientRecordSystem.Persistence.Service
{
    public interface IPersistenceService<TResource> where TResource : IdentifiedData
    {
        Task<TResource> CreateAsync(TResource resource);
    }
}
