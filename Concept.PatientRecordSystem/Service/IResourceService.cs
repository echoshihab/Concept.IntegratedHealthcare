using Concept.PatientRecordSystem.Persistence.Models;
using System.Text.Json;

namespace Concept.PatientRecordSystem.Service
{
    public interface IResourceService<TResource> where TResource : IdentifiedData
    {
        Task<TResource> CreateAsync(JsonDocument fhirResource);
    }
}