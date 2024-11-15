using Proto.PatientRecordSystem.DTOs;
using Proto.PatientRecordSystem.Exceptions;
using Proto.PatientRecordSystem.Persistence.Models;

namespace Proto.PatientRecordSystem.Service.Mapping
{
    public class PatientMappingService : IMappingService<PatientDto, Patient>
    {
        private readonly IConceptService _conceptService;

        public PatientMappingService(IConceptService conceptService)
        {
            _conceptService = conceptService;
        }
        public async Task<Patient> MapToDatabaseModelAsync(PatientDto domainResource)
        {
            var patient  = new Patient();
            patient.Individual = new Individual();            
            patient.Individual.Identifiers.Add(new Identifier { System = ApplicationConstants.InhIdentifierSystemMrn, Value = domainResource.Mrn });
            
            var genderConcept = await this._conceptService.RetreiveConceptAsync(domainResource.Gender) ?? throw new InvalidResourceException("Invalid Gender");
            
            patient.GenderConcept = genderConcept;

            patient.BirthYear = domainResource.BirthYear;
            patient.BirthMonth = domainResource.BirthMonth;
            patient.BirthDay = domainResource.BirthDay;

            var givenNameConcept = await this._conceptService.RetreiveConceptAsync(ApplicationConstants.NameTypeGiven) ?? throw new ArgumentNullException();
            var familyNameConcept = await this._conceptService.RetreiveConceptAsync(ApplicationConstants.NameTypeFamily) ?? throw new ArgumentNullException();

        
            patient.Individual.NameParts.Add(new NamePart
            {
                Value = domainResource.Name.LastName,
                Order = 0,
                NameTypeConceptId = familyNameConcept.Id
            });
            
            patient.Individual.NameParts.Add(new NamePart
            {
                Value = domainResource.Name.FirstName,
                Order = 0,
                NameTypeConceptId = givenNameConcept.Id
            });

            if (domainResource.Name.MiddleName != null)
            {
                patient.Individual.NameParts.Add(new NamePart
                {
                    Value = domainResource.Name.MiddleName,
                    Order = 1,
                    NameTypeConceptId = givenNameConcept.Id
                });
            }

            

            return patient;
        }

        public Task<PatientDto> MapToDomainModelAsync(Patient persistenceResource)
        {
            throw new NotImplementedException();
        }
    }
}
