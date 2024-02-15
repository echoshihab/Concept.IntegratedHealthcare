namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class Address
    {
        public Guid Use { get; set; }
        public List<string> Line { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}

