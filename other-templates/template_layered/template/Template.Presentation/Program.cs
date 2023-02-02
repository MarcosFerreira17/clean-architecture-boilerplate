using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Template.Application;
using Template.Presentation.Configurations;
using Template.Presentation.Configurations.Extensions;
using Template.Presentation.Middlewares;
using Template.Infrastructure;
using Template.Infrastructure.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
SerilogConfiguration.AddSerilogApi();
builder.Host.UseSerilog();
builder.Services.AddControllers();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
#if EnableSwaggerSupport
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
#endif
builder.Services.AddConfigureCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
#if EnableSwaggerSupport
    app.UseSwaggerConfiguration();
#endif
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MigrateDatabase<TemplateDbContext>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
