using Proto.PatientRecordSystem.Persistence.Models;

namespace Proto.PatientRecordSystem.Persistence.Service
{
    public interface IPersistenceService<TResource> where TResource : IdentifiedData
    {
        Task<TResource> CreateAsync(TResource resource);

        Task<TResource> GetAsync(string id);

        Task<IEnumerable<TResource>> QueryAsync(Dictionary<string, string> queryPrams);
        Task<TResource> UpdateAsync(string id, TResource resource);
    }
}
