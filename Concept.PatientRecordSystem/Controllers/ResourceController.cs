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

        private readonly ILogger<ResourceController> _logger;
        private readonly IResourceServiceFactory _resourceServiceFactory;

        public ResourceController(ILogger<ResourceController> logger, IResourceServiceFactory resourceServiceFactory)
        {
            _logger = logger;
            _resourceServiceFactory = resourceServiceFactory;
        }

        [HttpPost]
        public async Task<IActionResult> CreateResourceAsync(JsonDocument fhirResourcePayload)
        {
            var rawText = fhirResourcePayload.RootElement.GetRawText() ?? throw new ArgumentNullException();

            var fhirResource = JsonSerializer.Deserialize<JsonElement>(rawText);

            string resourceType = fhirResource.GetProperty(nameof(resourceType)).ToString();

            var resourceService = _resourceServiceFactory.GetResourceService(resourceType);

            await resourceService.CreateAsync(fhirResourcePayload);

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
