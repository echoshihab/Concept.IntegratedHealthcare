using System.ComponentModel.DataAnnotations;

namespace Proto.PatientRecordSystem.DTOs
{
    public class Name
    {       
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }    
        public required string LastName { get; set; }
    }
}
