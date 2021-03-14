using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Sharky.Cache
{
    public class JsonDistributedCacheSerializer : IDistributedCacheSerializer
    {
        public byte[] GetBytes(object value)
        {
            return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value));
        }

        public T ToObject<T>(byte[] source)
        {
            return (T)JsonSerializer.Deserialize(Encoding.UTF8.GetString(source), typeof(T));
        }
    }
}
