using Concept.PatientRecordSystem.Models;

namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class Patient : Resource
    {
        public Guid Id { get; set; }
        public string Mrn { get; set; }
        public List<NamePart> NameParts { get; set; }
        public Guid Gender { get; set; }
        public string BirthDate { get; set; }

        public List<Address> Address;
    }
}
