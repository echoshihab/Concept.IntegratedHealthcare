using Proto.PatientRecordSystem.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Proto.PatientRecordSystem.Persistence.Service
{
    public abstract class PersistenceServiceBase<TResource> : IPersistenceService<TResource> where  TResource : IdentifiedData
    {
        protected readonly ApplicationDbContext _context;

        protected PersistenceServiceBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<TResource> CreateAsync(TResource resource)
        {
            this._context.Add(resource);

            try
            {
                await this._context.SaveChangesAsync();
                return resource;
            } 
            catch (Exception ex)
            {
                throw new DbUpdateException($"Unable to persist data {ex.Message}");
            }
        }

        public virtual Task<IEnumerable<TResource>> QueryAsync(Dictionary<string, string> queryParams)
        {
            throw new NotImplementedException();
        }
    }
}
