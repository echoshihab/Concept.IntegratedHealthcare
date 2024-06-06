using Hl7.Fhir.Model;
using System.Text.Json;

namespace Concept.PatientRecordSystem.Service
{
    public abstract class ResourcePersistenceServiceBase<TResource> : IResourceService<TResource> where TResource : Resource
    {
        public virtual Task<TResource> CreateAsync(TResource fhirResource)
        {
            throw new NotImplementedException();
        }
    }
}
