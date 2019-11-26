Feature: Description
	In order to update my profile
	As a skill trader
	I want to update my description

@mytag
Scenario: Check if user could update Description
	Given Im in profile page and click on edit button
	When I update Description
	Then the description box should be updated
