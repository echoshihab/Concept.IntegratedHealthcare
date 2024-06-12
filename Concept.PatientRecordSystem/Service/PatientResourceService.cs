using Concept.PatientRecordSystem.Exceptions;
using Concept.PatientRecordSystem.Persistence;
using Concept.PatientRecordSystem.Persistence.Models;
using Firely.Fhir.Packages;
using Firely.Fhir.Validation;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Specification.Source;
using Hl7.Fhir.Specification.Terminology;
using Hl7.Fhir.Utility;
using Microsoft.EntityFrameworkCore;

namespace Concept.PatientRecordSystem.Service
{
    public class PatientResourceService : ResourcePersistenceServiceBase<Hl7.Fhir.Model.Patient>
    {
        public PatientResourceService(ApplicationDbContext context): base(context)
        {
            
        }

        public override async Task<Hl7.Fhir.Model.Patient> CreateAsync(Hl7.Fhir.Model.Patient patient)
        {            
            try
            {               
                var resolver = new FhirPackageSource(ModelInfo.ModelInspector, "https://packages.simplifier.net",
                     new[] { "hl7.fhir.r4.core" }
               );

                var directoryResolver = new DirectorySource("Profiles", new DirectorySourceSettings
                {
                    IncludeSubDirectories = true
                });

                // ensure we can validate against both core and profiles in directory
                var resourceResolver = new CachedResolver(new MultiResolver(resolver, directoryResolver));

                var terminologyServices = new LocalTerminologyService(resourceResolver);

                var validator = new Validator(resourceResolver, terminologyServices);

                var result = validator.Validate(patient, ApplicationConstants.PatientUSCoreProfile);

                if (!result.Success)
                {
                    throw new InvalidResourceException("Invalid Resource");
                }

                var patientDb = new Persistence.Models.Patient();
               

                // add birthdate
                var birthDateArray = patient.BirthDate.Split('-');

                patientDb.BirthYear = ushort.Parse(birthDateArray[0]);

                if (birthDateArray.Length > 0)
                {
                    patientDb.BirthMonth = ushort.Parse(birthDateArray[1]);
                } 

                if (birthDateArray.Length > 1)
                {
                    patientDb.BirthDay = ushort.Parse(birthDateArray[2]);
                }

                // add gender
                var genderConcept = await _context.Concepts.FirstOrDefaultAsync(c => c.Value == patient.Gender.ToString()) ?? throw new InvalidResourceException("Invalid resource");

                patientDb.GenderConcept = genderConcept;
                    
                // add identifier                    
                foreach(var identifier in patient.Identifier)
                {
                    patientDb.Individual.Identifiers.Add(new()
                    {
                        System = identifier.System,
                        Value = identifier.Value
                    });                      
                }            
                    
                // add name                   
                var givenNameConceptId = (await _context.Concepts.FirstOrDefaultAsync(c => c.Value == "Given"))?.Id ?? throw new NullReferenceException();
                var familyNameConceptId = (await _context.Concepts.FirstOrDefaultAsync(c => c.Value == "Family"))?.Id ?? throw new NullReferenceException();

      
                var patientName = patient.Name.FirstOrDefault(c => c.Use == HumanName.NameUse.Official) ?? patient.Name.First();
                
                if (!string.IsNullOrWhiteSpace(patientName.Family))
                {
                    patientDb.Individual.NameParts.Add(new NamePart()
                    {
                        Value = patientName.Family,
                        Order = 0,
                        NameTypeConceptId = familyNameConceptId
                    });
                }
                   
                if (patientName.Given.Any())
                {
                    var givenNames = patientName.Given.Select((c, i) => new NamePart()
                    {
                        Value = c,
                        Order = (short)i,
                        NameTypeConceptId = givenNameConceptId
                    });
                }

                // add language
                if (patient.Communication.Count > 0)
                {
                    var selectedCommunication = patient.Communication.FirstOrDefault(c => c.Preferred is true) ?? patient.Communication.First();
                    var languageCoding = selectedCommunication.Language.Coding.First(c => c.System == "http://hl7.org/fhir/us/core/ValueSet/simple-language")?.Code;

                    var languageConceptId = (await _context.Concepts.FirstOrDefaultAsync(c => c.Value == languageCoding))?.Id;

                    if (languageConceptId != null)
                    {
                        patientDb.Languages.Add(new()
                        {
                            LanguageConceptId = (Guid)languageConceptId
                        });
                    }
                }                 
                    
                var phoneConceptId = (await _context.Concepts.FirstOrDefaultAsync(c => c.Value == "phone"))?.Id ?? throw new NullReferenceException();
                var emailConceptId = (await _context.Concepts.FirstOrDefaultAsync(c => c.Value == "email"))?.Id ?? throw new NullReferenceException();
                    
                if (!patient.Telecom.IsNullOrEmpty())
                {
                    var phoneTelecom = patient.Telecom.Where(c => c.System == ContactPoint.ContactPointSystem.Phone);
                    // 1 is the highest rank https://hl7.org/fhir/R4/datatypes.html#ContactPoint
                    var selectedPhoneTelecom = phoneTelecom.FirstOrDefault(c => c.Rank == 1) ?? phoneTelecom.FirstOrDefault();                        

                    if (selectedPhoneTelecom != null)
                    {                                                                                    
                        var patientDbTelecomPhone = new PatientTelecom()
                        {
                            Value = selectedPhoneTelecom.Value,
                            ContactSystemConceptId = phoneConceptId
                        };

                        var phoneContactPointUseId = (await _context.Concepts.FirstOrDefaultAsync(c => c.Value == selectedPhoneTelecom.UseElement.Value.ToString()))?.Id;

                        if (phoneContactPointUseId != null)
                        {
                            patientDbTelecomPhone.ContactPointUseConceptId = phoneContactPointUseId;
                        }          
                            
                        patientDb.Telecoms.Add(patientDbTelecomPhone);
                    }

                    var emailTelecom = patient.Telecom.Where(c => c.System == ContactPoint.ContactPointSystem.Email);
                    var selectedEmailTelecom = emailTelecom.FirstOrDefault(c => c.Rank == 1) ?? emailTelecom.FirstOrDefault();

                    if (selectedEmailTelecom != null)
                    {
                        var patientDbTelecomEmail = new PatientTelecom()
                        {
                            Value = selectedEmailTelecom.Value,
                            ContactSystemConceptId = emailConceptId
                        };

                        var emailContactPointUseId = (await _context.Concepts.FirstOrDefaultAsync(c => c.Value == selectedEmailTelecom.UseElement.Value.ToString()))?.Id;

                        if (emailContactPointUseId != null)
                        {
                            patientDbTelecomEmail.ContactSystemConceptId = (Guid)emailContactPointUseId;
                        }

                        patientDb.Telecoms.Add(patientDbTelecomEmail);
                    }
                }

                // add address
                if (patient.Address.Count > 0)
                {
                    foreach (var address in patient.Address)
                    {
                        var patientDbAddress = new Persistence.Models.Address();

                        if (address.Line.Any())
                        {
                            patientDbAddress.Lines = address.Line.ToList();
                        }

                        if (address.City != null)
                        {
                            patientDbAddress.City = address.City;
                        }

                        if (address.State != null)
                        {
                            patientDbAddress.State = address.State;
                        }

                        if (address.UseElement != null)
                        {
                            var addressUseConceptId = (await _context.Concepts.FirstOrDefaultAsync(c => c.Value == address.UseElement.Value.ToString()))?.Id;
                                    
                            if (addressUseConceptId != null)
                            {
                                patientDbAddress.AddressUseConceptId = (Guid)addressUseConceptId;
                            }                                    
                        }

                        if (address.PostalCode != null)
                        {
                            patientDbAddress.PostalCode = address.PostalCode;
                        }

                        if (address.Country != null)
                        {
                            patientDbAddress.Country = address.Country;
                        }

                        patientDb.Individual.Addresses.Add(patientDbAddress);
                    }

                }

                    // add gender
                var genderConceptId = (await _context.Concepts.FirstOrDefaultAsync(c => c.Value == patient.GenderElement.Value.ToString()))?.Id ?? throw new InvalidResourceException("Invalid resource");

                patientDb.GenderConceptId = genderConceptId;

                _context.Patients.Add(patientDb);

                await _context.SaveChangesAsync();        
                    
                return patient;                
            }
            catch (DeserializationFailedException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
