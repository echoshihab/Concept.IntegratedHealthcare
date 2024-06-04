using Concept.PatientRecordSystem.Persistence;
using Concept.PatientRecordSystem.Persistence.Models;
using Concept.PatientRecordSystem.Service;


namespace Concept.PatientRecordSystem.Factory
{
    public class ResourceServiceFactory : IResourceServiceFactory
    {
        private readonly ApplicationDbContext _context;
        private readonly IResourceService<Hl7.Fhir.Model.Patient> _patientResourceService;

        public ResourceServiceFactory(ApplicationDbContext context, IResourceService<Hl7.Fhir.Model.Patient> patientResourceService)
        {
            this._context = context;
            _patientResourceService = patientResourceService;
        }
        public IResourceService<Hl7.Fhir.Model.Resource> GetResourceService(string resourceType) => resourceType.ToUpper() switch
        {
            ApplicationConstants.PATIENT => (IResourceService <Hl7.Fhir.Model.Resource>) _patientResourceService,
            _ => throw new NotSupportedException("Resource type not supported")
        };
    }
}
