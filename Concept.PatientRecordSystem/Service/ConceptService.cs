using Microsoft.EntityFrameworkCore;
using Proto.PatientRecordSystem.Persistence;
using Proto.PatientRecordSystem.Persistence.Models;

namespace Proto.PatientRecordSystem.Service
{
    public class ConceptService(ApplicationDbContext context) : IConceptService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Concept?> RetreiveConceptAsync(string value)
        {
            return await _context.Concepts.FirstOrDefaultAsync(c => c.Value == value);
        }

        public async Task<Concept?> RetreiveConceptByIdAsync(Guid? guid)
        {
            return await _context.Concepts.FirstOrDefaultAsync(c => c.Id == guid);
        }
    }
}
