using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Hooks
{
    /// <summary>
    /// IPostLoadHook
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IPostLoadHook<TEntity> where TEntity: class
    {
        /// <summary>
        /// Executes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        IQueryable<TEntity> Execute(IQueryable<TEntity> entity, HookContext context);
    }
}
