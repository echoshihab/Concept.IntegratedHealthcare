using Proto.PatientRecordSystem.Service.Integration.Interfaces;
using Proto.PatientRecordSystem.Service.Mapping.Interfaces;
using Proto.PatientRecordSystem.Service.Queue.Interfaces;

namespace Proto.PatientRecordSystem.Service.Integration
{
    public abstract class IntegrationServiceBase<TDbEntity, TFhirResource> : IIntegrationService<TDbEntity>
    {
        private readonly IFhirMappingService<TDbEntity, TFhirResource> _fhirMappingService;
        private readonly IResourceQueueService<TFhirResource> _resourceQueueService;

        protected IntegrationServiceBase(IFhirMappingService<TDbEntity, TFhirResource> fhirMappingService, IResourceQueueService<TFhirResource> resourceQueueService)
        {
            _fhirMappingService = fhirMappingService;
            _resourceQueueService = resourceQueueService;
        }

        public async virtual void Send(TDbEntity dbEntity)
        {
            var fhirResource = await _fhirMappingService.MapToFhirResourceAsync(dbEntity);

            _resourceQueueService.publish(fhirResource);
        }
    }
}
