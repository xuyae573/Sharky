using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharky.Core.Data.ObjectExtend;

namespace Sharky.Domain.Entities
{
    public abstract class CreationAuditedAggregateRoot: AggregateRoot, ICreationAuditedEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public abstract class CreationAuditedAggregateRoot<TKey> : AggregateRoot<TKey>, ICreationAuditedEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
       
    }
}
