
using Concept.PatientRecordSystem.Service;
using Hl7.Fhir.Model;
using Microsoft.AspNetCore.Mvc;

namespace Concept.PatientRecordSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PractitionerController : FhirControllerBase<Practitioner>
    {       
        public PractitionerController(IResourceService<Practitioner> practionerResourceService) : base(practionerResourceService)
        {

        }

        public override Task<IActionResult> CreateAsync(Practitioner resource)
        {
            return base.CreateAsync(resource);
        }




    }
}
