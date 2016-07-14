using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Hooks
{
    public interface IPostDeleteHook<TEntity>: IPostActionHook<TEntity> where TEntity : class
    {
    }
}
