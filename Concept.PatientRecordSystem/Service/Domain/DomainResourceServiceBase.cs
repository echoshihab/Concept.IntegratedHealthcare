﻿using Proto.PatientRecordSystem.DTOs;
using Proto.PatientRecordSystem.Persistence.Models;
using Proto.PatientRecordSystem.Persistence.Service;
using Hl7.Fhir.Model;

namespace Proto.PatientRecordSystem.Service.Domain
{
    public abstract class DomainResourceServiceBase<TDomain, TPersistence>: IDomainService<TDomain, TPersistence> where TDomain : IdentifiableData where TPersistence: IdentifiedData
    {
        protected readonly IMappingService<TDomain, TPersistence> _mappingService;
        protected readonly IPersistenceService<TPersistence> _persistenceService;

        protected DomainResourceServiceBase(IMappingService<TDomain, TPersistence> mappingService, IPersistenceService<TPersistence> persistenceService)
        {
            _mappingService = mappingService;
            _persistenceService = persistenceService;
        }

        public virtual Task<TDomain> CreateAsync(TDomain resource)
        {
            throw new NotImplementedException();
        }
    }
}
