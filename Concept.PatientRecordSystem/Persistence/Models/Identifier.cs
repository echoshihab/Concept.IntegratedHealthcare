namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class Identifier : IdentifiedData
    {        
        public string? System { get; set; }
        public string Value { get; set; } = null!;
        public Guid IndividualId { get; set; }
        public Individual Individual { get; set; } = null!;
    }
}

