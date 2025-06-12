using Microsoft.Extensions.Caching.Memory;

namespace ClairTourTiny.Core.Services
{
    public interface IConnectionStringCache
    {
        void SetConnectionString(string username, string connectionString);
        string GetConnectionString(string username);
    }

    public class ConnectionStringCache : IConnectionStringCache
    {
        private readonly IMemoryCache _cache;
        private const string CacheKeyPrefix = "ConnectionString_";

        public ConnectionStringCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void SetConnectionString(string username, string connectionString)
        {
            var cacheKey = $"{CacheKeyPrefix}{username}";
            _cache.Set(cacheKey, connectionString, TimeSpan.FromHours(1));
        }

        public string GetConnectionString(string username)
        {
            var cacheKey = $"{CacheKeyPrefix}{username}";
            return _cache.Get<string>(cacheKey);
        }
    }
} 