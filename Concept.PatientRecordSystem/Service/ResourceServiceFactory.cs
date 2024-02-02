using Concept.PatientRecordSystem.Models;


namespace Concept.PatientRecordSystem.Service
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
