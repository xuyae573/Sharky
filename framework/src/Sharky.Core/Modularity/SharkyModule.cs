using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharky.Core.Modularity
{
    public abstract class SharkyModule : ISharkyModule, IOnApplicationInitialization
    {
        public void ConfigureServices(ConfigureServicesContext context)
        {
            throw new NotImplementedException();
        }

        public void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
