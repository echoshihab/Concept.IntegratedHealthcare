using Concept.PatientRecordSystem.Persistence;

namespace Concept.PatientRecordSystem.Service
{
    public class ServiceRequestService : ResourcePersistenceServiceBase<Hl7.Fhir.Model.ServiceRequest>
    {
        public ServiceRequestService(ApplicationDbContext context): base(context)
        {
            
        }

        public override Task<Hl7.Fhir.Model.ServiceRequest> CreateAsync(Hl7.Fhir.Model.ServiceRequest fhirResource)
        {
            //TODO : add service request logic
            return base.CreateAsync(fhirResource);
        }
    }
}
