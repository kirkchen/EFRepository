@Repository
Feature: GenericRepository

As a programmer <br />
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
--------

Scenario: Add data into database should be success
	Given I have test datas
		| Id | Content  |
		| 1  | TestData |
	When I use generic repository to add data
	And  I save the changes
	Then database should exists test datas
		| Id | Content  |
		| 1  | TestData |

Scenario: Add datalist into database should be success
	Given I have test datas
		| Id | Content    |
		| 1  | TestData   |
		| 2  | TestData 2 |
	When I use generic repository to add datalist
	And  I save the changes
	Then database should exists test datas
		| Id | Content    |
		| 1  | TestData   |
		| 2  | TestData 2 |

Scenario: Get datalist from database should be success
	Given database has test datas
		| Id | Content    |
		| 1  | TestData   |
		| 2  | TestData 2 |
	When I use generic repository get data list from database	
	Then the data list I get should be
		| Id | Content    |
		| 1  | TestData   |
		| 2  | TestData 2 |

Scenario: Get datalist from database with condition content should contains "2" should be success
	Given database has test datas
		| Id | Content    |
		| 1  | TestData   |
		| 2  | TestData 2 |
	And test datas content field should contains "2"
	When I use generic repository get data list with condition from database	
	Then the data list I get should be
		| Id | Content    |		
		| 2  | TestData 2 |

Scenario: Get data from database should be success
	Given database has test datas
		| Id | Content    |
		| 1  | TestData   |
		| 2  | TestData 2 |
	When I use generic repository get data from database by id "1"
	Then the data list I get should be
		| Id | Content    |
		| 1  | TestData   |		

Scenario: Get data from database with condition content should contains "2" should be success
	Given database has test datas
		| Id | Content    |
		| 1  | TestData   |
		| 2  | TestData 2 |
	And test datas content field should contains "2"
	When I use generic repository get data from database with conditon
	Then the data list I get should be
		| Id | Content    |
		| 2  | TestData 2 |	

Scenario: Update data which is exists in database should be success
	Given database has test datas
		| Id | Content    |
		| 1  | TestData   |
		| 2  | TestData 2 |
	And the data I want to update is
		| Id | Content           |
		| 1  | TestData Modified |
	When I use generic repository update data
	And  I save the changes
	Then database should exists test datas
		| Id | Content           |
		| 1  | TestData Modified |
		| 2  | TestData 2        |

Scenario: Delete data which is exists in database should be success
	Given database has test datas
		| Id | Content    |
		| 1  | TestData   |
		| 2  | TestData 2 |	
	When I use generic repository delete data with id "1"
	And  I save the changes
	Then database should exists test datas
		| Id | Content           |		
		| 2  | TestData 2        |