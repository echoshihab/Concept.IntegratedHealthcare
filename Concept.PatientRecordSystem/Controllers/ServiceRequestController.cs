using Concept.PatientRecordSystem.Service;
using Hl7.Fhir.Model;
using Microsoft.AspNetCore.Mvc;

namespace Concept.PatientRecordSystem.Controllers
{
    public class ServiceRequestController : FhirControllerBase<ServiceRequest>
    {
        public ServiceRequestController(IResourceService<ServiceRequest> serviceRequestResourceService) : base(serviceRequestResourceService)
        {
            
        }

        public override Task<IActionResult> CreateAsync(ServiceRequest resource)
        {
            return base.CreateAsync(resource);
        }
    }
}
