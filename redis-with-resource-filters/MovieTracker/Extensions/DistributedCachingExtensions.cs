using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace MovieTracker.Extensions
{
    public static class DistributedCachingExtensions
    {
        public static async Task SetRecordAsync<T>(
            this IDistributedCache cache, 
            string recordKey,
            T data,
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? unusedExpireTime = null) 
        {
            var options = new DistributedCacheEntryOptions();
            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromMinutes(10);
            options.SlidingExpiration = unusedExpireTime ?? TimeSpan.FromMinutes(5);

            try
            {
                var settings = new JsonSerializerSettings {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                var jsonData = JsonConvert.SerializeObject(data, settings);
                await cache.SetStringAsync(recordKey, jsonData, options);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string recordKey) 
        {
            var jsonData = await cache.GetStringAsync(recordKey);
            if (jsonData is null) {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(jsonData);
        }
    }
}