using Hl7.Fhir.Model;

namespace Concept.PatientRecordSystem.Service
{
    public interface IResourceService<TResource> where TResource : Resource
    {
        Task<TResource> CreateAsync(TResource fhirResource);
    }
}