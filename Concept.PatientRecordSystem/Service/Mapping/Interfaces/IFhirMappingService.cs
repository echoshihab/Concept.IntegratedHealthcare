namespace Proto.PatientRecordSystem.Service.Mapping.Interfaces
{
    public interface IFhirMappingService<TPersistentResource, TFhirResource>
    {
        Task<TFhirResource> MapToFhirResourceAsync(TPersistentResource persistentResource);
    }
}
