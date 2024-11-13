// https://learn.microsoft.com/en-us/aspnet/core/mvc/advanced/custom-model-binding?view=aspnetcore-8.0


using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;

namespace Proto.PatientRecordSystem.Binder
{
    public class FhirResourceBinder : IModelBinder
    {
        public async System.Threading.Tasks.Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ArgumentNullException.ThrowIfNull(nameof(bindingContext));

            var modelType = bindingContext.ModelType;
       
            var options = new JsonSerializerOptions().ForFhir(ModelInfo.ModelInspector);

            try
            {
                var requestBody = bindingContext.HttpContext.Request.Body;

                var model = await JsonSerializer.DeserializeAsync(requestBody, modelType, options);

                bindingContext.Result = ModelBindingResult.Success(model);
            } 
            catch(Exception ex)
            {
                bindingContext.Result = ModelBindingResult.Failed();

                Console.Write(ex.Message);
            }
        }       
    }
}
