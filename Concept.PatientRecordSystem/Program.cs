using Proto.PatientRecordSystem.Binder;
using Proto.PatientRecordSystem.Exceptions;
using Proto.PatientRecordSystem.Persistence;
using Proto.PatientRecordSystem.Service;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Proto.PatientRecordSystem.DTOs;
using Proto.PatientRecordSystem.Service.Domain;
using Proto.PatientRecordSystem.Persistence.Models;
using Proto.PatientRecordSystem.Service.Mapping;
using Proto.PatientRecordSystem.Persistence.Service;
using MassTransit;
using Proto.PatientRecordSystem.Service.Mapping.Interfaces;
using RabbitMQ.Client;
using Proto.PatientRecordSystem.Service.Integration.Interfaces;
using Proto.PatientRecordSystem.Service.Integration;
using Proto.PatientRecordSystem.Service.Queue.Interfaces;
using Proto.PatientRecordSystem.Service.Queue;

var builder = WebApplication.CreateBuilder(args);


// Add Services to container
builder.Services.AddControllers(options =>
{
    options.ModelBinderProviders.Insert(0, new FhirResourceModelBinderProvider());
});

// Fhir Services
builder.Services.AddScoped<IResourceService<Hl7.Fhir.Model.Patient>, PatientResourceService>();
builder.Services.AddScoped<IResourceService<Hl7.Fhir.Model.Practitioner>, PractionerResourceService>();

// Rabbitmq
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.Message<Hl7.Fhir.Model.Resource>(x =>
        {
            x.SetEntityName("Inh.FhirResource");
        });
               

        cfg.Publish<Hl7.Fhir.Model.Resource>(p =>
        {
            p.ExchangeType = ExchangeType.Direct;
            p.Durable = false;                                                 
        });

        cfg.ConfigureEndpoints(context);
    });
});


// Patient Domain services
builder.Services.AddScoped<IDomainService<PatientDto, Patient>, PatientDomainService>();

// Domain Mapping Services
builder.Services.AddScoped<IMappingService<PatientDto, Patient>, PatientMappingService>();

// Fhir Mapping Services
builder.Services.AddScoped<IFhirMappingService<Patient, Hl7.Fhir.Model.Patient>, PatientFhirMappingService>();

// Concept Services
builder.Services.AddScoped<IConceptService, ConceptService>();

// Persistence Services
builder.Services.AddScoped<IPersistenceService<Patient>, PatientPersistenceService>();

// Integration Services
builder.Services.AddScoped<IIntegrationService<Patient>, PatientIntegrationService>();

// Queue Services
builder.Services.AddScoped<IResourceQueueService<Hl7.Fhir.Model.Patient>, PatientResourceQueueService>();




builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbContext"));
    options.UseLoggerFactory(LoggerFactory.Create(loggerOptions =>
    {
        loggerOptions.AddDebug();
        loggerOptions.AddConsole();
    }));
});


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

        if (exceptionHandlerPathFeature?.Error is InvalidResourceException)
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

