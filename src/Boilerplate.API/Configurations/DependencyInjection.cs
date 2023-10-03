using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Boilerplate.Application.Services;
using Boilerplate.Application.Services.Interfaces;
using Boilerplate.Infrastructure.DataContext;
using Boilerplate.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Boilerplate.Infrastructure.Repositories.Interfaces;

namespace Boilerplate.API.Configurations;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBoilerplateRepository, BoilerplateRepository>();
        services.AddScoped<IBoilerplateService, BoilerplateService>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
    }

    public static void ConfigureCors(this IServiceCollection services) =>
    services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
    });
}
