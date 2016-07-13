using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Hooks
{
    public class SoftDeletePostLoadHook<TEntity> : IPostLoadHook<TEntity> where TEntity : class
    {
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
