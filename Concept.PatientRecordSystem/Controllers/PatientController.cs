using Concept.PatientRecordSystem.Models;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Validation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net;
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
        public async Task<IActionResult> CreatePatient(JsonDocument patientString)
        {
            Patient patient;

            var options = new JsonSerializerOptions().ForFhir(ModelInfo.ModelInspector);

            try
            {
                patient = JsonSerializer.Deserialize<Patient>(patientString, options) ?? throw new ArgumentNullException();
            }
            catch (DeserializationFailedException e)
            {
                Console.WriteLine(e.Message);
            }

            await System.Threading.Tasks.Task.FromResult(true);

            return Ok();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(string id)
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
            
            return Ok();
        }
    }
}
