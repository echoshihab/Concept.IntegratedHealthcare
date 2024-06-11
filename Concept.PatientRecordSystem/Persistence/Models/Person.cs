namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class Person
    {
        public Person()
        {
            this.Identifiers = new List<Identifier>();
            this.Addresses = new List<Address>();
            this.NameParts = new List<NamePart>();         
        }

        public ICollection<Identifier> Identifiers { get; set; }
        public ICollection<NamePart> NameParts { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public string PersonType   { get; set; } = null!;
    }
}
