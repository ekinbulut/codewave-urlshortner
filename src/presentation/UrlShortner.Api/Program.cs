using UrlShortner.Api.Helpers;
using UrlShortner.Api.Middleware;

namespace UrlShortner.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddServices();
        builder.Services.AddAuthorization();
        builder.Services.AddMvc();
        builder.Services.UseOpenTelemetry();
        

        var connectionString = builder.Configuration.GetConnectionString("Redis");
        builder.Services.AddInfrastructure(connectionString);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseOpenTelemetryPrometheusScrapingEndpoint();
        app.UseLogging();
        app.UseErrorHandling();
        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}