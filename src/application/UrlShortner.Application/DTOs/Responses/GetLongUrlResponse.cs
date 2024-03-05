using UrlShortner.Domain.Entities;

namespace UrlShortner.Application.DTOs.Responses;

public class GetLongUrlResponse
{
    public string RedirectUrl { get; set; }
}