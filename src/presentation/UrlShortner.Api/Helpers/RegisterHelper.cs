using UrlShortner.Application.Interfaces;
using UrlShortner.Application.Repositories;
using UrlShortner.Application.Services;
using Urlshortner.Infrastructure.Services;

namespace UrlShortner.Api.Helpers;

public static class RegisterHelper
{
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUrlRepository, UrlRepository>();
        serviceCollection.AddTransient<IShortUrlGenerator, ShortUrlGenerator>();
        serviceCollection.AddTransient<IUrlShortenerService, UrlShortnerService>();
    }
    
    public static void AddInfrastructure(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddSingleton<IRedisService>(new RedisService(connectionString));
    }
}