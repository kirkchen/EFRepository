using EFRepository.Tests.TestClasses;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace EFRepository.Tests
{
    [Binding]
    [Scope(Feature = "GenericRepository")]
    public class GenericRepositorySteps
    {
        public TestDbContext DbContext { get; private set; }

        public TestRepository Repository { get; private set; }

        public TestData DataItem { get; private set; }

        [BeforeScenario]
        public void BeforeScenario()
        {
            this.DbContext = new TestDbContext();
            this.DbContext.Database.Delete();

            this.Repository = new TestRepository(this.DbContext);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            this.DbContext.Dispose();
        }

        [Given(@"I have test datas")]
        public void GivenIHaveTestDatas(Table table)
        {
            this.DataItem = table.CreateInstance<TestData>();
        }
        
        [When(@"I use generic repository to add data")]
        public void WhenIUseGenericRepositoryToAddData()
        {
            this.Repository.Add(this.DataItem);
        }
        
        [When(@"I save the changes")]
        public void WhenISaveTheChanges()
        {
            this.Repository.SaveChanges();
        }
        
        [Then(@"database should exists test datas")]
        public void ThenDatabaseShouldExistsTestDatas(Table table)
        {
            using (var dbContext = new TestDbContext())
            {
                var datalist = dbContext.TestDatas.ToList();

                table.CompareToSet(datalist);
            }
        }
    }
}
