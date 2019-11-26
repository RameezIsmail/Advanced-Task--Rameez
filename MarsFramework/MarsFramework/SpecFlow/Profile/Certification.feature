Feature: Certification
	In order to update my profile
	As a skill trader
	I want to update my certification tab

@mytag
Scenario: Check if user could able to add a certification
	Given I clicked on the Certifications tab under Profile Page
	When I add new certification details
	Then that certification details should be displayed on my listings

Scenario: Check if user could able to edit certification
	Given I clicked on the certification tab under Profile Page
	When I edit the certification details
	Then That certification that been edited should be displayed on my listings

Scenario: Check if user could able to delete a certification
	Given I clicked on the certifications tab under Profile Page
	When I click the delete button 
	Then the certification that got clicked should not be displayed on my listings