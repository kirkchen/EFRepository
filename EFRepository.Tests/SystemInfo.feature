Feature: SystemInfo
	In order to auto add system required information when store data
	As a programmer
	I would like to use update certain field to record system infomation

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
