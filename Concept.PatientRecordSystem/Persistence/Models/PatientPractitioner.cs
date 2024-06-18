namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class PatientPractitioner : IdentifiedData
    {
        public Guid PatientId { get; set; }
        public Patient Patient { get;set; } = null!;
        public Guid PractitionerReferenceId { get; set; }       
        public Guid PractitionerTypeConceptId { get; set; }
        public Concept PractitionerTypeConcept { get; set; } = null!;
    }
}
