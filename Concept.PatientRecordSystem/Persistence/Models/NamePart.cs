namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class NamePart : IdentifiedData
    {
        public string? Value { get; set; }
        public short Order { get; set; }
        public Guid NameTypeConceptId { get; set; }
        public Guid PatientId { get; set; }

        public Patient Patient { get; set; } = null!;
    }
}

