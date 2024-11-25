using Microsoft.AspNetCore.Mvc;
using Proto.PatientRecordSystem.DTOs;

namespace Proto.PatientRecordSystem.Controllers.Domain
{
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

        public virtual Task<IActionResult> QueryAsync([FromQuery] Dictionary<string,string> queryParams) 
        {
            throw new NotImplementedException();
        }
    }
}
