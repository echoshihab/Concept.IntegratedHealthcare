
using Concept.PatientRecordSystem.DTOs;

namespace Concept.PatientRecordSystem.Service
{
    public interface IDomainService<Tresource> where Tresource : IdentifiableData
    {
        Task<Tresource> CreateAsync(Tresource resource);
    }
}
