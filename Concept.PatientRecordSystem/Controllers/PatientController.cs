using Concept.PatientRecordSystem.Models;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
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

            var options = new JsonSerializerOptions().ForFhir(ModelInfo.ModelInspector);
            try
            {
                Patient p = JsonSerializer.Deserialize<Patient>(patientString, options);
            }
            catch (DeserializationFailedException e)
            {
                Console.WriteLine(e.Message);
            }

            await System.Threading.Tasks.Task.FromResult(true);

            return Ok();
        }
    }
}
