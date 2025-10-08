using Proto.PatientRecordSystem.Persistence.Models;
using Proto.PatientRecordSystem.Service.Mapping.Interfaces;

namespace Proto.PatientRecordSystem.Service.Mapping
{
    public class PatientFhirMappingService : IFhirMappingService<Hl7.Fhir.Model.Patient, Patient>
    {
        private readonly ConceptService _conceptService;

        public PatientFhirMappingService(ConceptService conceptService)
        {
            _conceptService = conceptService;
        }
        public async Task<Hl7.Fhir.Model.Patient> MapToFhirResourceAsync(Patient persistentResource)
        {
            var fhirPatient = new Hl7.Fhir.Model.Patient();

            // Birthdate
            fhirPatient.BirthDate = string.Join("-", persistentResource.BirthYear, persistentResource.BirthMonth, persistentResource.BirthDay);
            
            // Gender
            fhirPatient.Gender = Enum.TryParse< Hl7.Fhir.Model.AdministrativeGender>(persistentResource.GenderConcept.Value, true, out Hl7.Fhir.Model.AdministrativeGender gender) ? gender : Hl7.Fhir.Model.AdministrativeGender.Unknown;

            
            var individual = persistentResource?.Individual ?? throw new NullReferenceException();
           
            // Identifiers
            foreach (var identifier in individual.Identifiers)
            {
                fhirPatient.Identifier.Add(new Hl7.Fhir.Model.Identifier
                {
                    System = identifier.System,
                    Value  = identifier.Value,
                });
            }

            // Name
            var givenNameConceptId = (await this._conceptService.RetreiveConceptAsync(ApplicationConstants.NameTypeGiven))?.Id ?? throw new NullReferenceException();
            var familyNameConceptId = (await this._conceptService.RetreiveConceptAsync(ApplicationConstants.NameTypeFamily))?.Id ?? throw new NullReferenceException();


            fhirPatient.Name.Add(new Hl7.Fhir.Model.HumanName
            {
                Use = Hl7.Fhir.Model.HumanName.NameUse.Official,
                Family = individual.NameParts.FirstOrDefault(c => c.NameTypeConceptId == familyNameConceptId)?.Value ?? string.Empty,
                Given = individual.NameParts.Where(c => c.NameTypeConceptId == givenNameConceptId).OrderBy(c => c.Order).Select(c => c.Value),
            });

            // Language            
            var patientLanguage  = persistentResource.Languages?.FirstOrDefault();

            if (patientLanguage != null ) {
                fhirPatient.Communication.Add(new Hl7.Fhir.Model.Patient.CommunicationComponent
                {
                    Language = {
                        Coding = new List<Hl7.Fhir.Model.Coding>
                        {
                            new Hl7.Fhir.Model.Coding { 
                                System = "http://hl7.org/fhir/us/core/ValueSet/simple-language",
                                Code = patientLanguage.LanguageConcept.Value
                            }
                        }
                        }
                });
            }

            return fhirPatient;
            }            
        }
    }
}
