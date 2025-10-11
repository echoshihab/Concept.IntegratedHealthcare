namespace Proto.PatientRecordSystem.Service.Queue.Interfaces
{
    public interface IResourceQueueService<TResource>
    {
        Task PublishAsync(TResource resource);
    }
}
