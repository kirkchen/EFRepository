using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository
{
    /// <summary>
    /// UnitOfWork
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class UnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>
        /// The database context.
        /// </value>
        public DbContext DbContext { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(DbContext context)
        {
            this.DbContext = context;
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
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.DbContext = null;
        }
    }
}
