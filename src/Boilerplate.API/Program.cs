using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Boilerplate.API.Configurations;
using Boilerplate.API.Configurations.Extensions;
using Boilerplate.API.Middlewares;
using Boilerplate.Infra.Database.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
SerilogConfiguration.AddSerilogApi();

builder.Host.UseSerilog();

builder.Services.AddControllers();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerConfiguration();

builder.Services.ConfigureCors();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwaggerConfiguration();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MigrateDatabase<ApplicationDbContext>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
