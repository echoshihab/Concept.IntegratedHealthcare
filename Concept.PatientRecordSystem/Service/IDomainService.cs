
using Concept.PatientRecordSystem.DTOs;
using Concept.PatientRecordSystem.Persistence.Models;
using Hl7.Fhir.Model;

namespace Concept.PatientRecordSystem.Service
{
    public interface IDomainService<TDomain, TPersistence> where TDomain : IdentifiableData where TPersistence: IdentifiedData
    {
        Task<TDomain> CreateAsync(TDomain resource);
    }
}
