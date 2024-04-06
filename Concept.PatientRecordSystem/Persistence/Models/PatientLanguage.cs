namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class PatientLanguage : IdentifiedData
    {
        public PatientLanguage()
        {
            this.Patients = new HashSet<Patient>();
        }
        public Guid LanguageConceptId { get; set; }
        public Guid PatientId { get; set; }
        public Concept LanguageConcept { get;set;} = null!;
        public ICollection<Patient> Patients { get; set; }
    }
}
