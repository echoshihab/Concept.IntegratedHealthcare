﻿using Proto.PatientRecordSystem.Service;
using Hl7.Fhir.Model;
using Microsoft.AspNetCore.Mvc;

namespace Proto.PatientRecordSystem.Controllers.Fhir
{
    public class ServiceRequestController : FhirControllerBase<ServiceRequest>
    {
        public ServiceRequestController(IResourceService<ServiceRequest> serviceRequestResourceService) : base(serviceRequestResourceService)
        {

        }
    }
}
