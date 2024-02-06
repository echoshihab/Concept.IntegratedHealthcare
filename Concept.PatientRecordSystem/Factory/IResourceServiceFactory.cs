using Concept.PatientRecordSystem.Models;
using Concept.PatientRecordSystem.Service;

namespace Concept.PatientRecordSystem.Factory
{
    public interface IResourceServiceFactory
    {
        IResourceService<Resource> GetResourceService(string resourceType);
    }
}
