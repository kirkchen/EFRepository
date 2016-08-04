using EFRepository.Hooks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository
{
    /// <summary>
    /// GenericRepository
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class GenericRepository<TKey, TEntity> : IRepository<TKey, TEntity> where TEntity : class, IEntity<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>
        /// The database context.
        /// </value>
        internal DbContext DbContext { get; set; }

        /// <summary>
        /// Gets or sets the post action hooks.
        /// </summary>
        /// <value>
        /// The post action hooks.
        /// </value>
        public ICollection<IPostActionHook<TEntity>> PostActionHooks { get; set; }

        /// <summary>
        /// Gets or sets the post load hooks.
        /// </summary>
        /// <value>
        /// The post load hooks.
        /// </value>
        public ICollection<IPostLoadHook<TEntity>> PostLoadHooks { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GenericRepository(DbContext context)
        {
            this.DbContext = context;
            this.PostActionHooks = new List<IPostActionHook<TEntity>>();
            this.PostLoadHooks = new List<IPostLoadHook<TEntity>>();
        }

        /// <summary>
        /// Registers the post load hook.
        /// </summary>
        /// <param name="hook">The hook.</param>
        public void RegisterPostLoadHook(IPostLoadHook<TEntity> hook)
        {
            this.PostLoadHooks.Add(hook);
        }

        /// <summary>
        /// Registers the post action hook.
        /// </summary>
        /// <param name="hook">The hook.</param>
        public void RegisterPostActionHook(IPostActionHook<TEntity> hook)
        {
            this.PostActionHooks.Add(hook);
        }

        /// <summary>
        /// Adds the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public virtual void Add(TEntity data)
        {
            this.DbContext.Set<TEntity>().Add(data);
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="datalist">The datalist.</param>
        public virtual void AddRange(IEnumerable<TEntity> datalist)
        {
            foreach (var data in datalist)
            {
                this.Add(data);
            }
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns>data list</returns>
        public virtual IEnumerable<TEntity> GetList()
        {
            var query = this.DbContext.Set<TEntity>()
                                      .AsQueryable();
            
            foreach (var hook in this.PostLoadHooks)
            {
                query = hook.Execute(query, new HookContext()
                {
                    DbContext = this.DbContext,
                    Entity = query
                });
            }

            return query.ToList();
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="condition">The where.</param>
        /// <returns>data list</returns>
        public virtual IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> condition)
        {
            var query = this.DbContext.Set<TEntity>()
                                      .Where(condition);

            foreach (var hook in this.PostLoadHooks)
            {
                query = hook.Execute(query, new HookContext()
                {
                    DbContext = this.DbContext,
                    Entity = query
                });
            }

            return query.ToList();
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>data</returns>
        public virtual TEntity Get(TKey id)
        {
            var query = this.DbContext.Set<TEntity>()
                                      .Where(i => i.Id.Equals(id));

            foreach (var hook in this.PostLoadHooks)
            {
                query = hook.Execute(query, new HookContext()
                {
                    DbContext = this.DbContext,
                    Entity = query
                });
            }

            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>data</returns>
        public virtual TEntity Get(Expression<Func<TEntity, bool>> condition)
        {
            var query = this.DbContext.Set<TEntity>()
                                      .Where(condition);

            foreach (var hook in this.PostLoadHooks)
            {
                query = hook.Execute(query, new HookContext()
                {
                    DbContext = this.DbContext,
                    Entity = query
                });
            }

            return query.FirstOrDefault();
        }

        /// <summary>
        /// Updates the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public virtual void Update(TEntity data)
        {
            this.DbContext.Set<TEntity>().Attach(data);

            var entry = this.DbContext.Entry(data);
            entry.State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public virtual void Delete(TKey id)
        {
            var data = this.Get(id);

            this.DbContext.Set<TEntity>()
                          .Remove(data);

            foreach (var hook in this.PostActionHooks)
            {
                hook.Execute(data, new HookContext()
                {
                    DbContext = this.DbContext,
                    Entity = data
                });
            };
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns>the count of effected rows</returns>
        public int SaveChanges()
        {
            var result = this.DbContext.SaveChanges();

            return result;
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>        
        public async void SaveChangesAsync()
        {
            var result = await this.DbContext.SaveChangesAsync();            
        }
    }
}
