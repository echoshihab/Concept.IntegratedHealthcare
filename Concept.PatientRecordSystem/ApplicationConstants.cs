namespace Proto.PatientRecordSystem
{
    public class ApplicationConstants
    {
        public const string PATIENT = "PATIENT";

        public const string PatientUSCoreProfile = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-patient";
        public const string PractitionerUSCoreProfile = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-practitioner";
        public const string ServiceRequestUSCoreProfile = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-servicerequest";

        public const string InhIdentifierSystemMrn = "http://inh.org/identifiers/mrn";

        public const string NameTypeGiven = "Given";
        public const string NameTypeFamily = "Family";
        public const string ContactPointTypePhone = "phone";
        public const string ContactPointTypeEmail = "email";
    }
}
