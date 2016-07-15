using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Hooks
{
    /// <summary>
    /// SoftDeletePostLoadHook
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="EFRepository.Hooks.IPostLoadHook{TEntity}" />
    public class SoftDeletePostLoadHook<TEntity> : IPostLoadHook<TEntity> where TEntity : class
    {
        /// <summary>
        /// Executes the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public IQueryable<TEntity> Execute(IQueryable<TEntity> query, HookContext context)
        {
            if (query is IQueryable<ISoftDelete>)
            {
                var softDeleteQuery = query as IQueryable<ISoftDelete>;
                softDeleteQuery = softDeleteQuery.Where(i => !i.IsDelete);

                query = softDeleteQuery.OfType<TEntity>().AsQueryable();
            }

            return query;
        }
    }
}
