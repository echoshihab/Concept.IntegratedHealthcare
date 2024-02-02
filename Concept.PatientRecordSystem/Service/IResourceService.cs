using Concept.PatientRecordSystem.Models;
using System.Text.Json;

namespace Concept.PatientRecordSystem.Service
{
    public interface IResourceService<TResource> where TResource : Resource
    {
        Task<TResource> CreateAsync(JsonDocument fhirResource);
    }
}