using Concept.PatientRecordSystem.Persistence;
using Concept.PatientRecordSystem.Persistence.Models;
using Concept.PatientRecordSystem.Service;


namespace Concept.PatientRecordSystem.Factory
{
    public class ResourceServiceFactory : IResourceServiceFactory
    {
        private readonly ApplicationDbContext _context;
        public ResourceServiceFactory(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IResourceService<IdentifiedData> GetResourceService(string resourceType) => resourceType.ToUpper() switch
        {
            ApplicationConstants.PATIENT => new PatientResourceService(_context),
            _ => throw new NotSupportedException("Resource type not supported")
        };
    }
}
