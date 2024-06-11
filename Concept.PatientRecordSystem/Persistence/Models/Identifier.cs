namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class Identifier : IdentifiedData
    {
        public Guid PersonId { get; set; }
        public string? System { get; set; }
        public string Value { get; set; } = null!;
        public Person Person { get; set; } = null!;
    }
}

