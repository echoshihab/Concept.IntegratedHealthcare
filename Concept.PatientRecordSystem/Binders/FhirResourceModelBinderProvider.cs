using Hl7.Fhir.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Proto.PatientRecordSystem.Binder
{
    public class FhirResourceModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            if (context.Metadata.ModelType.BaseType == typeof(DomainResource))
            {
                return new BinderTypeModelBinder(typeof(FhirResourceBinder));                
            }

            return null;
        }
    }
}
