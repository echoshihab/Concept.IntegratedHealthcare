using Concept.PatientRecordSystem.Persistence.Models;
using Hl7.Fhir.Model;
using System.Text.Json;

namespace Concept.PatientRecordSystem.Service
{
    public interface IResourceService<TResource> where TResource : Resource
    {
        Task<TResource> CreateAsync(JsonDocument fhirResource);
    }
}