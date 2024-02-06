using Concept.PatientRecordSystem.Models;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
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
            }
            catch (DeserializationFailedException e)
            {
                Console.WriteLine(e.Message);
            }


            return await System.Threading.Tasks.Task.FromResult<PatientDb>(new PatientDb{ ResourceType = "Patient"});
        }
    }
}
