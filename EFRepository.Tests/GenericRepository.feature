﻿Feature: GenericRepository
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