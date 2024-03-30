namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class Identifier : IdentifiedData
    {
        public string System { get; set; }
        public string Value { get; set; }
    }
}

