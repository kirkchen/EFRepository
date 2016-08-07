using EFRepository.Hooks;
using EFRepository.Tests.TestClasses;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace EFRepository.Tests.Hooks
{
    [Binding]
    [Scope(Feature = "SystemInfo")]
    public class SystemInfoSteps
    {
        public string ConnectionString { get; private set; }

        public TestDbContext DbContext { get; private set; }

        public SystemInfoRepository Repository { get; private set; }

        public SystemInfoData DataItem { get; private set; }

        public IEnumerable<SystemInfoData> DataList { get; private set; }

        public Mock<IUserHelper> UserHelperMock { get; private set; }

        public Mock<IDatetimeHelper> DatetimeHelperMock { get; private set; }

        [BeforeScenario]
        public void BeforeScenario()
        {
            this.ConnectionString = Environment.GetEnvironmentVariable("TestDb") ?? "TestDb";

            this.DbContext = new TestDbContext(ConnectionString);
            this.DbContext.Database.Delete();

            this.Repository = new SystemInfoRepository(this.DbContext);

            this.UserHelperMock = new Mock<IUserHelper>();
            this.DatetimeHelperMock = new Mock<IDatetimeHelper>();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            this.DbContext.Dispose();
        }

        [Given(@"I have systemInfo datas")]
        public void GivenIHaveSystemInfoDatas(Table table)
        {
            this.DataList = table.CreateSet<SystemInfoData>();
        }

        [Given(@"database has systemInfo datas")]
        public void GivenDatabaseHasSystemInfoDatas(Table table)
        {
            var dataList = table.CreateSet<SystemInfoData>();

            using (var dbContext = new TestDbContext(this.ConnectionString))
            {
                dbContext.SystemInfoDatas.AddRange(dataList);
                dbContext.SaveChanges();
            }
        }

        [Given(@"the data I want to update is")]
        public void GivenTheDataIWantToUpdateIs(Table table)
        {
            this.DataItem = table.CreateInstance<SystemInfoData>();
        }       

        [Given(@"Current user is ""(.*)""")]
        public void GivenCurrentUserIs(string userName)
        {
            this.UserHelperMock.Setup(i => i.GetUserName()).Returns(userName);
        }

        [Given(@"Current datetime is ""(.*)""")]
        public void GivenCurrentDatetimeIs(DateTime currentDatetime)
        {
            this.DatetimeHelperMock.Setup(i => i.GetCurrentTime()).Returns(currentDatetime);
        }

        [Given(@"Register system info hook in generic repository")]
        public void GivenRegisterSystemInfoHookInGenericRepository()
        {
            this.Repository.RegisterPostActionHook(new SystemInfoPostActionHook<SystemInfoData>(this.UserHelperMock.Object, this.DatetimeHelperMock.Object));
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

        [When(@"I use generic repository update data")]
        public void WhenIUseGenericRepositoryUpdateData()
        {
            this.Repository.Update(this.DataItem);
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
                var datalist = dbContext.SystemInfoDatas.ToList();

                table.CompareToSet(datalist);
            }
        }
    }
}
