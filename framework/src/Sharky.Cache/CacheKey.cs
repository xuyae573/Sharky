using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sharky.Cache
{
    public class CacheKey
    {
        internal static readonly string SHA256 = "SHA256";

        public CacheKey(object cacheItemKey, string prefix)
        {
            this.cacheItemKey = cacheItemKey;
            this.prefix = prefix;
        }

        private string prefix { get; set; }
        private object cacheItemKey { get; set; }


        public virtual string Create()
        {
            var cacheKey = string.Empty;
            if (cacheItemKey == null)
                return cacheKey;

            var jsonData = JsonSerializer.Serialize(cacheItemKey);
            cacheKey = HashHelper.CreateHash(Encoding.UTF8.GetBytes(jsonData), SHA256);
            return $"{prefix} : {cacheKey}";
        }

    }
}
