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
        /// Gets or sets the nested datas.
        /// </summary>
        /// <value>
        /// The nested datas.
        /// </value>
        public DbSet<NestedData> NestedDatas { get; set; }

        /// <summary>
        /// Gets or sets the nested level2 datas.
        /// </summary>
        /// <value>
        /// The nested level2 datas.
        /// </value>
        public DbSet<NestedLevel2Data> NestedLevel2Datas { get; set; }

        /// <summary>
        /// Gets or sets the nested level3 datas.
        /// </summary>
        /// <value>
        /// The nested level3 datas.
        /// </value>
        public DbSet<NestedLevel3Data> NestedLevel3Datas { get; set; }
    }
}
