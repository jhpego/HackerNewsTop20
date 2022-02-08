using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace BestHackerNews.Services
{
    public interface IApiCache
    {

        Task<TItem> GetOrCreate<TItem>(object key, Func<Task<TItem>> createItem);
    }
}
