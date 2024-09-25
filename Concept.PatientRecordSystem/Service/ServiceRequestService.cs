using Concept.PatientRecordSystem.Exceptions;
using Concept.PatientRecordSystem.Persistence;
using Concept.PatientRecordSystem.Persistence.Models;
using Firely.Fhir.Packages;
using Firely.Fhir.Validation;
using Hl7.Fhir.Model;
using Hl7.Fhir.Specification.Source;
using Hl7.Fhir.Specification.Terminology;
using Microsoft.EntityFrameworkCore;

namespace Concept.PatientRecordSystem.Service
{
    public class ServiceRequestService : ResourcePersistenceServiceBase<Hl7.Fhir.Model.ServiceRequest>
    {
        public ServiceRequestService(ApplicationDbContext context): base(context)
        {
            
        }

        public override async Task<Hl7.Fhir.Model.ServiceRequest> CreateAsync(Hl7.Fhir.Model.ServiceRequest serviceRequest)
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

            var result = validator.Validate(serviceRequest, ApplicationConstants.ServiceRequestUSCoreProfile);

            if (!result.Success)
            {
                throw new InvalidResourceException("Invalid Resource");
            }

            var serviceRequestdb = new Persistence.Models.ServiceRequest();

            // TODO: Need to handle fhir dateTime correctly 
            // https://hl7.org/fhir/R4/datatypes.html#dateTime

            if (serviceRequest.Occurrence is Period occurencePeriod)
            {
                if (!string.IsNullOrEmpty(occurencePeriod.Start))
                {
                    serviceRequestdb.Start = DateTime.TryParse(occurencePeriod.Start, out var start) ? start : null;
                }

                if (!string.IsNullOrEmpty(occurencePeriod.End))
                {
                    serviceRequestdb.End = DateTime.TryParse(occurencePeriod.End, out var end) ? end : null;
                }
            }

            if (serviceRequest.AuthoredOn != null)
            {
                serviceRequestdb.RequestSignedDate = DateTime.TryParse(serviceRequest.AuthoredOn, out var signedDate) ? signedDate : null;
            }

            if (serviceRequest.Requester?.Reference != null)
            {
                var reference = serviceRequest.Requester.Reference;

                if (reference.StartsWith("Practitioner/"))
                {
                    //get practitioner reference type concept id
                    var practitionerReferenceTypeId = (await _context.Concepts.FirstOrDefaultAsync(c => c.Code == "practitioner"))?.Id ?? throw new NullReferenceException();

                    _ = Guid.TryParse(reference.Split('/')[1], out var practitionerId);

                    var practitioner = await _context.Practitioners.FindAsync(practitionerId);

                    if (practitioner != null)
                    {
                        serviceRequestdb.Requester = new PatientPractitioner()
                            {
                                PractitionerReferenceTypeConceptId = practitionerReferenceTypeId,
                                PractitionerReferenceId = practitioner.Id
                            };
                    }
                }


                //TODO : add service request logic
            return base.CreateAsync(fhirResource);
        }
    }
}
