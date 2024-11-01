using Concept.PatientRecordSystem.DTOs;
using Concept.PatientRecordSystem.Persistence.Models;
using Concept.PatientRecordSystem.Service;

namespace Concept.PatientRecordSystem.Controllers.Domain
{
    public class PatientController : DomainControllerBase<PatientDto>
    {
        private readonly IDomainService<PatientDto, Patient> _domainResourceService;

        public PatientController(IDomainService<PatientDto, Patient> domainResourceService) : base()
        {
            _domainResourceService = domainResourceService;
        }

        public override async Task<PatientDto> CreateAsync(PatientDto resource)
        {
          return await this._domainResourceService.CreateAsync(resource);
        }
    }
}
