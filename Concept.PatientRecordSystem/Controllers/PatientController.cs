using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Validation;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Concept.PatientRecordSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {

        private readonly ILogger<PatientController> _logger;

        public PatientController(ILogger<PatientController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatientAsync(JsonDocument patientPayload)
        {
            var options = new JsonSerializerOptions().ForFhir(ModelInfo.ModelInspector);

            try
            {
                var patient = JsonSerializer.Deserialize<Patient>(patientPayload, options) ?? throw new ArgumentNullException();

     
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
                    Div = "<div xmlns=\"http://www.w3.org/1999/xhtml\">The operation was successful</div>"
                }

            })
            { StatusCode = StatusCodes.Status201Created };
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientAsync(string id)
        {
            var patient = new Patient { Id = id, Active = true, BirthDate = "4", };
            try
            {
                patient.Validate(recurse: true, narrativeValidation: NarrativeValidationKind.FhirXhtml);
            }

            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }


            await System.Threading.Tasks.Task.FromResult(true);
            return Ok();
        }
    }
}
