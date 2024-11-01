using Concept.PatientRecordSystem.DTOs;
using Concept.PatientRecordSystem.Persistence.Models;
using Concept.PatientRecordSystem.Persistence.Service;

namespace Concept.PatientRecordSystem.Service.Domain
{
    public class PatientDomainService : DomainResourceServiceBase<PatientDto, Patient>
    {
        
        public PatientDomainService(IMappingService<PatientDto, Patient> mappingService, IPersistenceService<Patient> persistenceService) : base(mappingService, persistenceService)
        { 
            
        }

        public override async Task<PatientDto> CreateAsync(PatientDto domainResource)
        {
            var patientDb = base._mappingService.MapToDatabaseModel(domainResource);

            return base._mappingService.MapToDomainModel(await this._persistenceService.CreateAsync(patientDb));        
        }
    }
}
