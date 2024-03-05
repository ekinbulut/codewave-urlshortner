using Newtonsoft.Json;
using UrlShortner.Application.Interfaces;
using UrlShortner.Domain.Entities;
using Urlshortner.Infrastructure.Services;

namespace UrlShortner.Application.Repositories;

public class UrlRepository : IUrlRepository
{
    private IRedisService _redisService;

    public UrlRepository(IRedisService redisService)
    {
        _redisService = redisService;
    }

    public async Task<Url?> GetByUrlAsync(string longUrl)
    {
        var db = _redisService.GetDb();
        var value = db.StringGet(longUrl);

        if (value.HasValue)
        {
            var urlString = (string)value;
            return JsonConvert.DeserializeObject<Url>(urlString);
        }

        return null;
    }

    public async Task AddAsync(Url url)
    {
        var db = _redisService.GetDb();
        var value = JsonConvert.SerializeObject(url, Formatting.Indented);
        db.StringSet(url.LongUrl, value);
    }

    public async Task<Url> GetByShortUrlAsync(string shortUrl)
    {
        throw new NotImplementedException();
    }
}