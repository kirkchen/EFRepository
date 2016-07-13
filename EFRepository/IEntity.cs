using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository
{
    /// <summary>
    /// IEntity
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public interface IEntity<TKey> where TKey: IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        TKey Id { get; set; }
    }
}
