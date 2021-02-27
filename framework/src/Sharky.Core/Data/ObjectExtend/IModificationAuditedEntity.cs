using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharky.Core.Data.ObjectExtend
{
    public interface IModificationAuditedEntity
    {
        /// <summary>
        /// Last modifier user for this entity.
        /// </summary>
        string LastUpdatedBy { get; set; }

        /// <summary>
        /// The last modified time for this entity.
        /// </summary>
        DateTime? LastUpdatedOn { get; set; }
    }
}
