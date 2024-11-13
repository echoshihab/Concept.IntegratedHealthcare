namespace Proto.PatientRecordSystem.Persistence.Models
{
    public class ConceptConceptSet : IdentifiedData
    {
        public Guid ConceptId { get; set; }
        public Guid ConceptSetId { get; set; }
        public Concept Concept { get; set; } = null!;
        public ConceptSet ConceptSet { get; set; } = null!;
    }
}
