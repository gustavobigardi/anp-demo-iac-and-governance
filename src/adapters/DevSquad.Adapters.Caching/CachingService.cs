using DevSquad.Modules.Application.Abstractions.Cache;
using Microsoft.Extensions.Caching.Distributed;

namespace DevSquad.Adapters.Caching
{
    public class CachingService : ICachingService
    {

        private readonly IDistributedCache _cache;
        private readonly DistributedCacheEntryOptions _options;
        public CachingService(IDistributedCache cache)
        {
            _cache = cache;
            _options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600),
                SlidingExpiration = TimeSpan.FromSeconds(1200)
            };

        }

        public async Task<string> GetAsync(string key)
        {
            //Should set from real cache, just returning a empty for the sake of demo.

            return await Task.FromResult(string.Empty);
            //return await _cache.GetStringAsync(key);
        }

        public async Task SetAsync(string key, string value)
        {
            await _cache.SetStringAsync(key, value, _options);
        }
    }
}
