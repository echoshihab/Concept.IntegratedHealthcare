using Concept.PatientRecordSystem.DTOs;
using Concept.PatientRecordSystem.Persistence.Models;

namespace Concept.PatientRecordSystem.Service.Domain
{
    public class PatientDomainService : DomainResourceServiceBase<PatientDto, Patient>
    {
        
        public PatientDomainService(IMappingService<PatientDto, Patient> mappingService) : base(mappingService)
        {
            
        }

        public override Task<Patient> CreateAsync(PatientDto domainResource)
        {
            var patientDb = base._mappingService.MapToDatabaseModel(domainResource);


        }
    }
}
