using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Sharky.Core.Modularity.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddSharkyModule(this IServiceCollection services, Assembly[] assemblies)
        {
            services.AddSingleton<IModuleLoader, ModuleLoader>();
            var loader = services.GetSingletonInstanceOrNull<IModuleLoader>();
            var modules = loader.LoadModules(assemblies);
            foreach (var item in modules)
            {
                item.ConfigureServices(new ConfigureServicesContext(services));
            }
        }
        public static T GetSingletonInstanceOrNull<T>(this IServiceCollection services)
        {
            var servictType = services
                .FirstOrDefault(d => d.ServiceType == typeof(T) && d.Lifetime == ServiceLifetime.Singleton);
            if (servictType?.ImplementationInstance != null)
            {
                return (T)servictType.ImplementationInstance;
            }

            if (servictType?.ImplementationFactory != null)
            {
                return (T)servictType.ImplementationFactory.Invoke(null);
            }

            return default(T);
        }
    }
}
