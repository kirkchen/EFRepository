Feature: Nested
	In order to save nested data into the database
	As a programmer
	I would like to save the data and it's child collection into database

Scenario: Add two level data into database should be success
	Given I have nested datas
		| Id | Content  |
		| 1  | TestData |
	And the nested data with id "1" has level 2 data
		| Id | Content        |
		| 1  | Level 2 Data   |
		| 2  | Level 2 Data 2 |
	When I use generic repository to add data
	And  I save the changes
	Then database should exists nested datas
		| Id | Content  |
		| 1  | TestData |
	And database should exists nested level 2 datas
		| Id | Content        |
		| 1  | Level 2 Data   |
		| 2  | Level 2 Data 2 |

Scenario: Update nested data's child data which is exists in database should be success
	Given database has nested datas
		| Id | Content  |
		| 1  | TestData |	
	And database has nested level 2 data
		| Id | Content        | ParentId |
		| 1  | Level 2 Data   | 1        |
		| 2  | Level 2 Data 2 | 1        |
	And I have nested datas
		| Id | Content  |
		| 1  | TestData |
	And the nested data with id "1" has level 2 data
		| Id | Content           | ParentId |
		| 1  | Level 2 Data      | 1        |
		| 2  | Level 2 Data 2222 | 1        |
	When I use generic repository update data
	And  I save the changes
	Then database should exists nested datas
		| Id | Content  |
		| 1  | TestData |
	And database should exists nested level 2 datas
		| Id | Content           |
		| 1  | Level 2 Data      |
		| 2  | Level 2 Data 2222 |

Scenario: Update nested data's parent data which is exists in database should be success
	Given database has nested datas
		| Id | Content  |
		| 1  | TestData |	
	And database has nested level 2 data
		| Id | Content        | ParentId |
		| 1  | Level 2 Data   | 1        |
		| 2  | Level 2 Data 2 | 1        |
	And I have nested datas
		| Id | Content           |
		| 1  | TestData Modified |		
	And the nested data with id "1" has level 2 data
		| Id | Content        | ParentId |
		| 1  | Level 2 Data   | 1        |
		| 2  | Level 2 Data 2 | 1        |
	When I use generic repository update data
	And  I save the changes
	Then database should exists nested datas
		| Id | Content           |
		| 1  | TestData Modified |
	And database should exists nested level 2 datas
		| Id | Content        |
		| 1  | Level 2 Data   |
		| 2  | Level 2 Data 2 |