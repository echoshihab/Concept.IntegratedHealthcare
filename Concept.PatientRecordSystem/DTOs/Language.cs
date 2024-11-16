namespace Proto.PatientRecordSystem.DTOs
{
    public class Language
    {
        public required string Preferred { get; set; } 
        public string? Alternate { get; set; }
    }
}
