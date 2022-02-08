using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace BestHackerNews.Services
{

    //https://michaelscodingspot.com/cache-implementations-in-csharp-net/
    public class SemaphoreMemoryCache : IApiCache
    {
        private MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        private ConcurrentDictionary<object, SemaphoreSlim> _locks = new ConcurrentDictionary<object, SemaphoreSlim>();
        private TimeSpan _cacheSlidingExpiration = TimeSpan.FromSeconds(30);
        private TimeSpan _cacheAbsoluteExpiration = TimeSpan.FromMinutes(60);
        private int _cacheSize = 100;

        public async Task<TItem> GetOrCreate<TItem>(object key, Func<Task<TItem>> createItem)
        {
            TItem cacheEntry;
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSize(_cacheSize)
                //.SetPriority(CacheItemPriority.High)
                .SetSlidingExpiration(_cacheSlidingExpiration)
                .SetAbsoluteExpiration(_cacheAbsoluteExpiration);

            if (!_cache.TryGetValue(key, out cacheEntry))
            {
                SemaphoreSlim mylock = _locks.GetOrAdd(key, k => new SemaphoreSlim(1, 1));
                await mylock.WaitAsync();
                try
                {
                    if (!_cache.TryGetValue(key, out cacheEntry))
                    {
                        cacheEntry = await createItem();
                        _cache.Set(key, cacheEntry, cacheEntryOptions);
                    }
                }
                finally
                {
                    mylock.Release();
                }
            }
            return cacheEntry;
        }
    }
}
