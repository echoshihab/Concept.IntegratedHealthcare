namespace Proto.PatientRecordSystem.DTOs
{
    public class PatientQuery : IQuery
    {
        public string? MRN { get; set; }
        public string? Gender {get;set;}
        public ushort? BirthYear { get; set; }
        public ushort? BirthMonth { get; set; }
        public ushort? BirthDay { get; set; }

        public  string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public  string? LastName { get; set; }

    }
}
