using EFRepository.Hooks;
using EFRepository.Tests.TestClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace EFRepository.Tests.Hooks
{
    [Binding]
    [Scope(Feature = "SoftDelete")]
    public class SoftDeleteSteps
    {
        public string ConnectionString { get; private set; }

        public TestDbContext DbContext { get; private set; }

        public SoftDeleteRepository Repository { get; private set; }

        public Expression<Func<SoftDeleteData, bool>> Condition { get; set; }

        public SoftDeleteData DataItem { get; private set; }

        public IEnumerable<SoftDeleteData> DataList { get; private set; }

        [BeforeScenario]
        public void BeforeScenario()
        {
            this.ConnectionString = Environment.GetEnvironmentVariable("TestDb") ?? "TestDb";

            this.DbContext = new TestDbContext(ConnectionString);
            this.DbContext.Database.Delete();

            this.Repository = new SoftDeleteRepository(this.DbContext);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            this.DbContext.Dispose();
        }

        [Given(@"database has soft delete datas")]
        public void GivenDatabaseHasSoftDeleteDatas(Table table)
        {
            var dataList = table.CreateSet<SoftDeleteData>();

            using (var dbContext = new TestDbContext(this.ConnectionString))
            {
                dbContext.SoftDeleteDatas.AddRange(dataList);
                dbContext.SaveChanges();
            }
        }

        [Given(@"Register soft delete hook in generic repository")]
        public void GivenRegisterSoftDeleteHookInGenericRepository()
        {
            this.Repository.RegisterPostLoadHook(new SoftDeletePostLoadHook<SoftDeleteData>());
            this.Repository.RegisterPostActionHook(new SoftDeletePostActionHook<SoftDeleteData>());
        }

        [Given(@"test datas content field should contains ""(.*)""")]
        public void GivenTestDatasContentFieldShouldContains(string condition)
        {
            this.Condition = (data) => data.Content.Contains(condition);
        }

        [When(@"I use generic repository delete data with id ""(.*)""")]
        public void WhenIUseGenericRepositoryDeleteDataWithId(int id)
        {
            this.Repository.Delete(id);
        }

        [When(@"I use generic repository get data list from database")]
        public void WhenIUseGenericRepositoryGetDataListFromDatabase()
        {
            this.DataList = this.Repository.GetList();
        }

        [When(@"I use generic repository get data list with condition from database")]
        public void WhenIUseGenericRepositoryGetDataListWithConditionFromDatabase()
        {
            this.DataList = this.Repository.GetList(this.Condition);
        }

        [When(@"I use generic repository get data from database by id ""(.*)""")]
        public void WhenIUseGenericRepositoryGetDataFromDatabaseById(int id)
        {
            this.DataItem = this.Repository.Get(id);
            
            if (this.DataItem != null)
            {
                this.DataList = new List<SoftDeleteData>() { this.DataItem };
            }
        }

        [When(@"I use generic repository get data from database with conditon")]
        public void WhenIUseGenericRepositoryGetDataFromDatabaseWithConditon()
        {
            this.DataItem = this.Repository.Get(this.Condition);

            if (this.DataItem != null)
            {
                this.DataList = new List<SoftDeleteData>() { this.DataItem };
            }
        }


        [When(@"I save the changes")]
        public void WhenISaveTheChanges()
        {
            this.Repository.SaveChanges();
        }

        [Then(@"database should exists test datas")]
        public void ThenDatabaseShouldExistsTestDatas(Table table)
        {
            using (var dbContext = new TestDbContext(this.ConnectionString))
            {
                var datalist = dbContext.SoftDeleteDatas.ToList();

                table.CompareToSet(datalist);
            }
        }

        [Then(@"the data list I get should be")]
        public void ThenTheDataListIGetShouldBe(Table table)
        {
            table.CompareToSet(this.DataList);
        }

        [Then(@"the data list I get should be empty")]
        public void ThenTheDataListIGetShouldBeEmpty()
        {
            Assert.IsNull(this.DataList);
        }
    }
}
