
using Proto.PatientRecordSystem.DTOs;
using Proto.PatientRecordSystem.Persistence.Models;
using Hl7.Fhir.Model;

namespace Proto.PatientRecordSystem.Service
{
    public interface IDomainService<TDomain, TPersistence> where TDomain : IdentifiableData where TPersistence: IdentifiedData
    {
        Task<TDomain> CreateAsync(TDomain resource);

        Task<IEnumerable<TDomain>> QueryAsync(Dictionary<string, string> queryParams);

        Task<TDomain> GetAsync(string id);
    }
}
