using Proto.PatientRecordSystem.Service;
using Hl7.Fhir.Model;
using Microsoft.AspNetCore.Mvc;

namespace Proto.PatientRecordSystem.Controllers.Fhir
{
    [ApiController]
    [Route("fhir/[controller]")]
    public abstract class FhirControllerBase<TResource> : ControllerBase where TResource : Resource
    {
        private IResourceService<TResource> _resourceService;
        public FhirControllerBase(IResourceService<TResource> resourceService)
        {
            _resourceService = resourceService;
        }

        public virtual async Task<IActionResult> CreateAsync(TResource resource)
        {
            if (resource == null)
            {
                return BadRequest();
            }

            var resourcePersisted = await _resourceService.CreateAsync(resource);

            return Ok(resourcePersisted);
        }
    }
}
