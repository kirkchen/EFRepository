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
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>
        /// The database context.
        /// </value>
        internal DbContext DbContext { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GenericRepository(DbContext context)
        {
            this.DbContext = context;
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
            var query = this.DbContext.Set<TEntity>();

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

            return query.ToList();
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>data</returns>
        public virtual TEntity Get(object id)
        {
            var query = this.DbContext.Set<TEntity>()
                                      .Find(id);

            return query;
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
