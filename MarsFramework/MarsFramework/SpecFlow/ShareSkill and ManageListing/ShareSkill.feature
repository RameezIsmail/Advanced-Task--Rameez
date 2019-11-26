Feature: ShareSkill
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Check if user could able to add a skillshare
	Given I clicked on the ShareSkill button under Profile Page
	When I add new skillshare details
	Then that shareskill details should be displayed on my listing under ManageListing page

Scenario: Check if user could able to edit a skillshare
	Given I clicked on the ManageListing tab under Profile Page
	When I click on Edit button on ShareSkill under ManageListing Page and edit skillshare details
	Then that shareskill details should be displayed on my listings under ManageListing page

Scenario: Check if user could able to delete a skillshare
	Given I clicked on the ManageListings tab under Profile Page
	When I delete skillshare details
	Then that shareskill details should not be displayed on my listings under ManageListing page
