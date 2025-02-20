using Microsoft.AspNetCore.Mvc;
using Proto.PatientRecordSystem.DTOs;

namespace Proto.PatientRecordSystem.Controllers.Domain
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class DomainControllerBase<TResource> : ControllerBase where TResource : IdentifiableData
    {
        public DomainControllerBase()
        {
        }

        [HttpPost]
        public virtual Task<IActionResult> CreateAsync(TResource resource)
        {
          throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public virtual Task<IActionResult> GetAsync(string id) 
        { 
          throw new NotImplementedException(); 
        } 
            

        [HttpGet]
        public virtual Task<IActionResult> QueryAsync([FromQuery] Dictionary<string,string> queryParams) 
        {
            throw new NotImplementedException();
        }
    }
}
