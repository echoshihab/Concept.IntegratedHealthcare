using Microsoft.EntityFrameworkCore;
using Proto.PatientRecordSystem.DTOs;
using Proto.PatientRecordSystem.Persistence.Models;
using Proto.PatientRecordSystem.Service;

namespace Proto.PatientRecordSystem.Persistence.Service
{
    public class PatientPersistenceService : PersistenceServiceBase<Patient>
    {
        private readonly IConceptService _conceptService;
        private IQuery queryParams = new PatientQuery();

        public PatientPersistenceService(ApplicationDbContext context, IConceptService conceptService): base(context)
        {
            this._conceptService = conceptService;
        }

        public override Task<Patient> CreateAsync(Patient resource)
        {
            return base.CreateAsync(resource);
        }

        public override async Task<IEnumerable<Patient>> QueryAsync(Dictionary<string, string> queryParams)
        {
            var baseQuery = base._context.Patients.AsQueryable();

            if (queryParams.TryGetValue("gender", out var gender))
            {
                baseQuery = baseQuery.Where(p => p.GenderConcept.Value == gender);
            }

            var familyConcept = await this._conceptService.RetreiveConceptAsync(ApplicationConstants.NameTypeFamily) ?? throw new ArgumentOutOfRangeException();

            if (queryParams.TryGetValue("lname", out var lname))
            {
                baseQuery = baseQuery.Where(p => p.Individual.NameParts.Any(n => (n.Value == lname && n.NameTypeConceptId == familyConcept.Id)));
            }
        }
    }

    
}
