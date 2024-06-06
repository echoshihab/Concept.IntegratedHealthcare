using Concept.PatientRecordSystem.Service;
using Hl7.Fhir.Model;
using Microsoft.AspNetCore.Mvc;

namespace Concept.PatientRecordSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : FhirControllerBase<Patient>
    {
        
        public PatientController(IResourceService<Patient> patientResourceService) : base(patientResourceService)
        {
          
        }

        public override Task<IActionResult> CreateAsync(Patient resource)
        {
            return base.CreateAsync(resource);
        }      
    }
}
