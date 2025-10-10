namespace Proto.PatientRecordSystem.Service.Mapping.Interfaces
{
    public interface IMappingService<TDomainResource, TPersistenceResource>
    {
        Task<TDomainResource> MapToDomainModelAsync(TPersistenceResource persistenceResource);
        Task<TPersistenceResource> MapToDbModelAsync(TDomainResource domainResource);

    }
}
