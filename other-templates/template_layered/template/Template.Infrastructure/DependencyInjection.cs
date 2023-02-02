using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.Infrastructure.DataContext;
using Template.Infrastructure.Interfaces;
using Template.Infrastructure.Repositories;

namespace Template.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITemplateRepository, TemplateRepository>();

        string connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<TemplateDbContext>(options =>
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }
}
