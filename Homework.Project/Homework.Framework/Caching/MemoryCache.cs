using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Homework.Framework.Caching
{
    public partial class MemoryCache : ICache
    {
        public MemoryCache() { }

        protected ObjectCache Cache { get => System.Runtime.Caching.MemoryCache.Default; }

        public object this[string key] { get => Cache.Get(key); set => Add(key, value); }

        public int Count => (int)this.Cache.GetCount();

        public void Add(string key, object data, int cacheTime = 30)
        {
            if (data == null)
                return;
            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            Cache.Add(new CacheItem(key, data), policy);
        }

        public bool Contains(string key)
        {
            return Cache.Contains(key);
        }

        public T Get<T>(string key)
        {
            if (this.Cache.Contains(key))
                return (T)Cache[key];
            return default(T);
        }

        public void Remove(string key)
        {
            var regex = new Regex(key, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<String>();

            foreach (var item in Cache)
                if (regex.IsMatch(item.Key))
                    keysToRemove.Add(item.Key);

            foreach (string item in keysToRemove)
            {
                Remove(item);
            }
        }

        public void RemoveAll()
        {
            foreach (var item in Cache)
                Remove(item.Key);
        }
    }
}
