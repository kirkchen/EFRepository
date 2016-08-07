@Hook
Feature: SystemInfo

As a programmer <br />
In order to auto assign required system information when insert or update data <br />
I would like to use use system info hook to handle assign system infomation logic <br />

1. Create data class inherits **ISystemInfo**
		
		public class SoftDeleteData : IEntity<int>, ISoftDelete
		{        
			[Key]
			public int Id { get; set; }
       
			public string Content { get; set; }
      
			public DateTime CreatedAt { get; set; }

	        public string CreatedBy { get; set; }

			public DateTime UpdatedAt { get; set; }

			public string UpdatedBy { get; set; }
		}	

1. Create **UserHelper** class to get current username in your system

		public class UserHelper: IUserHelper
		{
			public string GetUserName()
			{
				//// Implement your system user name logic
				return HttpContext.Current.User.Name;
			}
		}

1. Create repository inherits **Generic repository** and register **System info hook**

		public class SystemInfoRepository : GenericRepository<int, SystemInfoData>, IRepository<int, SystemInfoData>
		{        
			public SystemInfoRepository(MyDbContext context)
				: base(context)
			{
				this.Repository.RegisterPostActionHook(new SystemInfoPostActionHook<SystemInfoData>(new UserHelper(), new DatetimeHelper()));
			}
		}

1. Use repository

		using(var dbContext = new MyDbContext())
		{
			var repository = new SoftDeleteRepository(dbContext);

			//// Will auto update required system info field
			repository.Add(myData);

			or

			//// Will auto update required system info field
			repository.Update(myData);
		}

Below are some sceranrios for **System info hook**

Scenario: Add data into database should be success and auto assign system required infomation
	Given I have systemInfo datas
		| Id | Content  |
		| 1  | TestData |
	And Current user is "John"
	And Current datetime is "2016/08/05 16:00:00"
	And Register system info hook in generic repository
	When I use generic repository to add data
	And  I save the changes
	Then database should exists test datas
		| Id | Content  | CreatedAt           | CreatedBy | UpdatedAt           | UpdatedBy |
		| 1  | TestData | 2016/08/05 16:00:00 | John      | 2016/08/05 16:00:00 | John      |

Scenario: Add datalist into database should be success and auto assign system required infomation
	Given I have systemInfo datas
		| Id | Content    |
		| 1  | TestData   |
		| 2  | TestData 2 |
	And Current user is "John"
	And Current datetime is "2016/08/05 16:00:00"
	And Register system info hook in generic repository
	When I use generic repository to add datalist
	And  I save the changes
	Then database should exists test datas
		| Id | Content    | CreatedAt           | CreatedBy | UpdatedAt           | UpdatedBy |
		| 1  | TestData   | 2016/08/05 16:00:00 | John      | 2016/08/05 16:00:00 | John      |
		| 2  | TestData 2 | 2016/08/05 16:00:00 | John      | 2016/08/05 16:00:00 | John      |

Scenario: Update data which is exists in database should be success and auto assign system required infomation
	Given database has systemInfo datas
		| Id | Content    | CreatedAt           | CreatedBy | UpdatedAt           | UpdatedBy |
		| 1  | TestData   |	2016/08/05 16:00:00 | John      | 2016/08/05 16:00:00 | John      |
		| 2  | TestData 2 | 2016/08/05 16:00:00 | John      | 2016/08/05 16:00:00 | John      |
	And the data I want to update is
		| Id | Content           | CreatedAt           | CreatedBy | UpdatedAt           | UpdatedBy |
		| 1  | TestData Modified | 2016/08/05 16:00:00 | John      | 2016/08/05 16:00:00 | John      |
	And Current user is "David"
	And Current datetime is "2016/08/06 09:00:00"
	And Register system info hook in generic repository
	When I use generic repository update data
	And  I save the changes
	Then database should exists test datas
		| Id | Content           | CreatedAt           | CreatedBy | UpdatedAt           | UpdatedBy |
		| 1  | TestData Modified | 2016/08/05 16:00:00 | John      | 2016/08/06 09:00:00 | David     |
		| 2  | TestData 2        | 2016/08/05 16:00:00 | John      | 2016/08/05 16:00:00 | John      |
