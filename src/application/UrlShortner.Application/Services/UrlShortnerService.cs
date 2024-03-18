using UrlShortner.Application.DTOs.Responses;
using UrlShortner.Application.Interfaces;
using UrlShortner.Domain.Entities;
using UrlShortner.Domain.Interfaces;

namespace UrlShortner.Application.Services;

public class UrlShortnerService: IUrlShortenerService
{
    private readonly IUrlRepository _urlRepository;
    private readonly IShortUrlGenerator _shortUrlGenerator;

    public UrlShortnerService(IShortUrlGenerator shortUrlGenerator, IUrlRepository urlRepository)
    {
        _shortUrlGenerator = shortUrlGenerator;
        _urlRepository = urlRepository;
    }

    public async Task<CreateShortUrlResponse> ShortenUrlAsync(string longUrl)
    {
        var response = new CreateShortUrlResponse();
        var url = await _urlRepository.GetByUrlAsync(longUrl);
        if (url != null)
        {
            response.ShortUrl = url.ShortUrl;
            return response;
        }

        var shortUrl = _shortUrlGenerator.GenerateShortUrl();
        
        url = new Url { LongUrl = longUrl, ShortUrl = shortUrl };
        await _urlRepository.AddAsync(url);
        response.ShortUrl = shortUrl;
        
        return response;
    }

    public async Task<GetLongUrlResponse> GetLongUrlAsync(string shortUrl)
    {
        var url = await _urlRepository.GetByShortUrlAsync(shortUrl);
        return new GetLongUrlResponse(){ RedirectUrl = url.LongUrl};
    }
}