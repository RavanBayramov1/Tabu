
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Tabu.DAL;
using Tabu.Exceptions;
using Tabu.ExternalServices.Abstracts;
using Tabu.ExternalServices.Implements;

namespace Tabu;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddValidatorsFromAssemblyContaining<Program>();
        builder.Services.AddStackExchangeRedisCache(opt =>
        {
            opt.Configuration = "Server=.\\SQLEXPRESS;Database=TABU;Trusted_Connection=True;TrustServerCertificate=True;";
            opt.InstanceName = "Tabu_";
        });
        builder.Services.AddScoped<ICacheService,RedisService>();

        builder.Services.AddAutoMapper(typeof(Program));

        builder.Services.AddServices();

        builder.Services.AddDbContext<TabuDbContext>(opt =>
        {
            opt.UseSqlServer("Server=.\\SQLEXPRESS;Database=TABU;Trusted_Connection=True;TrustServerCertificate=True;");
        });

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseTabuExceptionHandler();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
