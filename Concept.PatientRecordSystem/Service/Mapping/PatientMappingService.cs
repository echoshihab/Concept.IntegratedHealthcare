using Concept.PatientRecordSystem.DTOs;
using Concept.PatientRecordSystem.Persistence.Models;

namespace Concept.PatientRecordSystem.Service.Mapping
{
    public class PatientMappingService : IMappingService<PatientDto, Patient>
    {
        public Patient MapToDatabaseModel(PatientDto domainResource)
        {
            throw new NotImplementedException();
        }

        public PatientDto MapToDomainModel(Patient persistenceResource)
        {
            throw new NotImplementedException();
        }
    }
}
