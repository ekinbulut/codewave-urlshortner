using UrlShortner.Domain.Entities;

namespace UrlShortner.Domain.Interfaces;

public interface IUrlRepository
{
   Task<Url?> GetByUrlAsync(string longUrl);
   Task AddAsync(Url url);
   Task<Url?> GetByShortUrlAsync(string shortUrl);
}