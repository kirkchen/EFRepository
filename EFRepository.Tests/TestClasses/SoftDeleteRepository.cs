using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Tests.TestClasses
{
    /// <summary>
    /// SoftDeleteRepository
    /// </summary>
    /// <seealso cref="EFRepository.GenericRepository{System.Int32, EFRepository.Tests.TestClasses.SoftDeleteData}" />
    public class SoftDeleteRepository : GenericRepository<int, SoftDeleteData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SoftDeleteRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SoftDeleteRepository(TestDbContext context)
            : base(context)
        {
        }
    }
}
