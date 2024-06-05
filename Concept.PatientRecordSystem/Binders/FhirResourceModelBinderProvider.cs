using Hl7.Fhir.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Concept.PatientRecordSystem.Binder
{
    public class FhirResourceModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            if (context.Metadata.ModelType == typeof(Resource))
            {
                return new BinderTypeModelBinder(typeof(FhirResourceBinder));                
            }

            return null;
        }
    }
}
