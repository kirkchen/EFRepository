using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Hooks
{
    /// <summary>
    /// IPostUpdateHook
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="EFRepository.Hooks.IPostActionHook{TEntity}" />
    public interface IPostUpdateHook<TEntity>: IPostActionHook<TEntity> where TEntity : class
    {
    }
}
