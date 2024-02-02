using Concept.PatientRecordSystem.Models;
using System.Text.Json;

namespace Concept.PatientRecordSystem.Service
{
    public class PatientResourceService : IResourceService<Resource>
    {
        public Task<Resource> CreateAsync(JsonDocument fhirResource)
        {
            throw new NotImplementedException();
        }
    }
}
