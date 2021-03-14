using System;
using System.Collections.Generic;
using System.Text;

namespace Sharky.Cache
{
    public interface IDistributedCacheSerializer
    {
        public byte[] GetBytes(object value);
        public T ToObject<T>(byte[] source);
    }
}
