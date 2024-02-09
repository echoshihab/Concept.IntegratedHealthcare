using Hl7.Fhir.Model;

namespace Concept.PatientRecordSystem.Models
{
    public class PatientDb : Resource
    {
        public PatientDb()
        {
            this.ResourceType = "Patient";
        }

     
        public string MRN { get; set; }

        public string FamilyName { get; set; }

        //to
        public List<string> GivenName { get; set; }

        public List<string> Prefix { get; set; }

        public List<string> Suffix { get; set; }


    }
}
