using Concept.PatientRecordSystem.DTOs;

namespace Concept.PatientRecordSystem.Service.Domain
{
    public abstract class DomainResourceServiceBase<TResource> : IDomainService<TResource> where TResource : IdentifiableData
    {
        public Task<TResource> CreateAsync(TResource resource)
        {
            throw new NotImplementedException();
        }
    }
}
