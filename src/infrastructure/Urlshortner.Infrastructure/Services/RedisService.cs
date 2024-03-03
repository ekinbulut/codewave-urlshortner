using StackExchange.Redis;

namespace Urlshortner.Infrastructure.Services;

public interface IRedisService
{
    IDatabase GetDb(int db = -1);
}

public class RedisService : IDisposable, IRedisService
{
    private readonly ConnectionMultiplexer _redis;

    public RedisService(string connectionString)
    {
        _redis = ConnectionMultiplexer.Connect(connectionString);
    }

    public IDatabase GetDb(int db = -1)
    {
        return _redis.GetDatabase(db);
    }

    public void Dispose()
    {
        _redis?.Dispose();
    }
}