namespace Proto.PatientRecordSystem.Persistence.Models
{
    public class PatientTelecom : IdentifiedData
    {
        public Guid ContactSystemConceptId { get; set; }
        public Guid? ContactPointUseConceptId { get; set; }
        public Guid PatientId { get; set; }
        public string Value { get; set; } = null!;
        public Concept ContactSystemConcept { get; set; } = null!;
        public Concept? ContactPointUseConcept { get; set; } 
        public Patient Patient { get;set;} = null!;
    }
}
