using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharky.Core.Modularity
{
    public interface IOnApplicationInitialization
    {
        void OnApplicationInitialization(ApplicationInitializationContext context);
    }
}
