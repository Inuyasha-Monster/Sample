using Sample.Core.NetFrameworkExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Cache
{
    public class RuntimeCacheManager : ICacheManager
    {
        private static MemoryCache CacheItems
        {
            get
            {
                return MemoryCache.Default;
            }
        }

        public void Clear()
        {
            if (CacheItems.Any())
            {
                foreach (var item in CacheItems)
                {
                    this.Remove(item.Key);
                }
            }
        }

        public bool Contains(string key)
        {
            if (key.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(key));
            }
            return CacheItems.Contains(key);
        }

        public T Get<T>(string key)
        {
            if (key.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (!Contains(key))
            {
                return default(T);
            }
            var t = (T)MemoryCache.Default.Get(key);
            return t;
        }

        public void Remove(string key)
        {
            if (key.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (!Contains(key)) return;
            MemoryCache.Default.Remove(key);
        }

        public void Set(string key, object value, TimeSpan cacheTime)
        {
            MemoryCache.Default.Set(key, value, new CacheItemPolicy { SlidingExpiration = cacheTime });
        }
    }
}
