using Concept.PatientRecordSystem.Models;

namespace Concept.PatientRecordSystem.Service
{
    public interface IResourceServiceFactory
    {
        IResourceService<Resource> GetResourceService(string resourceType);
    }
}
