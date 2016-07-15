using System;
using System.Collections;
using System.Data.Entity;

namespace EFRepository.Hooks
{
    /// <summary>
    /// HookContext
    /// </summary>
    public class HookContext
    {
        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        public object Entity { get; set; }

        /// <summary>
        /// Gets or sets the database context.
        /// </summary>
        /// <value>
        /// The database context.
        /// </value>
        public DbContext DbContext { get; set; }
    }
}