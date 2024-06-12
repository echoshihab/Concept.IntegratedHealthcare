﻿namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class Patient : IdentifiedData
    {
        public Patient()
        {        
            this.Languages = new HashSet<PatientLanguage>();
            this.Telecoms = new HashSet<PatientTelecom>();
        }

        public Guid GenderConceptId { get; set; }
        public ushort BirthYear { get; set; }
        public ushort BirthMonth { get; set; }
        public ushort BirthDay { get; set; }
        public Guid IndividualId { get; set; }
        public Individual Individual { get; set; } = null!;
        public ICollection<PatientLanguage> Languages { get; set; }
        public ICollection<PatientTelecom> Telecoms { get; set; }
        public Concept GenderConcept { get;set;}        
    }
}
