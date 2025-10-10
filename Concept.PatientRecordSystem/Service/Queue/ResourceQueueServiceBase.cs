using Hl7.Fhir.Model;
using MassTransit;
using Proto.PatientRecordSystem.Service.Queue.Interfaces;

namespace Proto.PatientRecordSystem.Service.Queue
{
    public abstract class ResourceQueueServiceBase<TResource> : IResourceQueueService<TResource> where TResource: Resource
    {
        private readonly IPublishEndpoint _publishEndpoint;

        protected ResourceQueueServiceBase(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        public virtual void publish(TResource resource)
        {
            _publishEndpoint.Publish(resource);
        }
    }
}
