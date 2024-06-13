namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class Individual : IdentifiedData
    {
        public Individual()
        {
            this.Identifiers = [];
            this.Addresses = [];
            this.NameParts = [];
        }

        public Guid IndividualTypeConceptId { get; set; }
        public List<Identifier> Identifiers { get; set; }
        public List<NamePart> NameParts { get; set; }
        public List<Address> Addresses { get; set; }        
        public Concept IndividualTypeConcept { get; set; } = null!;
    }
}
