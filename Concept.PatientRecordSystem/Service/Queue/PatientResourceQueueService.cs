using Hl7.Fhir.Model;
using MassTransit;

namespace Proto.PatientRecordSystem.Service.Queue
{
    public class PatientResourceQueueService : ResourceQueueServiceBase<Patient>
    {
        public PatientResourceQueueService(IPublishEndpoint publishEndpoint) : base(publishEndpoint)
        {
            base.routingKey = nameof(Patient);
        }
    }
}
