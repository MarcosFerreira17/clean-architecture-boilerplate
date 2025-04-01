namespace Boilerplate.WebApi.Extensions;

using Asp.Versioning;
using Microsoft.OpenApi.Models;
using System.Reflection;

public static class ServiceExtensions
{
    public static void AddCorsExtensions(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: "AllowAngular",
                configurePolicy: policy =>
                {
                    policy.WithOrigins("https://localhost:5173");
                });
        });
    }

    public static void AddSwaggerExtensions(this IServiceCollection services)
    {
        services.AddSwaggerGen();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Boilerplate API",
                Version = "v1",
                Description = "Sample",
                Contact = new OpenApiContact
                {
                    Name = "Marcos Ferreira",
                    Email = "marcosfw7@@outlook.com",
                }
            });
            // Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
    }

    public static void AddApiVersioningExtensions(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-Api-Version"));
        })
        .AddMvc() // This is needed for controllers
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        });
    }

}
