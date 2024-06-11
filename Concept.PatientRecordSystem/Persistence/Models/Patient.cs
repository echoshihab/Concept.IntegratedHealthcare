namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class Patient : IdentifiedData
    {
        public Patient()
        {
            this.Identifiers = new HashSet<Identifier>();
            this.Addresses = new HashSet<Address>();
            this.NameParts = new HashSet<NamePart>();
            this.Languages = new HashSet<PatientLanguage>();
            this.Telecoms = new HashSet<PatientTelecom>();
        }

        public Guid GenderConceptId { get; set; }
        public ushort BirthYear { get; set; }
        public ushort BirthMonth { get; set; }
        public ushort BirthDay { get; set; }

        public ICollection<Identifier> Identifiers { get; set; }
        public ICollection<NamePart> NameParts { get; set; }
        public ICollection<Address> Addresses { get;set;}
        public ICollection<PatientLanguage> Languages { get; set; }
        public ICollection<PatientTelecom> Telecoms { get; set; }

        public Concept GenderConcept { get;set;}
    }
}
