using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharky.Core.Data.ObjectExtend;

namespace Sharky.Domain.Entities
{
    public abstract class CreationAuditedEntity : Entity, ICreationAuditedEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public abstract class CreationAuditedEntity<TKey> : Entity<TKey>, ICreationAuditedEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
       
    }
}
