using UrlShortner.Application.DTOs.Requests;
using UrlShortner.Application.DTOs.Responses;
using UrlShortner.Application.Interfaces;
using UrlShortner.Domain.Interfaces;

namespace UrlShortner.Application.Handlers;

public class UrlShortnerControllerHandler : IUrlShortnerControllerHandler
{
    private readonly IUrlShortenerService _urlShortenerService;
    private readonly IMessageBroker _messageBroker;

    public UrlShortnerControllerHandler(IUrlShortenerService urlShortenerService, IMessageBroker messageBroker)
    {
        _urlShortenerService = urlShortenerService;
        _messageBroker = messageBroker;
    }

    public async Task<CreateShortUrlResponse> ShortUrlAsync(CreateShortUrlRequest createShortUrlRequest)
    {
        var response = await _urlShortenerService.ShortenUrlAsync(createShortUrlRequest.LongUrl);
        await _messageBroker.PublishAsync(new
        {
            Id = Guid.NewGuid(),
            message = response.ShortUrl,
            original = createShortUrlRequest.LongUrl
        });

        return response;
    }

    public async Task<GetLongUrlResponse> GetLongUrlAsync(string shortUrl)
    {
        return await _urlShortenerService.GetLongUrlAsync(shortUrl);
    }
}