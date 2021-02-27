using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharky.Core.Data.ObjectExtend
{
    public interface ICreationAuditedEntity
    {
        string CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
    }
}
