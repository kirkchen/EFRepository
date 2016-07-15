using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Hooks
{
    /// <summary>
    /// SoftDeletePostDeleteHook
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="EFRepository.Hooks.IPostDeleteHook{TEntity}" />
    public class SoftDeletePostDeleteHook<TEntity> : IPostDeleteHook<TEntity> where TEntity : class
    {
        /// <summary>
        /// Executes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="context">The context.</param>
        public void Execute(TEntity entity, HookContext context)
        {
            if (!(entity is ISoftDelete))
            {
                return;
            }

            var entry = context.DbContext.Entry(entity);
            if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;

                var softDeleteData = entity as ISoftDelete;
                softDeleteData.IsDelete = true;
            }
        }
    }
}
