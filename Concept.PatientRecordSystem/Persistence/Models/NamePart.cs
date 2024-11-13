namespace Proto.PatientRecordSystem.Persistence.Models
{
    public class NamePart : IdentifiedData
    {
        public string? Value { get; set; }
        public short Order { get; set; }
        public Guid NameTypeConceptId { get; set; }
        public Guid IndividualId { get; set; }
        public Individual Individual { get; set; } = null!;
    }
}

