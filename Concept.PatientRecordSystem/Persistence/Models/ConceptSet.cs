namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class ConceptSet : IdentifiedData
    {
        public string Name { get; set; } = null!;
        public List<Concept> Concepts { get; set; } = [];
        public List<ConceptConceptSet> ConceptConceptSets { get; set; } = [];
    }

}
