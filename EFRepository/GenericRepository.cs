using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
