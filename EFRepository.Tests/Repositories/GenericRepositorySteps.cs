using EFRepository.Tests.TestClasses;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EFRepository.Tests.Repositories
{
    [Binding]
    [Scope(Feature = "GenericRepository")]
    public class GenericRepositorySteps
    {
        public string ConnectionString { get; private set; }

        public TestDbContext DbContext { get; private set; }

        public TestRepository Repository { get; private set; }

        public Expression<Func<TestData, bool>> Condition { get; set; }

        public TestData DataItem { get; private set; }

        public IEnumerable<TestData> DataList { get; private set; }

        [BeforeScenario]
        public void BeforeScenario()
        {
            this.ConnectionString = Environment.GetEnvironmentVariable("TestDb") ?? "TestDb";

            this.DbContext = new TestDbContext(ConnectionString);
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
            this.DataList = table.CreateSet<TestData>();
        }

        [Given(@"database has test datas")]
        public void GivenDatabaseHasTestDatas(Table table)
        {
            var dataList = table.CreateSet<TestData>();

            using (var dbContext = new TestDbContext(this.ConnectionString))
            {
                dbContext.TestDatas.AddRange(dataList);
                dbContext.SaveChanges();
            }
        }

        [Given(@"test datas content field should contains ""(.*)""")]
        public void GivenTestDatasContentFieldShouldContains(string condition)
        {
            this.Condition = (data) => data.Content.Contains(condition);
        }

        [Given(@"the data I want to update is")]
        public void GivenTheDataIWantToUpdateIs(Table table)
        {
            this.DataItem = table.CreateInstance<TestData>();
        }

        [When(@"I use generic repository to add data")]
        public void WhenIUseGenericRepositoryToAddData()
        {
            this.Repository.Add(this.DataList.First());
        }

        [When(@"I use generic repository to add datalist")]
        public void WhenIUseGenericRepositoryToAddDatalist()
        {
            this.Repository.AddRange(this.DataList);
        }

        [When(@"I save the changes")]
        public void WhenISaveTheChanges()
        {
            this.Repository.SaveChanges();
        }

        [When(@"I use generic repository get data list from database")]
        public void WhenIUseGenericRepositoryGetDataListFromDatabase()
        {
            this.DataList = this.Repository.GetList();
        }

        [When(@"I use generic repository get data from database by id ""(.*)""")]
        public void WhenIUseGenericRepositoryGetDataFromDatabaseById(int id)
        {
            this.DataItem = this.Repository.Get(id);

            this.DataList = new List<TestData>() { this.DataItem };
        }

        [When(@"I use generic repository get data list with condition from database")]
        public void WhenIUseGenericRepositoryGetDataListWithConditionFromDatabase()
        {
            this.DataList = this.Repository.GetList(this.Condition);
        }

        [When(@"I use generic repository get data from database with conditon")]
        public void WhenIUseGenericRepositoryGetDataFromDatabaseWithConditon()
        {
            this.DataItem = this.Repository.Get(this.Condition);

            this.DataList = new List<TestData>() { this.DataItem };
        }

        [When(@"I use generic repository update data")]
        public void WhenIUseGenericRepositoryUpdateData()
        {
            this.Repository.Update(this.DataItem);
        }

        [When(@"I use generic repository delete data with id ""(.*)""")]
        public void WhenIUseGenericRepositoryDeleteDataWithId(int id)
        {
            this.Repository.Delete(id);
        }

        [Then(@"database should exists test datas")]
        public void ThenDatabaseShouldExistsTestDatas(Table table)
        {
            using (var dbContext = new TestDbContext(this.ConnectionString))
            {
                var datalist = dbContext.TestDatas.ToList();

                table.CompareToSet(datalist);
            }
        }

        [Then(@"the data list I get should be")]
        public void ThenTheDataListIGetShouldBe(Table table)
        {
            table.CompareToSet(this.DataList);
        }
    }
}
