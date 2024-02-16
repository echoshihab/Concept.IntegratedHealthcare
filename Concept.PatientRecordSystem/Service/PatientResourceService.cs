using Concept.PatientRecordSystem.Exceptions;
using Concept.PatientRecordSystem.Persistence.Models;
using Firely.Fhir.Packages;
using Firely.Fhir.Validation;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Specification.Source;
using Hl7.Fhir.Specification.Terminology;
using System.Text.Json;

namespace Concept.PatientRecordSystem.Service
{
    public class PatientResourceService : IResourceService<Models.Resource>
    {
        public async Task<Models.Resource> CreateAsync(JsonDocument fhirResource)
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
                    return new Persistence.Models.Patient();
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
