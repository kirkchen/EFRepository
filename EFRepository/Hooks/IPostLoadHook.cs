using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Hooks
{
    public interface IPostLoadHook<TEntity> where TEntity: class
    {
        IQueryable<TEntity> Execute(IQueryable<TEntity> entity, HookContext context);
    }
}
