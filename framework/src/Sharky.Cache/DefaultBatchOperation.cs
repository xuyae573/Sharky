using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sharky.Cache
{
    public abstract class DefaultBatchOperation : IBatchOperations
    {
        public Task RemoveByPrefixAsync(string prefix)
        {
           return Task.CompletedTask;
        }

        public Task ClearAllCacheItems()
        {
            return Task.CompletedTask; 
        }
    }
}
