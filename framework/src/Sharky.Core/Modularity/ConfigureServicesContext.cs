using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Sharky.Core.Modularity.Extensions;

namespace Sharky.Core.Modularity
{
    public class ConfigureServicesContext
    {
        public IServiceCollection Services { get; }

        public ConfigureServicesContext(IServiceCollection services)
        {
            Services = services;
        }

        public IConfiguration GetConfiguration()
        {
            var implemenInstance = Services.GetSingletonInstanceOrNull<IConfiguration>();
            return implemenInstance;
        }
    }
}
