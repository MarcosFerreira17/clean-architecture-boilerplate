using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Template.Presentation.Configurations;
using Template.Presentation.Configurations.Extensions;
using Template.Presentation.Middlewares;
using Template.Infrastructure.DataContext;
using Template.Infrastructure;
using Template.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
SerilogConfiguration.AddSerilogApi();
builder.Host.UseSerilog();
builder.Services.AddControllers();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.ConfigureCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MigrateDatabase<ApplicationDbContext>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
