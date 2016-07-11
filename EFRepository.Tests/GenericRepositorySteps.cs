﻿using EFRepository.Tests.TestClasses;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Collections.Generic;

namespace EFRepository.Tests
{
    [Binding]
    [Scope(Feature = "GenericRepository")]
    public class GenericRepositorySteps
    {
        public string ConnectionString { get; private set; }

        public TestDbContext DbContext { get; private set; }

        public TestRepository Repository { get; private set; }

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

        [Then(@"database should exists test datas")]
        public void ThenDatabaseShouldExistsTestDatas(Table table)
        {
            using (var dbContext = new TestDbContext(this.ConnectionString))
            {
                var datalist = dbContext.TestDatas.ToList();

                table.CompareToSet(datalist);
            }
        }
    }
}
