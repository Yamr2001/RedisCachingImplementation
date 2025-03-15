namespace RedisCachingImplementation.RedisCachingService
{
    public interface IRedisCachingService
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value, TimeSpan? expiry = null);
        Task RemoveAsync(string key);
    }
}
