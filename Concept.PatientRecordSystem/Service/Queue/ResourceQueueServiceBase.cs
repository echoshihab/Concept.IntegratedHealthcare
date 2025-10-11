using Hl7.Fhir.Model;
using MassTransit;
using Proto.PatientRecordSystem.Service.Queue.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace Proto.PatientRecordSystem.Service.Queue
{
    public abstract class ResourceQueueServiceBase<TResource> : IResourceQueueService<TResource> where TResource: Resource
    {
        private readonly IPublishEndpoint _publishEndpoint;
        protected string? routingKey = null;

        protected ResourceQueueServiceBase(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        public async virtual Task PublishAsync(TResource resource)
        {
            if (this.routingKey == null) throw new ArgumentNullException(nameof(routingKey));

            await _publishEndpoint.Publish(resource, context => { 
                    context.SetRoutingKey(this.routingKey);
                }); 
        }
    }
}
