using Hl7.Fhir.Model;
using MassTransit;
using Proto.PatientRecordSystem.Service.Queue.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace Proto.PatientRecordSystem.Service.Queue
{
    public abstract class ResourceQueueServiceBase<TResource> : IResourceQueueService<TResource> where TResource: Resource
    {
        private readonly IPublishEndpoint _publishEndpoint;        

        protected ResourceQueueServiceBase(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        public async virtual Task PublishAsync(TResource resource)
        {            
            await _publishEndpoint.Publish(resource);
        }
    }
}
