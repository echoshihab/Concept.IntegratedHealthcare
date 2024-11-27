using Microsoft.EntityFrameworkCore;
using Proto.PatientRecordSystem.DTOs;
using Proto.PatientRecordSystem.Persistence.Models;
using Proto.PatientRecordSystem.Service;
using System.Globalization;

namespace Proto.PatientRecordSystem.Persistence.Service
{
    public class PatientPersistenceService : PersistenceServiceBase<Patient>
    {
        private readonly IConceptService _conceptService;

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

            var givenConcept = await this._conceptService.RetreiveConceptAsync(ApplicationConstants.NameTypeGiven) ?? throw new ArgumentOutOfRangeException();

            if (queryParams.TryGetValue("lName", out var lName))
            {
                baseQuery = baseQuery.Where(p => p.Individual.NameParts.Any(n => (n.Value == lName && n.NameTypeConceptId == familyConcept.Id)));
            }

            if (queryParams.TryGetValue("fName", out var fname))
            {
                baseQuery = baseQuery.Where(p => p.Individual.NameParts.Any(n => (n.Value == fname && n.NameTypeConceptId == givenConcept.Id && n.Order == 0)));
            }

            if (queryParams.TryGetValue("mName", out var mName))
            {
                baseQuery = baseQuery.Where(p => p.Individual.NameParts.Any(n => (n.Value == fname && n.NameTypeConceptId == givenConcept.Id && n.Order == 1)));
            }

            if (queryParams.TryGetValue("birthDate", out var birthDateParam) && DateOnly.TryParseExact(birthDateParam, "YYYY-mm-dd", out var birthDate))
            {              
                baseQuery = baseQuery.Where(p => p.BirthDay == birthDate.Day && p.BirthMonth == birthDate.Month && p.BirthYear == birthDate.Year);
            }

            return await baseQuery.ToListAsync();           
        }
    }

    
}
