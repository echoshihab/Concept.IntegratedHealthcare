namespace Proto.PatientRecordSystem.Persistence.Models
{
    public class Address : IdentifiedData
    {
        public Address()
        {
            this.Lines = [];
        }

        public Guid IndividualId { get; set; }
        public Individual Individual { get; set; } = null!;
        public Guid? AddressUseConceptId { get; set; }
        public List<string> Lines { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public Concept? AddressUseConcept { get; set; }       
    }
}

