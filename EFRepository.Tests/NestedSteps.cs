using EFRepository.Hooks;
using EFRepository.Tests.TestClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace EFRepository.Tests
{
    [Binding]
    [Scope(Feature = "Nested")]
    public class NestedSteps
    {
        public string ConnectionString { get; private set; }

        public TestDbContext DbContext { get; private set; }

        public NestedRepository Repository { get; private set; }

        public Expression<Func<NestedData, bool>> Condition { get; set; }

        public NestedData DataItem { get; private set; }

        public IEnumerable<NestedData> DataList { get; private set; }

        [BeforeScenario]
        public void BeforeScenario()
        {
            this.ConnectionString = Environment.GetEnvironmentVariable("TestDb") ?? "TestDb";

            this.DbContext = new TestDbContext(ConnectionString);
            this.DbContext.Database.Delete();

            this.Repository = new NestedRepository(this.DbContext);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            this.DbContext.Dispose();
        }

        [Given(@"I have nested datas")]
        public void GivenIHaveNestedDatas(Table table)
        {
            this.DataList = table.CreateSet<NestedData>();
        }

        [Given(@"the nested data with id ""(.*)"" has level 2 data")]
        public void GivenTheNestedDataWithIdHasLevelData(int id, Table table)
        {
            var level2Datas = table.CreateSet<NestedLevel2Data>();
            var parentData = this.DataList.Where(i => i.Id == id)
                                          .First();

            parentData.Children = new List<NestedLevel2Data>();
            foreach (var level2data in level2Datas)
            {                
                parentData.Children.Add(level2data);
            }
        }

        [Given(@"database has nested datas")]
        public void GivenDatabaseHasNestedDatas(Table table)
        {
            var dataList = table.CreateSet<NestedData>();

            using (var dbContext = new TestDbContext(this.ConnectionString))
            {
                dbContext.NestedDatas.AddRange(dataList);
                dbContext.SaveChanges();
            }
        }

        [Given(@"database has nested level 2 data")]
        public void GivenDatabaseHasNestedLevelData(Table table)
        {
            var dataList = table.CreateSet<NestedLevel2Data>();

            using (var dbContext = new TestDbContext(this.ConnectionString))
            {
                dbContext.NestedLevel2Datas.AddRange(dataList);
                dbContext.SaveChanges();
            }
        }

        [Given(@"Register nested data update hook in generic repository")]
        public void GivenRegisterNestedDataUpdateHookInGenericRepository()
        {            
            this.Repository.RegisterPostActionHook(new NestedDataPostUpdateHook<NestedData>());
        }

        [When(@"I use generic repository to add data")]
        public void WhenIUseGenericRepositoryToAddData()
        {
            this.Repository.Add(this.DataList.First());
        }

        [When(@"I save the changes")]
        public void WhenISaveTheChanges()
        {
            this.Repository.SaveChanges();
        }

        [When(@"I use generic repository update data")]
        public void WhenIUseGenericRepositoryUpdateData()
        {
            var data = this.DataList.First();

            this.Repository.Update(data);
        }

        [Then(@"database should exists nested datas")]
        public void ThenDatabaseShouldExistsNestedDatas(Table table)
        {
            using (var dbContext = new TestDbContext(this.ConnectionString))
            {
                var datalist = dbContext.NestedDatas.ToList();

                table.CompareToSet(datalist);
            }
        }

        [Then(@"database should exists nested level 2 datas")]
        public void ThenDatabaseShouldExistsNestedLevelDatas(Table table)
        {
            using (var dbContext = new TestDbContext(this.ConnectionString))
            {
                var datalist = dbContext.NestedLevel2Datas.ToList();

                table.CompareToSet(datalist);
            }
        }

    }
}
