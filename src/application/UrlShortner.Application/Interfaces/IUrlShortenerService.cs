using UrlShortner.Application.DTOs.Responses;

namespace UrlShortner.Application.Interfaces;

public interface IUrlShortenerService
{
    Task<CreateShortUrlResponse> ShortenUrlAsync(string longUrl);
    Task<string> GetLongUrlAsync(string shortUrl);
}