using Concept.PatientRecordSystem.Models;
using Firely.Fhir.Packages;
using Firely.Fhir.Validation;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Specification;
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
                var patient = JsonSerializer.Deserialize<Patient>(fhirResource, options) ?? throw new ArgumentNullException();


                var profileUrl = "https://www.hl7.org/fhir/us/core/";

                var fhirRelease = FhirRelease.R4;             
              
                var packageResolver = FhirPackageSource.CreateCorePackageSource(ModelInfo.ModelInspector, fhirRelease, profileUrl);
                
                var resourceResolver = new CachedResolver(packageResolver);

                var terminologyService = new LocalTerminologyService(resourceResolver);

                var validator = new Validator(resourceResolver, terminologyService);

                var result = validator.Validate(patient);

                if (result.Success)
                {
                    return new PatientDb();
                }


            }
            catch (DeserializationFailedException e)
            {
                Console.WriteLine(e.Message);
            }


            return await System.Threading.Tasks.Task.FromResult<PatientDb>(new PatientDb{ ResourceType = "Patient"});
        }
    }
}
