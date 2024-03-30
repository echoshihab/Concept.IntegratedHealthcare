namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class PatientLanguage : IdentifiedData
    {
        public Guid LanguageConceptId { get; set; }
        public Guid PatientId { get; set; }
        public Concept LanguageConcept { get;set;} = null!;
    }
}
