using Concept.PatientRecordSystem.Exceptions;
using Concept.PatientRecordSystem.Persistence;
using Concept.PatientRecordSystem.Persistence.Models;
using Firely.Fhir.Packages;
using Firely.Fhir.Validation;
using Hl7.Fhir.Model;
using Hl7.Fhir.Specification.Source;
using Hl7.Fhir.Specification.Terminology;
using Hl7.Fhir.Utility;
using Microsoft.EntityFrameworkCore;

namespace Concept.PatientRecordSystem.Service
{
    public class PractionerResourceService : ResourcePersistenceServiceBase<Hl7.Fhir.Model.Practitioner>
    {
        public PractionerResourceService(ApplicationDbContext context): base(context)
        {
            
        }

        public async Task<Hl7.Fhir.Model.Practitioner> CreateAsync(Hl7.Fhir.Model.Practitioner practitioner)
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

                var result = validator.Validate(practitioner, ApplicationConstants.PractitionerUSCoreProfile);

                if (!result.Success)
                {
                    throw new InvalidResourceException("Invalid Resource");
                }

                var practitionerDb = new Persistence.Models.Practitioner();

                // add identifier                                    
                var validIdentifiers = practitioner.Identifier.Where(c => c.System == "http://hl7.org/fhir/sid/us-npi");

                if (!validIdentifiers.Any())
                {
                    throw new InvalidResourceException("Invalid Resource");
                }

                foreach (var identifier in validIdentifiers)
                {
                    practitionerDb.Identifiers.Add(new()
                    {
                        System = identifier.System,
                        Value = identifier.Value
                    });
                }

                var givenNameConceptId = (await base._context.Concepts.FirstOrDefaultAsync(c => c.Value == "Given"))?.Id ?? throw new NullReferenceException();
                var familyNameConceptId = (await base._context.Concepts.FirstOrDefaultAsync(c => c.Value == "Family"))?.Id ?? throw new NullReferenceException();

                var practitionerName = practitioner.Name.FirstOrDefault(c => c.Use == HumanName.NameUse.Official) ?? practitioner.Name.First();
                
                if (string.IsNullOrWhiteSpace(practitionerName.Family))
                {
                    throw new InvalidResourceException("Invalid resource");
                }
               
                practitionerDb.NameParts.Add(new NamePart()
                {
                    Value = practitionerName.Family,
                    Order = 0,
                    NameTypeConceptId = familyNameConceptId
                });
                
                if (practitionerName.Given.Any())
                {
                    var givenNames = practitionerName.Given.Select((c, i) => new NamePart()
                    {
                        Value = c,
                        Order = (short)i,
                        NameTypeConceptId = givenNameConceptId
                    });
                }

                var phoneConceptId = (await _context.Concepts.FirstOrDefaultAsync(c => c.Value == "phone"))?.Id ?? throw new NullReferenceException();
                var faxConceptId = (await _context.Concepts.FirstOrDefaultAsync(c => c.Value == "fax"))?.Id ?? throw new NullReferenceException();
                var emailConceptId = (await _context.Concepts.FirstOrDefaultAsync(c => c.Value == "email"))?.Id ?? throw new NullReferenceException();

                if (!practitioner.Telecom.IsNullOrEmpty())
                {
                    var phoneTelecom = practitioner.Telecom.Where(c => c.System == ContactPoint.ContactPointSystem.Phone);
                    // 1 is the highest rank https://hl7.org/fhir/R4/datatypes.html#ContactPoint
                    var selectedPhoneTelecom = phoneTelecom.FirstOrDefault(c => c.Rank == 1) ?? phoneTelecom.FirstOrDefault();

                    if (selectedPhoneTelecom != null)
                    {
                        var practitionerDbTelecomPhone = new PractitionerTelecom()
                        {
                            Value = selectedPhoneTelecom.Value,
                            ContactSystemConceptId = phoneConceptId
                        };

                        var phoneContactPointUseId = (await _context.Concepts.FirstOrDefaultAsync(c => c.Value == selectedPhoneTelecom.UseElement.Value.ToString()))?.Id;

                        if (phoneContactPointUseId != null)
                        {
                            practitionerDbTelecomPhone.ContactPointUseConceptId = phoneContactPointUseId;
                        }

                        practitionerDb.Telecoms.Add(practitionerDbTelecomPhone);
                    }

                    var emailTelecom = practitioner.Telecom.Where(c => c.System == ContactPoint.ContactPointSystem.Email);
                    var selectedEmailTelecom = emailTelecom.FirstOrDefault(c => c.Rank == 1) ?? emailTelecom.FirstOrDefault();

                    if (selectedEmailTelecom != null)
                    {
                        var practitionerDbTelecomEmail = new PractitionerTelecom()
                        {
                            Value = selectedEmailTelecom.Value,
                            ContactSystemConceptId = emailConceptId
                        };

                        var emailContactPointUseId = (await _context.Concepts.FirstOrDefaultAsync(c => c.Value == selectedEmailTelecom.UseElement.Value.ToString()))?.Id;

                        if (emailContactPointUseId != null)
                        {
                            practitionerDbTelecomEmail.ContactSystemConceptId = (Guid)emailContactPointUseId;
                        }

                        practitionerDb.Telecoms.Add(practitionerDbTelecomEmail);
                    }
                }

                // add address
                if (practitioner.Address.Count > 0)
                {
                    foreach (var address in practitioner.Address)
                    {
                        var PractitionerDbAddress = new Persistence.Models.Address();

                        if (address.Line.Any())
                        {
                            PractitionerDbAddress.Lines = address.Line.ToList();
                        }

                        if (address.City != null)
                        {
                            PractitionerDbAddress.City = address.City;
                        }

                        if (address.State != null)
                        {
                            PractitionerDbAddress.State = address.State;
                        }

                        if (address.UseElement != null)
                        {
                            var addressUseConceptId = (await _context.Concepts.FirstOrDefaultAsync(c => c.Value == address.UseElement.Value.ToString()))?.Id;

                            if (addressUseConceptId != null)
                            {
                                PractitionerDbAddress.AddressUseConceptId = (Guid)addressUseConceptId;
                            }
                        }

                        if (address.PostalCode != null)
                        {
                            PractitionerDbAddress.PostalCode = address.PostalCode;
                        }

                        if (address.Country != null)
                        {
                            PractitionerDbAddress.Country = address.Country;
                        }

                        //_context.Practitioners.Add(practitionerDb);

                        //await _context.SaveChangesAsync();

                        return practitioner;

                    }
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
