using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Tests.TestClasses
{
    /// <summary>
    /// SystemInfoRepository
    /// </summary>
    /// <seealso cref="EFRepository.GenericRepository{System.Int32, EFRepository.Tests.TestClasses.SystemInfoData}" />
    /// <seealso cref="EFRepository.IRepository{System.Int32, EFRepository.Tests.TestClasses.SystemInfoData}" />
    public class SystemInfoRepository : GenericRepository<int, SystemInfoData>, IRepository<int, SystemInfoData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemInfoRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SystemInfoRepository(TestDbContext context)
            : base(context)
        {
        }
    }
}
