using Concept.PatientRecordSystem.Persistence.Models;
using Concept.PatientRecordSystem.Service;


namespace Concept.PatientRecordSystem.Factory
{
    public class ResourceServiceFactory : IResourceServiceFactory
    {
        public ResourceServiceFactory()
        {
        }
        public IResourceService<IdentifiedData> GetResourceService(string resourceType) => resourceType.ToUpper() switch
        {
            ApplicationConstants.PATIENT => new PatientResourceService(),
            _ => throw new NotSupportedException("Resource type not supported")
        };
    }
}
