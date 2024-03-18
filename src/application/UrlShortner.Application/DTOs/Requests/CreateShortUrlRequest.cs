using System.ComponentModel.DataAnnotations;

namespace UrlShortner.Application.DTOs.Requests;

public class CreateShortUrlRequest : BaseRequest
{
    [Required]
    [Url]
    public string LongUrl { get; set; }
}