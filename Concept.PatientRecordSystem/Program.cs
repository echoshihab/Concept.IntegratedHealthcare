using Proto.PatientRecordSystem.Binder;
using Proto.PatientRecordSystem.Exceptions;
using Proto.PatientRecordSystem.Persistence;
using Proto.PatientRecordSystem.Service;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add Services to container
builder.Services.AddControllers(options =>
{
    options.ModelBinderProviders.Insert(0, new FhirResourceModelBinderProvider());
});

builder.Services.AddScoped<IResourceService<Hl7.Fhir.Model.Patient>, PatientResourceService>();
builder.Services.AddScoped<IResourceService<Hl7.Fhir.Model.Practitioner>, PractionerResourceService>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DbContext")));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        context.Response.ContentType = "application/json";

        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

        if(exceptionHandlerPathFeature?.Error is InvalidResourceException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(exceptionHandlerPathFeature?.Error.Message);   
        }
        else if (exceptionHandlerPathFeature?.Error is Exception)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(exceptionHandlerPathFeature?.Error.Message);
        }
    });
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

try
{
    DbInitializer.InitDb(app);
}
catch (Exception e)
{
    Console.WriteLine(e);
}

app.Run();

