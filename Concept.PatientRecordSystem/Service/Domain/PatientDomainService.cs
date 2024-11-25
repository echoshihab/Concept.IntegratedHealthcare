using Proto.PatientRecordSystem.DTOs;
using Proto.PatientRecordSystem.Persistence.Models;
using Proto.PatientRecordSystem.Persistence.Service;

namespace Proto.PatientRecordSystem.Service.Domain
{
    public class PatientDomainService : DomainResourceServiceBase<PatientDto, Patient>
    {
        
        public PatientDomainService(IMappingService<PatientDto, Patient> mappingService, IPersistenceService<Patient> persistenceService) : base(mappingService, persistenceService)
        { 
            
        }

        public override async Task<PatientDto> CreateAsync(PatientDto domainResource)
        {
            var patientDb = await base._mappingService.MapToDatabaseModelAsync(domainResource);

            return await base._mappingService.MapToDomainModelAsync(await this._persistenceService.CreateAsync(patientDb));        
        }

        public override Task<IEnumerable<PatientDto>> QueryAsync(Dictionary<string, string> queryParams)
        {
            return base._persistenceService.qu
        }
    }
}
