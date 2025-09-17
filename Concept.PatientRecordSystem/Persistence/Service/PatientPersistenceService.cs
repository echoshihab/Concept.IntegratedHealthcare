using Hl7.Fhir.ElementModel.Types;
using Microsoft.EntityFrameworkCore;
using Proto.PatientRecordSystem.Exceptions;
using Proto.PatientRecordSystem.Persistence.Models;
using Proto.PatientRecordSystem.Service;

namespace Proto.PatientRecordSystem.Persistence.Service
{
    public class PatientPersistenceService : PersistenceServiceBase<Patient>
    {
        private readonly IConceptService _conceptService;

        private readonly Guid patientTypeConceptId = Guid.Parse("0582e424-c9c0-4e6b-a922-0dd16fb68aea");

        public PatientPersistenceService(ApplicationDbContext context, IConceptService conceptService): base(context)
        {
            this._conceptService = conceptService;
        }

        public override Task<Patient> CreateAsync(Patient resource)
        {
            resource.Individual.IndividualTypeConceptId = this.patientTypeConceptId;
            return base.CreateAsync(resource);
        }

        public override async Task<IEnumerable<Patient>> QueryAsync(Dictionary<string, string> queryParams)
        {
            var baseQuery = base._context.Patients
                .Include(p => p.GenderConcept)
                .Include(p => p.Individual)
                .ThenInclude(i => i.NameParts)               
                .AsQueryable();

            if (queryParams.TryGetValue("gender", out var gender) && gender is not null)
            {
                baseQuery = baseQuery.Where(p => p.GenderConcept.Value == gender);
            }

            var familyConcept = await this._conceptService.RetreiveConceptAsync(ApplicationConstants.NameTypeFamily) ?? throw new ArgumentOutOfRangeException();

            var givenConcept = await this._conceptService.RetreiveConceptAsync(ApplicationConstants.NameTypeGiven) ?? throw new ArgumentOutOfRangeException();

            if (queryParams.TryGetValue("lastName", out var lName) && lName is not null)
            {
                baseQuery = baseQuery.Where(p => p.Individual.NameParts.Any(n => (n.Value == lName && n.NameTypeConceptId == familyConcept.Id)));
            }

            if (queryParams.TryGetValue("firstName", out var fname) && fname is not null)
            {
                baseQuery = baseQuery.Where(p => p.Individual.NameParts.Any(n => (n.Value == fname && n.NameTypeConceptId == givenConcept.Id && n.Order == 0)));
            }

            if (queryParams.TryGetValue("middleName", out var mName) && mName is not null)
            {
                baseQuery = baseQuery.Where(p => p.Individual.NameParts.Any(n => (n.Value == fname && n.NameTypeConceptId == givenConcept.Id && n.Order == 1)));
            }

            if (queryParams.TryGetValue("birthDate", out var birthDateParam) && DateOnly.TryParseExact(birthDateParam, "YYYY-mm-dd", out var birthDate))
            {              
                baseQuery = baseQuery.Where(p => p.BirthDay == birthDate.Day && p.BirthMonth == birthDate.Month && p.BirthYear == birthDate.Year);
            }

            return await baseQuery.ToListAsync();           
        }

        /// <summary>
        /// Retrieves a patient asynchronously by its MRN.
        /// </summary>
        /// <param name="mrn">The unique identifier of the patient as a string.</param>
        /// <returns>The <see cref="Patient"/> entity if found.</returns>
        /// <exception cref="InvalidOperationException">Thrown if no patient is found with the specified MRN.</exception>
        public override async Task<Patient> GetAsync(string mrn)
        {   
            if (!Integer.TryParse(mrn, out var patientMrn))
            {
                throw new FormatException("Invalid format for MRN");
            }

            return await this._context.Patients
                .Include(p => p.GenderConcept)
                .Include(p => p.Individual)
                    .ThenInclude(i => i.NameParts)
                .FirstOrDefaultAsync(p => p.Mrn == patientMrn) 
                ?? throw new KeyNotFoundException($"No patient found with MRN: {mrn}");
        }


        public override async Task<Patient> UpdateAsync(string mrn, Patient resource)
        {
            if (!Integer.TryParse(mrn, out var patientMrn))
            {
                throw new FormatException("Invalid format for MRN");
            }

            resource.Individual.IndividualTypeConceptId = this.patientTypeConceptId;

            var patientDb = await this._context.Patients.Include(p => p.Individual).ThenInclude(n => n.NameParts).
                                FirstOrDefaultAsync(p => p.Mrn == patientMrn) ?? throw new KeyNotFoundException($"No patient found with MRN: {mrn}");

            patientDb.BirthDay = resource.BirthDay;
            patientDb.BirthMonth = resource.BirthMonth;
            patientDb.BirthYear = resource.BirthYear;

            patientDb.GenderConcept = resource.GenderConcept;

            var existingNames = patientDb.Individual.NameParts.ToList();
            var updatedNames = resource.Individual.NameParts.ToList();

            foreach (var namePart in existingNames)
            {
                var match = updatedNames.FirstOrDefault(n => n.NameTypeConceptId == namePart.NameTypeConceptId && n.Order == namePart.Order);

                if (match == null)
                {
                    // update removes the name
                    this._context.NameParts.Remove(namePart);  
                    continue;
                }

                namePart.Value = match.Value;

                // removing processed names
                updatedNames.Remove(match);
            }

            // add the remnant new names from updated names if any
            foreach (var newNamePart in updatedNames)
            {
                patientDb.Individual.NameParts.Add(new NamePart()
                {
                    NameTypeConceptId = newNamePart.NameTypeConceptId,
                    Order = newNamePart.Order,
                    Value = newNamePart.Value
                });
            }

            await this._context.SaveChangesAsync();
            return resource;
        }
    }    
}
