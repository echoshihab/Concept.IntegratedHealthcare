
using Proto.PatientRecordSystem.Persistence.Models;
using Proto.PatientRecordSystem.Service.Mapping.Interfaces;

namespace Proto.PatientRecordSystem.Service.Mapping
{
    public class PatientFhirMappingService : IFhirMappingService<Patient, Hl7.Fhir.Model.Patient>
    {
        private readonly IConceptService _conceptService;

        public PatientFhirMappingService(IConceptService conceptService)
        {
            _conceptService = conceptService;
        }
        public async Task<Hl7.Fhir.Model.Patient> MapToFhirResourceAsync(Patient persistentResource)
        {
            var fhirPatient = new Hl7.Fhir.Model.Patient();

            // Birthdate
            fhirPatient.BirthDate = string.Join("-", persistentResource.BirthYear, persistentResource.BirthMonth, persistentResource.BirthDay);

            // Gender
            fhirPatient.Gender = Enum.TryParse<Hl7.Fhir.Model.AdministrativeGender>(persistentResource.GenderConcept.Value, true, out Hl7.Fhir.Model.AdministrativeGender gender) ? gender : Hl7.Fhir.Model.AdministrativeGender.Unknown;

            var individual = persistentResource?.Individual ?? throw new NullReferenceException();

            // Identifiers
            foreach (var identifier in individual.Identifiers)
            {
                fhirPatient.Identifier.Add(new Hl7.Fhir.Model.Identifier
                {
                    System = identifier.System,
                    Value = identifier.Value,
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

            // Language - take the first language for now           
            var patientLanguage = persistentResource.Languages?.FirstOrDefault();

            if (patientLanguage != null)
            {
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

            // Telecom
            var phoneConceptId = (await _conceptService.RetreiveConceptAsync("phone"))?.Id ?? throw new NullReferenceException();

            var emailConceptId = (await _conceptService.RetreiveConceptAsync("email"))?.Id ?? throw new NullReferenceException();

            var phoneContactPoint = persistentResource.Telecoms.FirstOrDefault(c => c.ContactSystemConcept.Id == phoneConceptId);

            if (phoneContactPoint != null)
            {
                var phoneContactPointUseConcept = (await _conceptService.RetreiveConceptByIdAsync(phoneContactPoint.ContactPointUseConceptId))?.Value ?? throw new NullReferenceException();

                if (Enum.TryParse<Hl7.Fhir.Model.ContactPoint.ContactPointUse>(phoneContactPointUseConcept, out var phoneContactPointUse))
                {
                    fhirPatient.Telecom.Add(new Hl7.Fhir.Model.ContactPoint
                    {
                        System = Hl7.Fhir.Model.ContactPoint.ContactPointSystem.Phone,
                        Value = phoneContactPoint.Value,
                        UseElement =
                    {
                        Value = phoneContactPointUse
                    }
                    });
                }
            }
            var emailContactPoint = persistentResource.Telecoms.FirstOrDefault(c => c.ContactPointUseConcept.Id == emailConceptId);

            if (emailContactPoint != null)
            {
                var emailContactPointUseConcept = (await _conceptService.RetreiveConceptByIdAsync(emailContactPoint.ContactPointUseConceptId))?.Value ?? throw new NullReferenceException();

                if (Enum.TryParse<Hl7.Fhir.Model.ContactPoint.ContactPointUse>(emailContactPointUseConcept, out var emailContactPointUse))
                {
                    fhirPatient.Telecom.Add(new Hl7.Fhir.Model.ContactPoint
                    {
                        System = Hl7.Fhir.Model.ContactPoint.ContactPointSystem.Email,
                        Value = emailContactPoint.Value,
                        UseElement =
                            {
                                Value = emailContactPointUse
                            }
                    });
                }
            }

            // address
            if (individual.Addresses.Count > 0)
            {
                var fhirAddress = new Hl7.Fhir.Model.Address();

                foreach (var address in individual.Addresses)
                {
                    if (address.Lines.Count > 0)
                    {
                        fhirAddress.Line = address.Lines;
                    }

                    if (address.City != null)
                    {
                        fhirAddress.City = address.City;
                    }

                    if (address.State != null)
                    {
                        fhirAddress.State = address.State;
                    }

                    if (address.AddressUseConcept != null && Enum.TryParse<Hl7.Fhir.Model.Address.AddressUse>(address.AddressUseConcept.Value, out var result))
                    {
                        fhirAddress.Use = result;
                    }
                }

                if (persistentResource.PatientPractitioners.Count > 0)
                {
                    foreach (var practitioner in persistentResource.PatientPractitioners)
                    {
                        fhirPatient.GeneralPractitioner.Add(
                            new Hl7.Fhir.Model.ResourceReference
                            {
                                Reference = $"Practitioner/{practitioner.Id}"
                            });
                    }

                    //TODO take care of other practitioners
                }
            }

            return fhirPatient;
        }
    }
}

