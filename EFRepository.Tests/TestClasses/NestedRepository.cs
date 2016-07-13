using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Tests.TestClasses
{
    /// <summary>
    /// NestedRepository
    /// </summary>
    /// <seealso cref="EFRepository.GenericRepository{System.Int32, EFRepository.Tests.TestClasses.NestedData}" />
    /// <seealso cref="EFRepository.IRepository{System.Int32, EFRepository.Tests.TestClasses.NestedData}" />
    public class NestedRepository : GenericRepository<int, NestedData>, IRepository<int, NestedData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NestedRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public NestedRepository(TestDbContext context)
            : base(context)
        {
        }

        public override void Update(NestedData data)
        {
            //foreach (var level2data in data.Children)
            //{
            //    this.DbContext.Set<NestedLevel2Data>().Attach(level2data);

            //    var entry = this.DbContext.Entry(level2data);
            //    entry.State = System.Data.Entity.EntityState.Modified;
            //}

            base.Update(data);
        }
    }
}
