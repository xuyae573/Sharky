﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sharky.Domain.Entities
{
    public interface IEntity
    {
        /// <summary>
        /// Returns an array of ordered keys for this entity.
        /// </summary>
        /// <returns></returns>
        object[] GetKeys();
    }

    /// <summary>
    /// Defines an entity with a single primary key with "Id" property.
    /// </summary>
    /// <typeparam name="TKey">Type of the primary key of the entity</typeparam>
    public interface IEntity<TKey> : IEntity
    {
        /// <summary>
        /// Unique identifier for this entity.
        /// </summary>
        TKey Id { get; }
    }
}
