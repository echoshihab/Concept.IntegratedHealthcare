namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class Practitioner
    {
        public Practitioner()
        {
            Identifiers = [];
            NameParts = [];
            Addresses = [];
            Telecoms = [];
        }
        public List<Identifier> Identifiers { get; set; }
        public List<NamePart> NameParts { get; set; }
        public List<Address> Addresses { get; set; }        
        public List<PractitionerTelecom> Telecoms { get; set; }
    }
}
