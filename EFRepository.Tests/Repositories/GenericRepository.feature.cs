﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace EFRepository.Tests.Repositories
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class GenericRepositoryFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GenericRepository.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GenericRepository", @"As a programmer <br />
In order to reduce the work of writing repository <br />
I would like to create a GenericRepository to process database related logic <br />

How to use?
--------

1. Create data class inherits **IEntity**

		public class TestData : IEntity<int>
		{        
			[Key]
			public int Id { get; set; }
        
	        public string Content { get; set; }
		}

1. Create repository inherits **Generic repository**

		public class TestRepository : GenericRepository<int, TestData>, IRepository<int, TestData>
		{        
			public TestRepository(TestDbContext context)
				: base(context)
			{
			}
		}

1. Use repository

		using(var dbContext = new MyDbContext())
		{
			var repository = new TestRepository(dbContext);
			
			//// Support basic CRUD operation
			var data = repository.Get(1)
			repository.Add(myData);
			repository.Update(myData);
			repository.Delete(1)
		}

Scenarios
--------", ProgrammingLanguage.CSharp, new string[] {
                        "Repository"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "GenericRepository")))
            {
                EFRepository.Tests.Repositories.GenericRepositoryFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Add data into database should be success")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GenericRepository")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Repository")]
        public virtual void AddDataIntoDatabaseShouldBeSuccess()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add data into database should be success", ((string[])(null)));
#line 47
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Content"});
            table1.AddRow(new string[] {
                        "1",
                        "TestData"});
#line 48
 testRunner.Given("I have test datas", ((string)(null)), table1, "Given ");
#line 51
 testRunner.When("I use generic repository to add data", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
 testRunner.And("I save the changes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Content"});
            table2.AddRow(new string[] {
                        "1",
                        "TestData"});
#line 53
 testRunner.Then("database should exists test datas", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Add datalist into database should be success")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GenericRepository")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Repository")]
        public virtual void AddDatalistIntoDatabaseShouldBeSuccess()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add datalist into database should be success", ((string[])(null)));
#line 57
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Content"});
            table3.AddRow(new string[] {
                        "1",
                        "TestData"});
            table3.AddRow(new string[] {
                        "2",
                        "TestData 2"});
#line 58
 testRunner.Given("I have test datas", ((string)(null)), table3, "Given ");
#line 62
 testRunner.When("I use generic repository to add datalist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
 testRunner.And("I save the changes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Content"});
            table4.AddRow(new string[] {
                        "1",
                        "TestData"});
            table4.AddRow(new string[] {
                        "2",
                        "TestData 2"});
#line 64
 testRunner.Then("database should exists test datas", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get datalist from database should be success")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GenericRepository")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Repository")]
        public virtual void GetDatalistFromDatabaseShouldBeSuccess()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get datalist from database should be success", ((string[])(null)));
#line 69
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Content"});
            table5.AddRow(new string[] {
                        "1",
                        "TestData"});
            table5.AddRow(new string[] {
                        "2",
                        "TestData 2"});
#line 70
 testRunner.Given("database has test datas", ((string)(null)), table5, "Given ");
#line 74
 testRunner.When("I use generic repository get data list from database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Content"});
            table6.AddRow(new string[] {
                        "1",
                        "TestData"});
            table6.AddRow(new string[] {
                        "2",
                        "TestData 2"});
#line 75
 testRunner.Then("the data list I get should be", ((string)(null)), table6, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get datalist from database with condition content should contains \"2\" should be s" +
            "uccess")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GenericRepository")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Repository")]
        public virtual void GetDatalistFromDatabaseWithConditionContentShouldContains2ShouldBeSuccess()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get datalist from database with condition content should contains \"2\" should be s" +
                    "uccess", ((string[])(null)));
#line 80
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Content"});
            table7.AddRow(new string[] {
                        "1",
                        "TestData"});
            table7.AddRow(new string[] {
                        "2",
                        "TestData 2"});
#line 81
 testRunner.Given("database has test datas", ((string)(null)), table7, "Given ");
#line 85
 testRunner.And("test datas content field should contains \"2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.When("I use generic repository get data list with condition from database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Content"});
            table8.AddRow(new string[] {
                        "2",
                        "TestData 2"});
#line 87
 testRunner.Then("the data list I get should be", ((string)(null)), table8, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get data from database should be success")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GenericRepository")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Repository")]
        public virtual void GetDataFromDatabaseShouldBeSuccess()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get data from database should be success", ((string[])(null)));
#line 91
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Content"});
            table9.AddRow(new string[] {
                        "1",
                        "TestData"});
            table9.AddRow(new string[] {
                        "2",
                        "TestData 2"});
#line 92
 testRunner.Given("database has test datas", ((string)(null)), table9, "Given ");
#line 96
 testRunner.When("I use generic repository get data from database by id \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Content"});
            table10.AddRow(new string[] {
                        "1",
                        "TestData"});
#line 97
 testRunner.Then("the data list I get should be", ((string)(null)), table10, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get data from database with condition content should contains \"2\" should be succe" +
            "ss")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GenericRepository")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Repository")]
        public virtual void GetDataFromDatabaseWithConditionContentShouldContains2ShouldBeSuccess()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get data from database with condition content should contains \"2\" should be succe" +
                    "ss", ((string[])(null)));
#line 101
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Content"});
            table11.AddRow(new string[] {
                        "1",
                        "TestData"});
            table11.AddRow(new string[] {
                        "2",
                        "TestData 2"});
#line 102
 testRunner.Given("database has test datas", ((string)(null)), table11, "Given ");
#line 106
 testRunner.And("test datas content field should contains \"2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
 testRunner.When("I use generic repository get data from database with conditon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Content"});
            table12.AddRow(new string[] {
                        "2",
                        "TestData 2"});
#line 108
 testRunner.Then("the data list I get should be", ((string)(null)), table12, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Update data which is exists in database should be success")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GenericRepository")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Repository")]
        public virtual void UpdateDataWhichIsExistsInDatabaseShouldBeSuccess()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update data which is exists in database should be success", ((string[])(null)));
#line 112
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Content"});
            table13.AddRow(new string[] {
                        "1",
                        "TestData"});
            table13.AddRow(new string[] {
                        "2",
                        "TestData 2"});
#line 113
 testRunner.Given("database has test datas", ((string)(null)), table13, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Content"});
            table14.AddRow(new string[] {
                        "1",
                        "TestData Modified"});
#line 117
 testRunner.And("the data I want to update is", ((string)(null)), table14, "And ");
#line 120
 testRunner.When("I use generic repository update data", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 121
 testRunner.And("I save the changes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Content"});
            table15.AddRow(new string[] {
                        "1",
                        "TestData Modified"});
            table15.AddRow(new string[] {
                        "2",
                        "TestData 2"});
#line 122
 testRunner.Then("database should exists test datas", ((string)(null)), table15, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete data which is exists in database should be success")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GenericRepository")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Repository")]
        public virtual void DeleteDataWhichIsExistsInDatabaseShouldBeSuccess()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete data which is exists in database should be success", ((string[])(null)));
#line 127
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Content"});
            table16.AddRow(new string[] {
                        "1",
                        "TestData"});
            table16.AddRow(new string[] {
                        "2",
                        "TestData 2"});
#line 128
 testRunner.Given("database has test datas", ((string)(null)), table16, "Given ");
#line 132
 testRunner.When("I use generic repository delete data with id \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 133
 testRunner.And("I save the changes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Content"});
            table17.AddRow(new string[] {
                        "2",
                        "TestData 2"});
#line 134
 testRunner.Then("database should exists test datas", ((string)(null)), table17, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
