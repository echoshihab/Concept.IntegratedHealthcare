using Hl7.Fhir.Model;

namespace Proto.PatientRecordSystem.Service
{
    public interface IResourceService<TResource> where TResource : Resource
    {
        Task<TResource> CreateAsync(TResource fhirResource);
    }
}