using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sharky.Cache
{
    public interface IBatchOperations 
    {
        Task RemoveByPrefixAsync(string prefix);
        Task ClearAllCacheItems();
    }
}
