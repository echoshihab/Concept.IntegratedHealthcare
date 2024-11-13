using Proto.PatientRecordSystem.DTOs;
using Proto.PatientRecordSystem.Persistence.Models;

namespace Proto.PatientRecordSystem.Service.Mapping
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
