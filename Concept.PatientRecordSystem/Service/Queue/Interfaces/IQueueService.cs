namespace Proto.PatientRecordSystem.Service.Queue.Interfaces
{
    public interface IResourceQueueService<TResource>
    {
        void publish(TResource resource);
    }
}
