using Concept.PatientRecordSystem.Models;
using Concept.PatientRecordSystem.Service;


namespace Concept.PatientRecordSystem.Factory
{
    public class ResourceServiceFactory : IResourceServiceFactory
    {
        public ResourceServiceFactory()
        {
        }
        public IResourceService<Resource> GetResourceService(string resourceType) => resourceType.ToUpper() switch
        {
            "PATIENT" => new PatientResourceService(),
            _ => throw new NotSupportedException("Resource type not supported")
        };
    }
}
