using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Hooks
{
    /// <summary>
    /// SystemInfoPostActionHook
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="EFRepository.Hooks.IPostActionHook{TEntity}" />
    public class SystemInfoPostActionHook<TEntity> : IPostActionHook<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets the user helper.
        /// </summary>
        /// <value>
        /// The user helper.
        /// </value>
        public IUserHelper UserHelper { get; private set; }

        public IDatetimeHelper DatetimeHelper { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemInfoPostActionHook{TEntity}"/> class.
        /// </summary>
        /// <param name="userHelper">The user helper.</param>
        public SystemInfoPostActionHook(IUserHelper userHelper, IDatetimeHelper datetimeHelper)
        {
            this.UserHelper = userHelper;
            this.DatetimeHelper = datetimeHelper;
        }

        /// <summary>
        /// Executes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="context">The context.</param>
        public void Execute(TEntity entity, HookContext context)
        {
            if (!(entity is ISystemInfo))
            {
                return;
            }

            var systemInfoData = entity as ISystemInfo;
            var entry = context.DbContext.Entry(entity);

            if (entry.State == EntityState.Added)
            {
                var currentTime = this.DatetimeHelper.GetCurrentTime();
                var userName = this.UserHelper.GetUserName();

                systemInfoData.CreatedAt = currentTime;
                systemInfoData.CreatedBy = userName;
                systemInfoData.UpdatedAt = currentTime;
                systemInfoData.UpdatedBy = userName;
            }

            if (entry.State == EntityState.Modified)
            {
                var currentTime = this.DatetimeHelper.GetCurrentTime();
                var userName = this.UserHelper.GetUserName();

                systemInfoData.UpdatedAt = currentTime;
                systemInfoData.UpdatedBy = userName;
            }
        }        
    }
}
