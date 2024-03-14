namespace Urlshortner.Infrastructure.Interfaces;

public interface IRedisService
{
    Task<bool> SetValueAsync(string key, string value);
    Task<string> GetValueAsync(string key);
}