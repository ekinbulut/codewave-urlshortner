using RabbitMQ.Client;
using UrlShortner.Application.Handlers;
using UrlShortner.Application.Interfaces;
using UrlShortner.Application.Repositories;
using UrlShortner.Application.Services;
using UrlShortner.Domain.Interfaces;
using Urlshortner.Infrastructure.Services;

namespace UrlShortner.Api.Helpers;

public static class RegisterHelper
{
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUrlRepository, UrlRepository>();
        serviceCollection.AddTransient<IShortUrlGenerator, ShortUrlGenerator>();
        serviceCollection.AddTransient<IUrlShortenerService, UrlShortnerService>();
        serviceCollection.AddTransient<IUrlShortnerControllerHandler, UrlShortnerControllerHandler>();

    }
    
    public static void AddInfrastructure(this IServiceCollection serviceCollection, ConfigurationManager configuration)
    {
        var connectionString = configuration.GetConnectionString("Redis");
        serviceCollection.AddSingleton<IRedisService>(new RedisService(connectionString));
        var factory = new ConnectionFactory
        {
            HostName = configuration.GetConnectionString("Mq")
        };
        serviceCollection.AddSingleton<IMessageBroker>(new MessageBroker(factory));

    }
}