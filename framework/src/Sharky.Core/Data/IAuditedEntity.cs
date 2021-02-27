using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharky.Core.Data.ObjectExtend;

namespace Sharky.Core.Data
{
    public interface IAuditedEntity : ICreationAuditedEntity, IModificationAuditedEntity
    {

    }
}
