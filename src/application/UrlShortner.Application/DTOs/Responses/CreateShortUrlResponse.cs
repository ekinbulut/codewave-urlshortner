namespace UrlShortner.Application.DTOs.Responses;

public class CreateShortUrlResponse
{
    public string ShortUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}