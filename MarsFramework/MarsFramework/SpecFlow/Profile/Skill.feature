Feature: Skill
	In order to update my profile
	As a skill trader
	I want to update my skill tab

@mytag
Scenario: Check if user could able to add a skill
	Given I clicked on the skill tab under Profile page
	When I add a new skill
	Then that skill should be displayed on my listings

Scenario: Check if user could able to edit the skill
	Given I click on the skill tab under Profile Page
	When I edit the skill details
	Then That skill that have been edited should be displayed on my listings

Scenario: Check if user could able to delete a skill
	Given I clicked on the skill tab under Profile Page
	When I click delete button 
	Then the skill that got clicked should not be displayed on my listings
