using Newtonsoft.Json;
using UrlShortner.Application.Interfaces;
using UrlShortner.Domain.Entities;
using UrlShortner.Domain.Interfaces;
using Urlshortner.Infrastructure.Services;

namespace UrlShortner.Application.Repositories;

public class UrlRepository : IUrlRepository
{
    private readonly IRedisService _redisService;

    public UrlRepository(IRedisService redisService)
    {
        _redisService = redisService;
    }

    public async Task<Url?> GetByUrlAsync(string longUrl)
    {
        var value = await _redisService.GetValueAsync(longUrl);
        return string.IsNullOrEmpty(value) ? null : JsonConvert.DeserializeObject<Url>(value);
    }

    public async Task AddAsync(Url url)
    {
        var value = JsonConvert.SerializeObject(url, Formatting.Indented);
        await _redisService.SetValueAsync(url.LongUrl, value);
        await _redisService.SetValueAsync(url.ShortUrl, value);
    }

    public async Task<Url?> GetByShortUrlAsync(string shortUrl)
    {
        var value = await _redisService.GetValueAsync(shortUrl);
        return string.IsNullOrEmpty(value) ? null : JsonConvert.DeserializeObject<Url>(value);
    }
}