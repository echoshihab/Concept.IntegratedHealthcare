namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class Identifier : IdentifiedData
    {
        public Guid PatientId { get; set; }
        public string? System { get; set; }
        public string Value { get; set; } = null!;
        public Patient Patient { get; set; } = null!;
    }
}

