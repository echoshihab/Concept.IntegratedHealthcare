

namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class ServiceRequest : IdentifiedData
    {
        public DateTime? Start { get; set; }  //occurrence period
        public DateTime? End { get; set; }  // occurrence period
        // TODO: Encounter
        public DateTime? RequestSignedDate { get; set; } //request signed date
        public Concept Status { get; set; } = null!; // Status
        public Concept Intent { get; set; } = null!; // Intent
        public ProcedureDetail ProcedureDetail { get; set; } = null!; // Code
        public Patient Patient { get; set; } = null!;// subject
        public PatientPractitioner Requester { get; set; } = null!; 
        public Guid StatusId { get;set;}
        public Guid IntentId { get;set;}
        public Guid ProcedureDetailId { get;set;}
        public Guid PatientId { get; set;}
        public Guid RequesterId { get;set;}
    }
}
