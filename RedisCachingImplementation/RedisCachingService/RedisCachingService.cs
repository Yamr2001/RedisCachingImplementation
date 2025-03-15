
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace RedisCachingImplementation.RedisCachingService
{
    public class RedisCachingService(IDistributedCache cache) : IRedisCachingService
    {
        private readonly IDistributedCache _cache = cache;
        public async Task<T> GetAsync<T>(string key)
        {
            string? data = await _cache.GetStringAsync(key);
            if (data is null)
                return default(T);
            return JsonSerializer.Deserialize<T>(data);
        }

        public Task RemoveAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            var option = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.Add(expiry ?? TimeSpan.FromSeconds(30))
            };
            return _cache.SetStringAsync(key, JsonSerializer.Serialize(value), option);
        }
    }
}
