﻿namespace Concept.PatientRecordSystem.Persistence.Models
{
    public class ConceptSet : IdentifiedData
    {
        public ConceptSet()
        {
            this.Concepts = new List<Concept>();
        }
        public Guid IdentifierId { get; set; }
        public string Name { get; set; } = null!;
        public List<Concept> Concepts { get; set; } 
    }
}
