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

            var givenNameConceptId = (await this._conceptService.RetreiveConceptAsync(ApplicationConstants.NameTypeGiven))?.Id ?? throw new NullReferenceException();
            var familyNameConceptId = (await this._conceptService.RetreiveConceptAsync(ApplicationConstants.NameTypeFamily))?.Id ?? throw new NullReferenceException();


            fhirPatient.Name.Add(new Hl7.Fhir.Model.HumanName
            {
                Use = Hl7.Fhir.Model.HumanName.NameUse.Official,
                Family = individual.NameParts.FirstOrDefault(c => c.NameTypeConceptId == familyNameConceptId)?.Value ?? string.Empty
                // TODO : Finish mapping given 
            });

            return fhirPatient;
            }
            

        }
    }
}
