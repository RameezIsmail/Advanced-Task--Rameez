Feature: Language
	In order to update my profile
	As a skill trader
	I want to update my language tab

@mytag
Scenario: Check if user could able to add a language 
	Given I clicked on the Language tab under Profile page
	When I add a new language
	Then that language should be displayed on my listings
	
Scenario: Check if user could able to edit language details
	Given I click on the language tab under Profile Page
	When I edit the language details
	Then that language that been edited should be displayed on my listings

Scenario: Check if user could able to delete language
	Given I clicked on the Languages tab under Profile Page
	When I click on the delete button
	Then the language that got clicked should not be displayed on my listings
