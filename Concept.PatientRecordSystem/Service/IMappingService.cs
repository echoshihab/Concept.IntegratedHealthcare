namespace Proto.PatientRecordSystem.Service
{
    public interface IMappingService<TDomainResource, TPersistenceResource>
    {
        Task<TDomainResource> MapToDomainModelAsync(TPersistenceResource persistenceResource);

        Task<TPersistenceResource> MapToDatabaseModelAsync(TDomainResource domainResource);
    }
}
