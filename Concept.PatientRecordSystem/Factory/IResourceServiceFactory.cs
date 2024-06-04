using Concept.PatientRecordSystem.Service;

namespace Concept.PatientRecordSystem.Factory
{
    public interface IResourceServiceFactory
    {
        IResourceService<Hl7.Fhir.Model.Resource> GetResourceService(string resourceType);
    }
}
