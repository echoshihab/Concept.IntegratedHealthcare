using Concept.PatientRecordSystem.Models;

namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class PatientDb : Resource
    {
        public Guid Id { get; set; }
        public string Mrn { get; set; }
        public List<NamePart> NameParts { get; set; }

    }
}
