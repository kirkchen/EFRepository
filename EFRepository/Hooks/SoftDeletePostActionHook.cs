using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Hooks
{
    public class SoftDeletePostActionHook<TEntity> : IPostActionHook<TEntity> where TEntity : class
    {
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
