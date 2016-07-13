namespace EFRepository.Hooks
{
    public interface IPostActionHook<TEntity> where TEntity : class
    {
        void Execute(TEntity entity, HookContext context);
    }
}