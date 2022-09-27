using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.DataContext;
using FluentValidation.AspNetCore;
using Application.Interfaces;
using Infrastructure.Repositories;

namespace Presentation.Configurations;

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
        services.AddScoped<ITemplateRepository, TemplateRepository>();
        // services.AddScoped<ITemplateService, TemplateService>();
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
