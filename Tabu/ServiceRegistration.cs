﻿using Microsoft.AspNetCore.Diagnostics;
using Tabu.Exceptions;
using Tabu.Services.Abstracts;
using Tabu.Services.Implements;

namespace Tabu;

public static class ServiceRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ILanguageService,LanguageService>();
        services.AddScoped<IGameService, GameService>();
        services.AddScoped<IWordService, WordService>();
        return services;
    }
    public static IApplicationBuilder UseTabuExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(handler =>
        {
            handler.Run(async context =>
            {
                var feature = context.Features.Get<IExceptionHandlerFeature>();
                Exception exc = feature!.Error;
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                if (exc is IBaseException ibe)
                {
                    context.Response.StatusCode = ibe.StatusCode;
                    await context.Response.WriteAsJsonAsync(new
                    {
                        StatusCode = ibe.StatusCode,
                        Message = ibe.ErrorMessage
                    });
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsJsonAsync(new
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "Bir xeta bash verdi!"
                    });
                }
            });
        });
        return app;
    }
}
