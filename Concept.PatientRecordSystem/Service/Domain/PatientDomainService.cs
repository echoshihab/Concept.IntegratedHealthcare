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

        public override async Task<IEnumerable<PatientDto>> QueryAsync(Dictionary<string, string> queryParams)
        {
            var dbPatients = await this._persistenceService.QueryAsync(queryParams);
            return await Task.WhenAll(dbPatients.Select(async p => await base._mappingService.MapToDomainModelAsync(p)));                    
        }



        public override async Task<PatientDto> GetAsync(string mrn)
        {
            return await base._mappingService.MapToDomainModelAsync(await this._persistenceService.GetAsync(mrn));
        }

        public override async Task<PatientDto> UpdateAsync(string mrn, PatientDto resource)
        {
            var patientDb = await base._mappingService.MapToDatabaseModelAsync(resource);
            return await base._mappingService.MapToDomainModelAsync(await this._persistenceService.UpdateAsync(mrn, patientDb));
        }
    }
}
