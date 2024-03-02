using UrlShortner.Domain.Entities;

namespace UrlShortner.Application.Interfaces;

public class IUrlRepository
{
    public async Task<Url> GetByUrlAsync(string longUrl)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Url url)
    {
        throw new NotImplementedException();
    }

    public async Task<Url> GetByShortUrlAsync(string shortUrl)
    {
        throw new NotImplementedException();
    }
}