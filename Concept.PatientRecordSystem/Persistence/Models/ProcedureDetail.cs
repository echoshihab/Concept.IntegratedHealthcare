namespace Proto.PatientRecordSystem.Persistence.Models
{
    public class ProcedureDetail : IdentifiedData
    {
        public string Code { get; set; }
        public bool Active { get; set; }
        public string? Description { get; set; }
        public string? Display { get; set; }


        public Modality Modality { get; set; } = null!;
        public Guid ModalityId { get; set; }
    }
}
