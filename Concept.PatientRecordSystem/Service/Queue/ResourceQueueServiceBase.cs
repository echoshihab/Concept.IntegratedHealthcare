using Hl7.Fhir.Model;
using MassTransit;
using MassTransit.Transports;
using Proto.PatientRecordSystem.Service.Queue.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace Proto.PatientRecordSystem.Service.Queue
{
    public abstract class ResourceQueueServiceBase<TResource> : IResourceQueueService<TResource> where TResource: Resource
    {        
        protected string? routingKey = null;
        private readonly ISendEndpointProvider _sendEndpointProvider;

        protected ResourceQueueServiceBase(ISendEndpointProvider _sendEndpointProvider)
        {
            this._sendEndpointProvider = _sendEndpointProvider;
        }
        public async virtual Task PublishAsync(TResource resource)
        {
            if (this.routingKey == null) throw new ArgumentNullException(nameof(routingKey));

            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("exchange:Inh.FhirResource"));

            await sendEndpoint.Send(resource, context =>
            {
                context.SetRoutingKey(this.routingKey);
            });
        }
    }
}
