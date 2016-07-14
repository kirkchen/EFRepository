using EFRepository.Hooks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        protected DbContext DbContext { get; set; }

        /// <summary>
        /// Gets or sets the post action hooks.
        /// </summary>
        /// <value>
        /// The post action hooks.
        /// </value>
        public ICollection<IPostDeleteHook<TEntity>> PostDeleteHooks { get; set; }

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
            this.PostDeleteHooks = new List<IPostDeleteHook<TEntity>>();
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
            if(hook is IPostDeleteHook<TEntity>)
            {
                var deleleHook = hook as IPostDeleteHook<TEntity>;
                this.PostDeleteHooks.Add(deleleHook);
            }            
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

            var datatype = typeof(TEntity);

            var entry = this.DbContext.Entry(data);
            entry.State = EntityState.Modified;

            TypeDescriptor.AddProvider(new AssociatedMetadataTypeTypeDescriptionProvider(datatype), datatype);
            var properties = TypeDescriptor.GetProperties(datatype);

            foreach (PropertyDescriptor property in properties)
            {
                var isChildList = property.PropertyType.GetInterfaces()
                                                       .Any(t => t.IsGenericType
                                                                 && t.GetGenericTypeDefinition() == typeof(IEnumerable<>));
                isChildList = isChildList && property.PropertyType.IsGenericType;
                if (!isChildList)
                {
                    continue;
                }

                var childType = property.PropertyType.GenericTypeArguments[0];
                var children = property.GetValue(data) as IEnumerable;
                foreach (var child in children)
                {
                    this.DbContext.Set(childType).Attach(child);

                    var childEntry = this.DbContext.Entry(child);
                    childEntry.State = EntityState.Modified;
                }
            }                              
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

            foreach (var hook in this.PostDeleteHooks)
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
    }
}
