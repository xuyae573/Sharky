using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharky.Application.Contracts
{
    public abstract class EntityDto : IEntityDto 
    {
        public override string ToString()
        {
            return $"[DTO: {GetType().Name}]";
        }
    }

    public abstract class EntityDto<TKey> : EntityDto, IEntityDto<TKey>
    {
        /// <summary>
        /// Id of the entity.
        /// </summary>
        public TKey Id { get; set; }

        public override string ToString()
        {
            return $"[DTO: {GetType().Name}] Id = {Id}";
        }
    }
}
