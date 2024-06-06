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

        //[HttpPost]
        //public async Task<IActionResult> CreateResourceAsync(JsonDocument fhirResourcePayload)
        //{
        //    var rawText = fhirResourcePayload.RootElement.GetRawText() ?? throw new ArgumentNullException();

        //    var fhirResource = JsonSerializer.Deserialize<JsonElement>(rawText);

        //    string resourceType = fhirResource.GetProperty(nameof(resourceType)).ToString();

        //    var resourceService = _resourceServiceFactory.GetResourceService(resourceType);

        //    await resourceService.CreateAsync(fhirResourcePayload);

        //    return new ObjectResult(new OperationOutcome
        //        {
        //            Text = new Narrative
        //            {
        //                Status = Narrative.NarrativeStatus.Generated,
        //                Div = $"<div xmlns=\"http://www.w3.org/1999/xhtml\">The operation was successful with {resourceType}</div>"
        //            }
        //        })
        //        { StatusCode = StatusCodes.Status201Created };
        //}
    }
}
