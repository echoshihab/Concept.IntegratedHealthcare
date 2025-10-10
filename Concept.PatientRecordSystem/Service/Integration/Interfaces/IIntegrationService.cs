namespace Proto.PatientRecordSystem.Service.Integration.Interfaces
{
    public interface IIntegrationService<TDbEntity>
    {
        void Send(TDbEntity dbEntity);
    }
}