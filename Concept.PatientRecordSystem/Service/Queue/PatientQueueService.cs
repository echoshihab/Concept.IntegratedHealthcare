using Hl7.Fhir.Model;
using MassTransit;

namespace Proto.PatientRecordSystem.Service.Queue
{
    public class PatientQueueService : ResourceQueueServiceBase<Patient>
    {
        public PatientQueueService(IPublishEndpoint publishEndpoint) : base(publishEndpoint)
        {
            
        }
    }
}
