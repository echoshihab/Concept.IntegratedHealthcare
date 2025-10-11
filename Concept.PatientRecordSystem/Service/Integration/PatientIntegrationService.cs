using Proto.PatientRecordSystem.Persistence.Models;
using Proto.PatientRecordSystem.Service.Mapping.Interfaces;
using Proto.PatientRecordSystem.Service.Queue.Interfaces;

namespace Proto.PatientRecordSystem.Service.Integration
{
    public class PatientIntegrationService : IntegrationServiceBase<Patient, Hl7.Fhir.Model.Patient>
    {
        public PatientIntegrationService(IFhirMappingService<Patient, Hl7.Fhir.Model.Patient> fhirMappingService, IResourceQueueService<Hl7.Fhir.Model.Patient> resourceQueueService) : base(fhirMappingService, resourceQueueService)
        {
        }
    }
}
