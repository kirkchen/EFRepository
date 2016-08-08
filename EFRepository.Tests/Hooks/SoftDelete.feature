@Hook
Feature: SoftDelete

As a programmer  <br />
In order to update IsDelete property in data class instead of delete data in the database	<br />
I would like to use soft delete hook to handle soft delete logic <br />

How to use?
--------

1. Create data class inherits **ISoftDelete**
		
		public class SoftDeleteData : IEntity<int>, ISoftDelete
		{        
			[Key]
			public int Id { get; set; }
       
			public string Content { get; set; }
      
			public bool IsDelete { get; set; }
		}	

1. Create repository inherits **Generic repository** and register **Soft delete hook**

		public class SoftDeleteRepository : GenericRepository<int, SoftDeleteData>, IRepository<int, SoftDeleteData>
		{        
			public SoftDeleteRepository(MyDbContext context)
				: base(context)
			{
				this.RegisterPostLoadHook(new SoftDeletePostLoadHook<MyData>());
				this.RegisterPostActionHook(new SoftDeletePostActionHook<MyData>());
			}
		}

1. Use repository

		using(var dbContext = new MyDbContext())
		{
			var repository = new SoftDeleteRepository(dbContext);

			//// Will update IsDelete to true
			repository.Delete(1);

			or

			//// Will only get data with IsDelete=false
			var myData = repository.Get(1);
		}

Scenarios
--------

Scenario: Get datalist from database should filter IsDelete=true if data is soft delete
	Given database has soft delete datas
		| Id | Content    | IsDelete |
		| 1  | TestData   | true     |
		| 2  | TestData 2 | false    |
	And Register soft delete hook in generic repository
	When I use generic repository get data list from database	
	Then the data list I get should be
		| Id | Content    |		
		| 2  | TestData 2 |

Scenario: Get datalist from database with condition content should contains "2" should filter IsDelete=true if data is soft delete
	Given database has soft delete datas
		| Id | Content    | IsDelete |
		| 1  | TestData   | true     |
		| 2  | TestData 2 | false    |
		| 3  | TestData 2 | true     |
	And test datas content field should contains "2"
	And Register soft delete hook in generic repository
	When I use generic repository get data list with condition from database	
	Then the data list I get should be
		| Id | Content    |		
		| 2  | TestData 2 |

Scenario: Get data from database should filter IsDelete=true if data is soft delete
	Given database has soft delete datas
		| Id | Content    | IsDelete |
		| 1  | TestData   | true     |
		| 2  | TestData 2 | false    |
	And Register soft delete hook in generic repository
	When I use generic repository get data from database by id "1"
	Then the data list I get should be empty		

Scenario: Get data from database with condition content should contains "2" should filter IsDelete=true if data is soft delete
	Given database has soft delete datas
		| Id | Content    | IsDelete |
		| 1  | TestData   | true     |
		| 2  | TestData 2 | true     |
		| 3  | TestData 2 | false    |
	And test datas content field should contains "2"
	And Register soft delete hook in generic repository
	When I use generic repository get data from database with conditon
	Then the data list I get should be
		| Id | Content    |
		| 3  | TestData 2 |

Scenario: Delete data will be replaced by update IsDelete field
	Given database has soft delete datas
		| Id | Content    | IsDelete |
		| 1  | TestData   | false    |
		| 2  | TestData 2 | false    |
	And Register soft delete hook in generic repository
	When I use generic repository delete data with id "1"
	And  I save the changes
	Then database should exists test datas
		| Id | Content    | Is delete |
		| 1  | TestData   | true      |
		| 2  | TestData 2 | false     |
