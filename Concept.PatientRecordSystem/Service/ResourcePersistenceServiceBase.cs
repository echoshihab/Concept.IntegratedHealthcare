using Concept.PatientRecordSystem.Persistence;
using Hl7.Fhir.Model;

namespace Concept.PatientRecordSystem.Service
{
    public abstract class ResourcePersistenceServiceBase<TResource> : IResourceService<TResource> where TResource : Resource
    {
        private readonly ApplicationDbContext _context;

        public ResourcePersistenceServiceBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual Task<TResource> CreateAsync(TResource fhirResource)
        {
            throw new NotImplementedException();
        }
    }
}
