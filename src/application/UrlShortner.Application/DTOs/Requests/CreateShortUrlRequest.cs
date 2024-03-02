using System.ComponentModel.DataAnnotations;

namespace UrlShortner.Application.DTOs.Requests;

public class CreateShortUrlRequest
{
    [Required]
    [Url]
    public string LongUrl { get; set; }
}