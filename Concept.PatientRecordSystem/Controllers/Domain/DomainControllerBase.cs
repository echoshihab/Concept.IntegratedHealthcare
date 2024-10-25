using Concept.PatientRecordSystem.DTOs;
using Concept.PatientRecordSystem.Service;
using Microsoft.AspNetCore.Mvc;

namespace Concept.PatientRecordSystem.Controllers.Domain
{
    public abstract class DomainControllerBase<TResource> : ControllerBase where TResource : IdentifiableData
    {
        private readonly IDomainService<TResource> _domainResourceService;

        public DomainControllerBase(IDomainService<TResource> domainResourceService)
        {
            _domainResourceService = domainResourceService;
        }

        public virtual async Task<TResource> CreateAsync(TResource resource)
        {
            return await _domainResourceService.CreateAsync(resource);
        }
    }
}
