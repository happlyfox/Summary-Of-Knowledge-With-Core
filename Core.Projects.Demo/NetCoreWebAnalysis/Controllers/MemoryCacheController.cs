using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreWebAnalysis.Controllers
{
    /// <summary>
    /// 缓存使用说明
    /// </summary>
    [ApiController]
    [Route("MemoryCache")]

    public class MemoryCacheController : Controller
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// cache状态变化回调
        /// </summary>
        [HttpGet("CacheStateCallback")]
        public void CacheStateCallback()
        {
            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions();
            options.AbsoluteExpiration = DateTime.Now.AddSeconds(1);
            options.RegisterPostEvictionCallback(MyCallback, this);

            string cacheKey = "absoluteKey";
            _memoryCache.Get(cacheKey);
            _memoryCache.Set(cacheKey, DateTime.Now.ToString(), options);

            Task.Run(() =>
            {
                Task.Delay(1000).Wait();
                _memoryCache.Get(cacheKey);
            });

            Task.Delay(2000).Wait();
        }

        private void MyCallback(object key, object value, EvictionReason reason, object state)
        {
            var message = $"Cache entry state change:{key} {value} {reason} {state}";
            _memoryCache.Set("callbackMessage", message);

            Console.WriteLine(message);
        }

    }
}
