namespace Proto.PatientRecordSystem.Persistence.Models
{
    public class PatientPractitioner : IdentifiedData
    {
        public Guid PatientId { get; set; }
        public Patient Patient { get;set; } = null!;
        public Guid PractitionerReferenceId { get; set; }       
        public Guid PractitionerReferenceTypeConceptId { get; set; }
        public Concept PractitionerReferenceTypeConcept { get; set; } = null!;
    }
}
