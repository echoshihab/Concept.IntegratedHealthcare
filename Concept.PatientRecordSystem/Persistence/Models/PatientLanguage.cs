namespace Proto.PatientRecordSystem.Persistence.Models
{
    public class PatientLanguage : IdentifiedData
    {
        public Guid LanguageConceptId { get; set; }
        public Concept LanguageConcept { get;set;} = null!;
        public Guid PatientId { get;set;}
        public Patient Patient { get;set;} = null!;
    }
}
