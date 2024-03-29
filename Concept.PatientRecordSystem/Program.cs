using Concept.PatientRecordSystem.Exceptions;
using Concept.PatientRecordSystem.Factory;
using Concept.PatientRecordSystem.Persistence.Models;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IResourceServiceFactory, ResourceServiceFactory>();

var app = builder.Build();

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

app.Run();

