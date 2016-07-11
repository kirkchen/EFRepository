Feature: GenericRepository
	In order to reduce the work of writing repository
	As a programmer
	I would like to create a GenericRepository to process database related logic

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