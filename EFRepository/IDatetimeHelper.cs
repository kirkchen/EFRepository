using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository
{
    /// <summary>
    /// IDatetimeHelper
    /// </summary>
    public interface IDatetimeHelper
    {
        /// <summary>
        /// Gets the current time.
        /// </summary>
        /// <returns></returns>
        DateTime GetCurrentTime();
    }
}
