namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class PatientTelecom : IdentifiedData
    {
        public Guid ContactSystemConceptId { get; set; }
        public Guid ContactPointUseConceptId { get; set; }
        public Guid PatientId { get; set; }
        public string? Value { get; set; }
        public Concept ContactSystemConcept { get; set; } = null!;
        public Concept ContactPointUseConcept { get; set; } = null!;
    }
}
