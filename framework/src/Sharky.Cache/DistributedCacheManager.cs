using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Nito.AsyncEx;

namespace Sharky.Cache
{
    public class DistributedCacheManager : IDistributedCacheManager
    {
        private IDistributedCache _cache;
        private IBatchOperations _batchOperation;
        private static readonly AsyncLock _locker;
        private static readonly List<string> _keys;
        private readonly IDistributedCacheSerializer _cacheSerializer;

        public int Expiration { get; set; } = 60 * 30;//30 mins

        static DistributedCacheManager()
        {
            _locker = new AsyncLock();
            _keys = new List<string>();
        }

        public DistributedCacheManager(IDistributedCache cache, IBatchOperations batchOperation, IDistributedCacheSerializer cacheSerializer)
        {
            _cache = cache;
            _batchOperation = batchOperation;
            _cacheSerializer = cacheSerializer;
        }

        public Task ClearAllCacheItems()
        {
            return _batchOperation.ClearAllCacheItems();
        }

        public Task<T> GetAsync<T>(CacheKey key, Func<Task<T>> acquire)
        {
            return GetAsync(key.Create(), acquire, Expiration);
        }

        public Task<T> GetAsync<T>(CacheKey key, Func<T> acquire)
        {
            return GetAsync(key.Create(), acquire, Expiration);
        }

        public Task<T> GetAsync<T>(CacheKey key, Func<Task<T>> acquire, int expiredSeconds)
        {
            return GetAsync(key.Create(), acquire, expiredSeconds);
        }

        public Task<T> GetAsync<T>(CacheKey key, Func<T> acquire, int expiredSeconds)
        {
            return GetAsync(key.Create(), acquire, expiredSeconds);
        }

        public Task<T> GetAsync<T>(string key, Func<Task<T>> acquire)
        {

            return GetAsync(key, acquire, Expiration);
        }

        public Task<T> GetAsync<T>(string key, Func<T> acquire)
        {
            return GetAsync(key, acquire, Expiration);
        }

        public async Task<T> GetAsync<T>(string key, Func<Task<T>> acquire, int expiredSeconds)
        {
            var result = await GetAsync<T>(key);
            if (result == null)
            {
                result = await acquire();
                if (result != null)
                   await SetAsync(key, result, expiredSeconds);
            }

            return result;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var bytes = await _cache.GetAsync(key);

            if (bytes != null)
                return _cacheSerializer.ToObject<T>(bytes);
            return default(T);
        }

        public async Task<T> GetAsync<T>(string key, Func<T> acquire, int expiredSeconds)
        {
            var result = await GetAsync<T>(key);
            if (result == null)
            {
                result = acquire();
                if (result != null)
                    await SetAsync(key, result, expiredSeconds);
            }
            return result;
        }

        public async Task RemoveAsync(string key)
        {
            using var _ = await _locker.LockAsync();
            await _cache.RemoveAsync(key);
        }

        public Task RemoveByPrefixAsync(string prefix)
        {
            throw new NotImplementedException();
        }

        public async Task SetAsync(CacheKey key, object value, int expiredSeconds)
        {
            if (value == null) return;
            var keyStr = key.Create();
            await SetAsync(keyStr, value, Expiration);
        }

        public async Task SetAsync(CacheKey key, object value)
        {
            if (value == null) return;
            await SetAsync(key, value, Expiration);
        }

        public async Task SetAsync(string key, object value, int expiredSeconds)
        {
            if (value == null) return;
            using var _ = await _locker.LockAsync();
            await _cache.SetAsync(key, _cacheSerializer.GetBytes(value), GetEntryOptions(expiredSeconds));
        }

        public async Task SetAsync(string key, object value)
        {
            if (value == null) return;
            await SetAsync(key, value, Expiration);
        }


        #region Cache Option
        private DistributedCacheEntryOptions GetEntryOptions(int expiredSeconds)
        {
            //set expiration time for the passed cache key
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(expiredSeconds)
            };
            return options;
        }

        #endregion
    }
}
