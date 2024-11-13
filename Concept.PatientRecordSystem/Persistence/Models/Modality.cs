using Hl7.Fhir.ElementModel.Types;

namespace Proto.PatientRecordSystem.Persistence.Models
{
    public class Modality : IdentifiedData
    {
        public string Code { get; set; } = null!;
        public string Display { get; set; } = null!;
        public bool Active { get; set;}
    }
}
