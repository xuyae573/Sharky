using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharky.Core.Modularity
{
    public interface ISharkyModule
    {
        void ConfigureServices(ConfigureServicesContext context);
    }
}
