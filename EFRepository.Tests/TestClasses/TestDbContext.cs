using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Tests.TestClasses
{
    /// <summary>
    /// TestDbContext
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class TestDbContext: DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestDbContext"/> class.
        /// </summary>
        public TestDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        /// <summary>
        /// Gets or sets the test datas.
        /// </summary>
        /// <value>
        /// The test datas.
        /// </value>
        public DbSet<TestData> TestDatas { get; set; }

        /// <summary>
        /// Gets or sets the soft delete datas.
        /// </summary>
        /// <value>
        /// The soft delete datas.
        /// </value>
        public DbSet<SoftDeleteData> SoftDeleteDatas { get; set; }

        /// <summary>
        /// Gets or sets the system information datas.
        /// </summary>
        /// <value>
        /// The system information datas.
        /// </value>
        public DbSet<SystemInfoData> SystemInfoDatas { get; set; }
    }
}
