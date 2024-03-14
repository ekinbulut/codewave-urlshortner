using StackExchange.Redis;
using Urlshortner.Infrastructure.Interfaces;

namespace Urlshortner.Infrastructure.Services;

public class RedisService : IRedisService
{
    
    private static Lazy<Task<ConnectionMultiplexer>> _lazyConnection;

    public RedisService(string connectionString)
    {
        _lazyConnection = new Lazy<Task<ConnectionMultiplexer>>(() => ConnectAsync(connectionString));
    }
    
    private static async Task<ConnectionMultiplexer> ConnectAsync(string connectionString)
    {
        return await ConnectionMultiplexer.ConnectAsync(connectionString);
    }
    
    private async Task<IDatabase> GetDatabaseAsync()
    {
        var connection = await _lazyConnection.Value;
        return connection.GetDatabase();
    }
    
    // Asynchronous operation: Set value
    public async Task<bool> SetValueAsync(string key, string value)
    {
        var database = await GetDatabaseAsync();
        return await database.StringSetAsync(key, value);
    }

    // Asynchronous operation: Get value
    public async Task<string> GetValueAsync(string key)
    {
        var database = await GetDatabaseAsync();
        return await database.StringGetAsync(key);
    }
    
}