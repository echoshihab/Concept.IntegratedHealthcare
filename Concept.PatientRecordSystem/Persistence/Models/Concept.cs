namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class Concept : IdentifiedData
    {      
        public string? Value { get; set; }
        public List<ConceptSet> ConceptSets { get; set; } = [];
        public List<ConceptConceptSet> ConceptConceptSets { get; set; } = [];
        public string? Code { get; set; }
        public string? Display { get; set; }
    }
}
