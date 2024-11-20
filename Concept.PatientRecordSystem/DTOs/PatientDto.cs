using Proto.PatientRecordSystem.Enums;
using System.ComponentModel.DataAnnotations;

namespace Proto.PatientRecordSystem.DTOs
{
    public class PatientDto : IdentifiableData
    {
        public required string Mrn { get; set; }        
        public required Gender Gender { get; set; }
        public ushort BirthYear { get; set; }
        public ushort BirthMonth { get; set; }
        public ushort BirthDay { get; set; }

        public required Name Name { get; set; }

        public List<ContactPhone> PhoneNumbers { get;set;} = new List<ContactPhone>();

        public string? Email {get;set;}
        public Language? Language { get; set; } 
    }
}
