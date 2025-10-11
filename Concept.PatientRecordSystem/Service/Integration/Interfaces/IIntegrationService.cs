namespace Proto.PatientRecordSystem.Service.Integration.Interfaces
{
    public interface IIntegrationService<TDbEntity>
    {
        Task SendAsync(TDbEntity dbEntity);
    }
}