namespace Proto.PatientRecordSystem.Service
{
    public interface IMappingService<TDomainResource, TPersistenceResource>
    {
        TDomainResource MapToDomainModel(TPersistenceResource persistenceResource);

        TPersistenceResource MapToDatabaseModel(TDomainResource domainResource);
    }
}
