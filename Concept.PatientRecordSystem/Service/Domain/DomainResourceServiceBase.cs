using Concept.PatientRecordSystem.DTOs;
using Concept.PatientRecordSystem.Persistence.Models;
using Hl7.Fhir.Model;

namespace Concept.PatientRecordSystem.Service.Domain
{
    public abstract class DomainResourceServiceBase<TDomain, TPersistence>: IDomainService<TDomain, TPersistence> where TDomain : IdentifiableData where TPersistence: IdentifiedData
    {
        public readonly IMappingService<TDomain, TPersistence> _mappingService;

        protected DomainResourceServiceBase(IMappingService<TDomain, TPersistence> mappingService, IResourceService<T>)
        {
            _mappingService = mappingService;
        }

        public Task<TDomain> CreateAsync(TDomain resource)
        {
            throw new NotImplementedException();
        }
    }
}
