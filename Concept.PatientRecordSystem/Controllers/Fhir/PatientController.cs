using Concept.PatientRecordSystem.Service;
using Hl7.Fhir.Model;
using Microsoft.AspNetCore.Mvc;

namespace Concept.PatientRecordSystem.Controllers.Fhir
{
    [ApiController]
    public class PatientController : FhirControllerBase<Patient>
    {

        public PatientController(IResourceService<Patient> patientResourceService) : base(patientResourceService)
        {

        }

    }
}
