﻿using Concept.PatientRecordSystem.Exceptions;
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
using System.Text.Json;

namespace Concept.PatientRecordSystem.Service
{
    public class PatientResourceService : IResourceService<Persistence.Models.IdentifiedData>
    {
        private readonly ApplicationDbContext _context;

        public PatientResourceService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Persistence.Models.IdentifiedData> CreateAsync(JsonDocument fhirResource)
        {
            var options = new JsonSerializerOptions().ForFhir(ModelInfo.ModelInspector);

            try
            {
                var patient = JsonSerializer.Deserialize<Hl7.Fhir.Model.Patient>(fhirResource, options) ?? throw new ArgumentNullException();

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

                if (result.Success)
                {
                    // map first
                    // then context save changes all resources in same class - this means this class
                    // worry about other stuff later 
                    var patientDb = new Persistence.Models.Patient();

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

                    // retrieve matching gender concept
                    var genderConcept = await _context.Concepts.FirstOrDefaultAsync(c => c.Value == patient.Gender.ToString()) ?? throw new InvalidResourceException("Invalid resource");

                    patientDb.GenderConcept = genderConcept;
                    
                    // add identifier 
                    // TODO: change identifiers from ICollection<> to List<> to have access to add range. 
                    foreach(var identifier in patient.Identifier)
                    {
                        patientDb.Identifiers.Add(new()
                        {
                            System = identifier.System,
                            Value = identifier.Value
                        });                      
                    }

                    // add name
                    var nameTypes = await _context.ConceptSets.Where(c => c.Name == "NameType").Include(cs => cs.Concepts)
                        .SelectMany(c => c.Concepts).ToListAsync();
                    
                    var givenNameConceptId = nameTypes.FirstOrDefault(c => c.Value == "Given")?.Id ?? throw new NullReferenceException();
                    var familyNameConceptId = nameTypes.FirstOrDefault(c => c.Value == "Family")?.Id ?? throw new NullReferenceException();

                    // TODO: assess if this is US core compliant
                    var patientName = patient.Name.FirstOrDefault(c => c.Use == HumanName.NameUse.Official) ?? patient.Name.First();
                
                    if (!string.IsNullOrWhiteSpace(patientName.Family))
                    {
                        patientDb.NameParts.Add(new NamePart()
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

                        var languageConcept = await _context.Concepts.FirstOrDefaultAsync(c => c.Value == selectedCommunication.Language.Coding.First(c => c.System == "http://hl7.org/fhir/us/core/ValueSet/simple-language").Code);

                        if (languageConcept != null)
                        {
                            patientDb.Languages.Add(new()
                            {
                                LanguageConceptId = familyNameConceptId
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
                        
                        var emailTelecom = patient.Telecom.Where(c => c.System == ContactPoint.ContactPointSystem.Email);
                        var selectedEmailTelecom = emailTelecom.FirstOrDefault(c => c.Rank == 1) ?? emailTelecom.FirstOrDefault();

                        if (selectedPhoneTelecom != null)
                        {
                            
                            var phoneContactPointUse = _context.Concepts.FirstOrDefault(c => c.Value == selectedPhoneTelecom.UseElement.Value.ToString())?.Id;
                            
                            patientDb.Telecoms.Add(new()
                            {
                                ContactSystemConceptId = phoneConceptId,                                
                                Value = selectedPhoneTelecom.Value
                            });

                            // need to make contact point use nullable.
                        }

                    }

                    // add email


                    if (selectedTelecoms.Any())
                    {

                    }

                        
                    

                    


                      
                }

                throw new InvalidResourceException("Invalid resource");
            }
            catch (DeserializationFailedException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
