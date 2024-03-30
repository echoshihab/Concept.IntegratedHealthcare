namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class Address : IdentifiedData
    {
        public Address()
        {
            this.Lines = new List<string>();    
        }
        public Guid AddressUseConceptId { get; set; }
        public List<string> Lines { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }

        public Concept AddressUseConcept { get; set; } = null!;
    }
}

