using Proto.PatientRecordSystem.Enums;

namespace Proto.PatientRecordSystem.DTOs
{
    public class PatientDto : IdentifiableData
    {
        public string? Mrn { get; set; }        
        public string? Gender { get; set; }
        public ushort BirthYear { get; set; }
        public ushort BirthMonth { get; set; }
        public ushort BirthDay { get; set; }
        public required Name Name { get; set; }
        public List<ContactPhone> PhoneNumbers { get;set;} = new List<ContactPhone>();
        public string? Email {get;set;}
        public Language? Language { get; set; } 
    }
}
