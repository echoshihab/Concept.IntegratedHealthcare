using Concept.PatientRecordSystem.Exceptions;
using Concept.PatientRecordSystem.Persistence;
using Concept.PatientRecordSystem.Persistence.Models;
using Firely.Fhir.Packages;
using Firely.Fhir.Validation;
using Hl7.Fhir.Model;
using Hl7.Fhir.Specification.Source;
using Hl7.Fhir.Specification.Terminology;

namespace Concept.PatientRecordSystem.Service
{
    public class ServiceRequestService : ResourcePersistenceServiceBase<Hl7.Fhir.Model.ServiceRequest>
    {
        public ServiceRequestService(ApplicationDbContext context): base(context)
        {
            
        }

        public override Task<Hl7.Fhir.Model.ServiceRequest> CreateAsync(Hl7.Fhir.Model.ServiceRequest serviceRequest)
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

            if (serviceRequest.Occurrence is Period occurencePeriod)
            {

                if (!string.IsNullOrEmpty(occurencePeriod.Start))
                {
                    serviceRequestdb.Start = DateTime.TryParse(occurencePeriod.Start, out DateTime start) ? start : null;
                }

                if (!string.IsNullOrEmpty(occurencePeriod.End))
                {
                    serviceRequestdb.End = DateTime.TryParse(occurencePeriod.End, out DateTime end) ? end : null;
                }

            }


            //TODO : add service request logic
            return base.CreateAsync(fhirResource);
        }
    }
}
