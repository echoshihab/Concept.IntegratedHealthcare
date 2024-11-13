using Proto.PatientRecordSystem.Service;
using Hl7.Fhir.Model;
using Microsoft.AspNetCore.Mvc;

namespace Proto.PatientRecordSystem.Controllers.Fhir
{
    [ApiController]
    public class PractitionerController : FhirControllerBase<Practitioner>
    {
        public PractitionerController(IResourceService<Practitioner> practionerResourceService) : base(practionerResourceService)
        {

        }

    }
}
