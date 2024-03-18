using UrlShortner.Application.DTOs.Requests;
using UrlShortner.Application.DTOs.Responses;

namespace UrlShortner.Application.Handlers;

public interface IUrlShortnerControllerHandler
{
    Task<CreateShortUrlResponse> ShortUrlAsync(CreateShortUrlRequest createShortUrlRequest);
    Task<GetLongUrlResponse> GetLongUrlAsync(string shortUrl);
}