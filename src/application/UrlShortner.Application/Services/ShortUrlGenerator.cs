using UrlShortner.Domain.Interfaces;

namespace UrlShortner.Application.Services;

public class ShortUrlGenerator : IShortUrlGenerator
{
    private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    private static Random _random = new Random();

    public string GenerateShortUrl()
    {
        return new string(Enumerable.Repeat(_chars, 7)
            .Select(s => s[_random.Next(s.Length)]).ToArray());
    }
}