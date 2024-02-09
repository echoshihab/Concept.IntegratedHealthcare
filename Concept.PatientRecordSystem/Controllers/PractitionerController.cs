
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Validation;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Concept.PatientRecordSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PractitionerController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;

        public PractitionerController(ILogger<PatientController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePractitionerAsync(JsonDocument practionerPayload)
        {
            
            var options = new JsonSerializerOptions().ForFhir(ModelInfo.ModelInspector);

            try
            {
               var practioner = JsonSerializer.Deserialize<Practitioner>(practionerPayload, options) ?? throw new ArgumentNullException();
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
        public async Task<IActionResult> GetPractitionerAsync(string id)
        {
            var practitioner = new Practitioner
            {
                Id = id,
                Name = [new HumanName { Use = HumanName.NameUse.Official, Family = "House", Given = ["Gregory"], Prefix = ["Dr."] }],
                Telecom = [new ContactPoint { System = ContactPoint.ContactPointSystem.Phone, Value = "666-5858", Use = ContactPoint.ContactPointUse.Work }]
            };

            try
            {
                practitioner.Validate(recurse: true, narrativeValidation: NarrativeValidationKind.FhirXhtml);
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
