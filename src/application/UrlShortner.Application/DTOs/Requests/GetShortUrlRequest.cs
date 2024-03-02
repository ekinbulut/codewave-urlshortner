using System.ComponentModel.DataAnnotations;

namespace UrlShortner.Application.DTOs.Requests;

public class GetShortUrlRequest
{
    [Required]
    [Url]
    public string ShortUrl { get; set; }
}