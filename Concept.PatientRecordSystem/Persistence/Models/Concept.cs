namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class Concept : IdentifiedData
    {
        public Concept()
        {
            this.ConceptSets = new List<ConceptSet>();
        }
        public string? Value { get; set; }
        public List<ConceptSet> ConceptSets { get; set; }
        public string? Code { get; set; }
        public string? Display { get; set; }
    }
}
