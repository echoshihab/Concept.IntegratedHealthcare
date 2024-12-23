using Microsoft.AspNetCore.Mvc;
using Proto.PatientRecordSystem.DTOs;
using Proto.PatientRecordSystem.Persistence.Models;
using Proto.PatientRecordSystem.Service;

namespace Proto.PatientRecordSystem.Controllers.Domain
{
    public class PatientController : DomainControllerBase<PatientDto>
    {
        private readonly IDomainService<PatientDto, Patient> _domainResourceService;

        public PatientController(IDomainService<PatientDto, Patient> domainResourceService) : base()
        {
            _domainResourceService = domainResourceService;
        }

        public override async Task<IActionResult> CreateAsync(PatientDto resource)
        {
          return this.Ok(await this._domainResourceService.CreateAsync(resource));
        }

        public override async Task<IActionResult> QueryAsync([FromQuery] Dictionary<string, string> queryParams)
        {
            return this.Ok(await this._domainResourceService.QueryAsync(queryParams));
        }
    }
}
