﻿using System.Collections.Generic;

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
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}