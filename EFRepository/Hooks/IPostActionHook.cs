namespace EFRepository.Hooks
{
    /// <summary>
    /// IPostActionHook
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IPostActionHook<TEntity> where TEntity : class
    {
        /// <summary>
        /// Executes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="context">The context.</param>
        void Execute(TEntity entity, HookContext context);
    }
}