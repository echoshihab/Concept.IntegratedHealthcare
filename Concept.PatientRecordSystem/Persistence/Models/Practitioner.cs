namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class Practitioner : IdentifiedData
    {
        public Practitioner()
        {
            Addresses = [];
            Telecoms = [];
        }

        public Guid IndividualId { get; set; }
        public Individual Individual { get; set; } = null!;
        public List<Address> Addresses { get; set; }        
        public List<PractitionerTelecom> Telecoms { get; set; }        
    }
}
