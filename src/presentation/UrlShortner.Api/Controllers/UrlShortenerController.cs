using Microsoft.AspNetCore.Mvc;
using UrlShortner.Application.DTOs.Requests;
using UrlShortner.Application.Interfaces;

namespace UrlShortner.Api.Controllers;

[ApiController]
[Route("")]
public class UrlShortenerController : ControllerBase
{
    private readonly IUrlShortenerService _urlShortenerService;

    public UrlShortenerController(IUrlShortenerService urlShortenerService)
    {
        _urlShortenerService = urlShortenerService;
    }

    [HttpPost("api/v1/shorten")]
    public async Task<IActionResult> ShortenUrl([FromBody] CreateShortUrlRequest createShortUrlRequest)
    {
        var longUrl = createShortUrlRequest.LongUrl;
        var shortUrl = await _urlShortenerService.ShortenUrlAsync(longUrl);
        return Ok(shortUrl);
    }

    [HttpGet("{shortUrl}")]
    public async Task<IActionResult> GetLongUrl(string shortUrl)
    {
        var longUrl = await _urlShortenerService.GetLongUrlAsync(shortUrl);
        if (longUrl == null)
        {
            return NotFound();
        }
        return Ok(longUrl);
    }
}