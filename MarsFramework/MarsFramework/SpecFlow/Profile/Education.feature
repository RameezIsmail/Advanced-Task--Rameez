Feature: Education
	In order to update my profile
	As a skill trader
	I want to update my education tab

@mytag
Scenario: Check if user could able to add an education
	Given I clicked on the education tab under Profile page
	When I add new education details
	Then that education details should be displayed on my listings

Scenario: Check if user could able to edit education details
	Given I click on the education tab under Profile Page
	When I edit the education details
	Then That education that been edited should be displayed on my listings

Scenario: Check if user could able to delete an education
	Given I clicked on the education tab under Profile Page
	When I click that delete button
	Then the education that got clicked should not be displayed in my listings