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
            
            var genderConcept = await this._conceptService.RetreiveConceptAsync(domainResource.Gender.ToString()) ?? throw new InvalidResourceException("Invalid Gender");
            
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


            var phoneNameConcept = await this._conceptService.RetreiveConceptAsync(ApplicationConstants.ContactPointTypePhone) ?? throw new ArgumentNullException();

            if (domainResource.PhoneNumbers.Count > 0)
            {
                foreach ( var phoneNumber in domainResource.PhoneNumbers )
                {
                    var patientTelecom = new PatientTelecom
                    {
                        Value = phoneNumber.Value,
                        ContactSystemConceptId = phoneNameConcept.Id
                    };
                                        
                    if (!string.IsNullOrWhiteSpace(phoneNumber.Use))
                    {
                       var useConcept =  await this._conceptService.RetreiveConceptAsync(phoneNumber.Use) ?? throw new InvalidResourceException();
                       patientTelecom.ContactPointUseConceptId = useConcept.Id;
                    }

                    patient.Telecoms.Add(patientTelecom);
                }               
            }

            if (!string.IsNullOrWhiteSpace(domainResource.Email))
            {
                var emailConcept = await this._conceptService.RetreiveConceptAsync(ApplicationConstants.ContactPointTypeEmail) ?? throw new InvalidResourceException();

                patient.Telecoms.Add(new PatientTelecom
                {
                    Value = domainResource.Email,
                    ContactSystemConceptId = emailConcept.Id
                });
            }

            if (domainResource.Language != null)
            {
                var preferredLanguageConcept = await this._conceptService.RetreiveConceptAsync(domainResource.Language.Preferred) ?? throw new InvalidResourceException();

                patient.Languages.Add(new PatientLanguage
                {
                    LanguageConceptId = preferredLanguageConcept.Id,
                });

                if (!string.IsNullOrWhiteSpace(domainResource.Language.Alternate))
                {
                    var alternateLanguageConcept = await this._conceptService.RetreiveConceptAsync(domainResource.Language.Alternate) ?? throw new InvalidResourceException();

                    patient.Languages.Add(new PatientLanguage
                    {
                        LanguageConceptId = alternateLanguageConcept.Id,
                    });
                }
            }

            return patient;
        }

        public Task<PatientDto> MapToDomainModelAsync(Patient persistenceResource)
        {
            throw new NotImplementedException();
        }
    }
}
