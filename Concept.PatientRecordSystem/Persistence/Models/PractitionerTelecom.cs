namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class PractitionerTelecom : IdentifiedData
    {        
        public Guid ContactSystemConceptId { get; set; }
        public Guid? ContactPointUseConceptId { get; set; }
        public Guid PractitionerId { get; set; }
        public string Value { get; set; } = null!;
        public Concept ContactSystemConcept { get; set; } = null!;
        public Concept? ContactPointUseConcept { get; set; }
        public Practitioner Practitioner { get; set; } = null!;       
    }
}
