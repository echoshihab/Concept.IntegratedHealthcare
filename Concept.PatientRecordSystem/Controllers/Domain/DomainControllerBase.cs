using Proto.PatientRecordSystem.DTOs;
using Proto.PatientRecordSystem.Service;
using Microsoft.AspNetCore.Mvc;

namespace Proto.PatientRecordSystem.Controllers.Domain
{
    public abstract class DomainControllerBase<TResource> : ControllerBase where TResource : IdentifiableData
    {

        public DomainControllerBase()
        {
        }

        public virtual Task<TResource> CreateAsync(TResource resource)
        {
          throw new NotImplementedException();
        }
    }
}
