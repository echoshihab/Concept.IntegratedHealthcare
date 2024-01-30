using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Validation;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Concept.PatientRecordSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResourceController : ControllerBase
    {

        private readonly ILogger<PatientController> _logger;

        public ResourceController(ILogger<PatientController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateResourceAsync(JsonDocument fhirResourcePayload)
        {
            string resourceType = "";

            try
            {
                var rawText = fhirResourcePayload.RootElement.GetRawText() ?? throw new ArgumentNullException();

                var fhirResource = JsonSerializer.Deserialize<JsonElement>(rawText);

                resourceType = fhirResource.GetProperty("resourceType").ToString();

            }
            catch (DeserializationFailedException e)
            {
                Console.WriteLine(e.Message);
            }

            await System.Threading.Tasks.Task.FromResult(true);


            return new ObjectResult(new OperationOutcome
            {

                Text = new Narrative
                {
                    Status = Narrative.NarrativeStatus.Generated,
                    Div = $"<div xmlns=\"http://www.w3.org/1999/xhtml\">The operation was successful with {resourceType}</div>"
                }

            })
            { StatusCode = StatusCodes.Status201Created };
        }

    }
}
