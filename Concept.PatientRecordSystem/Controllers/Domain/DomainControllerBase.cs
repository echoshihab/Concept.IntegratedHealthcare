using Concept.PatientRecordSystem.DTOs;
using Concept.PatientRecordSystem.Service;
using Microsoft.AspNetCore.Mvc;

namespace Concept.PatientRecordSystem.Controllers.Domain
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
