using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Template.Application.Services;
using Template.Domain.Interfaces;

namespace Template.Application;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<ITemplateService, TemplateService>();
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
    }
}
