using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EFRepository
{
    /// <summary>
    /// IRepository
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Adds the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        void Add(TEntity data);

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="datalist">The datalist.</param>
        void AddRange(IEnumerable<TEntity> datalist);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns>data list</returns>
        IEnumerable<TEntity> GetList();

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>data list</returns>
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> condition);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>data</returns>
        TEntity Get(object id);

        /// <summary>
        /// Gets the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>data</returns>
        TEntity Get(Expression<Func<TEntity, bool>> condition);

        /// <summary>
        /// Updates the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        void Update(TEntity data);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(object id);

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}