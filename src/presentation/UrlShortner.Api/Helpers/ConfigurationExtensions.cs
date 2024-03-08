using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;
namespace UrlShortner.Api.Helpers;

public static class ConfigurationExtensions
{
    public static void UseOpenTelemetry(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddOpenTelemetry()
            .WithTracing(builder => builder
                .AddAspNetCoreInstrumentation()
                .AddConsoleExporter());

        serviceCollection.AddOpenTelemetry()
            .WithMetrics(builder => builder
                .AddPrometheusExporter(config 
                    => config.ScrapeResponseCacheDurationMilliseconds = 0));
    }
}