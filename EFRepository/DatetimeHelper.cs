using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository
{
    /// <summary>
    /// DatetimeHelper
    /// </summary>
    /// <seealso cref="EFRepository.IDatetimeHelper" />
    public class DatetimeHelper : IDatetimeHelper
    {
        /// <summary>
        /// Gets the current time.
        /// </summary>
        /// <returns>current time</returns>
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
