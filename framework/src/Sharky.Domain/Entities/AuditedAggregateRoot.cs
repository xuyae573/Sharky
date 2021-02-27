using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharky.Core.Data;
using Sharky.Core.Data.ObjectExtend;

namespace Sharky.Domain.Entities
{
    public abstract class AuditedAggregateRoot : CreationAuditedAggregateRoot, IModificationAuditedEntity
    {
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }

    public abstract class AuditedAggregateRoot<TKey> : CreationAuditedAggregateRoot<TKey>, IModificationAuditedEntity
    {
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
