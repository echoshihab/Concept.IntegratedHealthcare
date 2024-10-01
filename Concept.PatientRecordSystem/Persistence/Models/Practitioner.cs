namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class Practitioner : IdentifiedData
    {
        public Practitioner()
        {
            this.Telecoms = new List<PractitionerTelecom>();
        }

        public Guid IndividualId { get; set; }
        public Individual Individual { get; set; } = null!;        
        public List<PractitionerTelecom> Telecoms { get; set; }        
    }
}
