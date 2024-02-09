namespace Concept.PatientRecordSystem.Models
{

    public class Rootobject
    {
        public string resourceType { get; set; }
        public string id { get; set; }
        public Identifier[] identifier { get; set; }
        public NamePart[] name { get; set; }
        public Telecom[] telecom { get; set; }
        public string gender { get; set; }
        public string birthDate { get; set; }
        public Address[] address { get; set; }
    }
}

