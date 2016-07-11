using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Tests.TestClasses
{
    /// <summary>
    /// TestRepository
    /// </summary>
    /// <seealso cref="EFRepository.GenericRepository{EFRepository.Tests.TestClasses.TestData}" />
    public class TestRepository : GenericRepository<int, TestData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public TestRepository(TestDbContext context)
            : base(context)
        {
        }
    }
}
