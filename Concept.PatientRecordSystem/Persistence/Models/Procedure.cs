namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class ProcedureDetail : IdentifiedData
    {
        public string Code { get; set; }
        public bool Active { get; set; }
        public string? Description { get; set; }
    }
}
