using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository
{
    /// <summary>
    /// IUserHelper
    /// </summary>
    public interface IUserHelper
    {
        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <returns>User name</returns>
        string GetUserName();
    }
}
