namespace Proto.PatientRecordSystem.Service.Mapping.Interfaces
{
    public interface IFhirMappingService<TFhirResource, TPersistentResource>
    {
        Task<TFhirResource> MapToFhirResourceAsync(TPersistentResource persistentResource);
    }
}
