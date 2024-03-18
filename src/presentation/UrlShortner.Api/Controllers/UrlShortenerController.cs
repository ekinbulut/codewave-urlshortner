using System.Net;
using Microsoft.AspNetCore.Mvc;
using UrlShortner.Application.DTOs.Requests;
using UrlShortner.Application.Handlers;

namespace UrlShortner.Api.Controllers;

[ApiController]
[Route("")]
public class UrlShortenerController : ControllerBase
{
    
    private readonly IUrlShortnerControllerHandler _controllerHandler;

    public UrlShortenerController(IUrlShortnerControllerHandler controllerHandler)
    {
        _controllerHandler = controllerHandler;
    }

    [HttpPost("api/v1/shorten")]
    public async Task<IActionResult> ShortenUrl([FromBody] CreateShortUrlRequest createShortUrlRequest)
    {
        var shortUrl = await _controllerHandler.ShortUrlAsync(createShortUrlRequest);
        return Ok(shortUrl);
    }

    [HttpGet("{shortUrl}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Redirect)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetLongUrl(string shortUrl)
    {
        var response = await _controllerHandler.GetLongUrlAsync(shortUrl);
        if (response == null)
        {
            return NotFound();
        }
        
        return Ok(response);
    }
}