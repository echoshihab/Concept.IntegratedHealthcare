namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class Individual : IdentifiedData
    {
        public Individual()
        {
            this.Identifiers = new List<Identifier>();
            this.Addresses = new List<Address>();
            this.NameParts = new List<NamePart>();         
        }

        public Guid IndividualTypeConceptId { get; set; }
        public ICollection<Identifier> Identifiers { get; set; }
        public ICollection<NamePart> NameParts { get; set; }
        public ICollection<Address> Addresses { get; set; }        
        public Concept IndividualTypeConcept { get; set; } = null!;
    }
}
