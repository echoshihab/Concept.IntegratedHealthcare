using Concept.PatientRecordSystem.Factory;
using Hl7.Fhir.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Concept.PatientRecordSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResourceController : ControllerBase
    {

        private readonly ILogger<PatientController> _logger;
        private readonly IResourceServiceFactory _resourceServiceFactory;

        public ResourceController(ILogger<PatientController> logger, IResourceServiceFactory resourceServiceFactory)
        {
            _logger = logger;
            _resourceServiceFactory = resourceServiceFactory;
        }

        [HttpPost]
        public async Task<IActionResult> CreateResourceAsync(JsonDocument fhirResourcePayload)
        {
            string resourceType = "";

            var rawText = fhirResourcePayload.RootElement.GetRawText() ?? throw new ArgumentNullException();

            var fhirResource = JsonSerializer.Deserialize<JsonElement>(rawText);

            var resourceService = _resourceServiceFactory.GetResourceService(fhirResource.GetProperty("resourceType").ToString());

            await resourceService.CreateAsync(fhirResourcePayload);

            await System.Threading.Tasks.Task.FromResult(true);

            return new ObjectResult(
                new OperationOutcome
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
