using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sharky.Cache
{
    public interface IDistributedCacheManager : IBatchOperations
    {
        Task<T> GetAsync<T>(CacheKey key, Func<Task<T>> acquire);
        Task<T> GetAsync<T>(CacheKey key, Func<T> acquire);
        Task<T> GetAsync<T>(CacheKey key, Func<Task<T>> acquire, int expiredSeconds);
        Task<T> GetAsync<T>(CacheKey key, Func<T> acquire, int expiredSeconds);

        Task<T> GetAsync<T>(string key);
        Task<T> GetAsync<T>(string key, Func<Task<T>> acquire);
        Task<T> GetAsync<T>(string key, Func<T> acquire);
        Task<T> GetAsync<T>(string key, Func<Task<T>> acquire, int expiredSeconds);
        Task<T> GetAsync<T>(string key, Func<T> acquire, int expiredSeconds);


        Task SetAsync(CacheKey key, object value, int expiredSeconds);
        Task SetAsync(CacheKey key, object value);

        Task SetAsync(string key, object value, int expiredSeconds);
        Task SetAsync(string key, object value);

        Task RemoveAsync(string key);
    }
}
