using Concept.PatientRecordSystem.Service;

namespace Concept.PatientRecordSystem.Factory
{
    public interface IResourceServiceFactory
    {
        IResourceService<Persistence.Models.IdentifiedData> GetResourceService(string resourceType);
    }
}
