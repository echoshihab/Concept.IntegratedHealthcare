﻿using Proto.PatientRecordSystem.Persistence.Models;

namespace Proto.PatientRecordSystem.Persistence.Service
{
    public interface IPersistenceService<TResource> where TResource : IdentifiedData
    {
        Task<TResource> CreateAsync(TResource resource);

        Task<IEnumerable<TResource>> QueryAsync(Dictionary<string, string> queryPrams);
    }
}
