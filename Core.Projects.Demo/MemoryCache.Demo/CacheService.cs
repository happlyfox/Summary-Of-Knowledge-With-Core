using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Core.Cache.Demo
{
    public class CacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// 缓存设置
        /// </summary>
        public void BaseCache()
        {
            string cacheKey = "timestamp";
            //set cache
            _memoryCache.Set(cacheKey, DateTime.Now.ToString());

            //get cache
            Console.WriteLine(_memoryCache.Get(cacheKey));
        }

        /// <summary>
        /// 库的使用
        /// </summary>
        public void ActionUse()
        {
            //场景-如果缓存存在，取出。如果缓存不存在，写入
            //原始写法
            string cacheKey = "timestamp";
            if (_memoryCache.Get(cacheKey) != null)
            {
                _memoryCache.Set(cacheKey, DateTime.Now.ToString());
            }
            else
            {
                Console.WriteLine(_memoryCache.Get(cacheKey));
            }

            //新写法
            var dataCacheValue = _memoryCache.GetOrCreate(cacheKey, entry =>
             {
                 return DateTime.Now.ToString();
             });
            Console.WriteLine(dataCacheValue);

            //删除缓存
            _memoryCache.Remove(cacheKey);

            //场景 判断缓存是否存在的同时取出缓存数据
            _memoryCache.TryGetValue(cacheKey, out string cacheValue);
            Console.WriteLine(cacheValue);

        }

        /// <summary>
        /// 过期缓存
        /// </summary>
        public void ExpiredCache()
        {
            //set absolute cache
            string cacheKey = "absoluteKey";
            _memoryCache.Set(cacheKey, DateTime.Now.ToString(), TimeSpan.FromSeconds(5));

            //get absolute cache
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(_memoryCache.Get(cacheKey));
                Thread.Sleep(1000);
            }

            Console.WriteLine("----------------------------");

            //set slibing cache
            string cacheSlibingKey = "slibingKey";
            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions();
            options.SlidingExpiration = TimeSpan.FromSeconds(2);

            _memoryCache.Set(cacheSlibingKey, DateTime.Now.ToString(), options);

            //get slibing cache
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(_memoryCache.Get(cacheSlibingKey));
                Thread.Sleep(1000);
            }
            for (int i = 0; i < 2; i++)
            {
                Thread.Sleep(2000);
                Console.WriteLine(_memoryCache.Get(cacheSlibingKey));
            }


            Console.WriteLine("----------------------------");
            //组合缓存 绝对到期+滑动过期

            string cacheCombineKey = "combineKey";
            MemoryCacheEntryOptions combineOptions = new MemoryCacheEntryOptions();
            combineOptions.SlidingExpiration = TimeSpan.FromSeconds(2);
            combineOptions.AbsoluteExpiration = DateTime.Now.AddSeconds(6);

            _memoryCache.Set(cacheCombineKey, DateTime.Now.ToString(), combineOptions);

            //get slibing cache
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(_memoryCache.Get(cacheCombineKey));
                Thread.Sleep(1000);
            }

            for (int i = 0; i < 6; i++)
            {
                Thread.Sleep(2000);
                Console.WriteLine(i+"|" + _memoryCache.Get(cacheCombineKey));
            }

            Console.WriteLine("------------combineKey End----------------");

        }

        /// <summary>
        /// cache状态变化回调
        /// </summary>
        public void CacheStateCallback()
        {
            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions();
            options.AbsoluteExpiration = DateTime.Now.AddSeconds(3
                );
            options.RegisterPostEvictionCallback(MyCallback, this);

            //show callback console
            string cacheKey = "absoluteKey";
            _memoryCache.Set(cacheKey, DateTime.Now.ToString(), options);

            Thread.Sleep(500);
            _memoryCache.Set(cacheKey, DateTime.Now.ToString(), options);

            _memoryCache.Remove(cacheKey);

        }

        private static void MyCallback(object key, object value, EvictionReason reason, object state)
        {
            var message = $"Cache entry state change:{key} {value} {reason} {state}";
            ((CacheService)state)._memoryCache.Set("callbackMessage", message);

            Console.WriteLine(message);
        }


        /// <summary>
        /// 缓存依赖策略
        /// </summary>
        public void CacheDependencyPolicy()
        {
            //设置一个缓存A 
            //设置一个缓存B,依赖于缓存A 如果缓存A失效,缓存B也失效

            string DependentCTS = "DependentCTS";
            string cacheKeyParent = "CacheKeys.Parent";
            string cacheKeyChild = "CacheKeys.Child";

            var cts = new CancellationTokenSource();
            _memoryCache.Set(DependentCTS, cts);

            //创建一个cache策略
            using (var entry = _memoryCache.CreateEntry(cacheKeyParent))
            {
                //当前key对应的值
                entry.Value = "parent" + DateTime.Now;

                //当前key对应的回调事件
                entry.RegisterPostEvictionCallback(MyCallback, this);

                //基于些key创建一个依赖缓存
                _memoryCache.Set(cacheKeyChild, "child" + DateTime.Now, new CancellationChangeToken(cts.Token));
            }

            string ParentCachedTime = _memoryCache.Get<string>(cacheKeyParent);
            string ChildCachedTime = _memoryCache.Get<string>(cacheKeyChild);
            string callBackMsg = _memoryCache.Get<string>("callbackMessage");
            Console.WriteLine("第一次获取");
            Console.WriteLine(ParentCachedTime + "|" + ChildCachedTime + "|" + callBackMsg);

            //移除parentKey
            _memoryCache.Get<CancellationTokenSource>(DependentCTS).Cancel();
            Thread.Sleep(1000);

            ParentCachedTime = _memoryCache.Get<string>(cacheKeyParent);
            ChildCachedTime = _memoryCache.Get<string>(cacheKeyChild);
            callBackMsg = _memoryCache.Get<string>("callbackMessage");
            Console.WriteLine("第二次获取");
            Console.WriteLine(ParentCachedTime + "|" + ChildCachedTime + "|" + callBackMsg);
        }
    }
}
