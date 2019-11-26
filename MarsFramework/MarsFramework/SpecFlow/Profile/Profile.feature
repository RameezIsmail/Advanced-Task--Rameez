Feature: Profile
	In order to update my profile
	As a skill trader
	I want to update my profile page

@mytag
Scenario: Check if user could update Availability
	Given I am in profile page and click on edit button
	When I update Availability
	Then the result should be updated beside Availability

Scenario: Check if user could update Hours
	Given I am in profile page and click edit button
	When I update Hours
	Then the result should be updated beside Hours

Scenario: Check if user could update Earn Target
	Given I am in profile and click on edit button
	When I update Earn Target
	Then the result should be updated beside Earn Target
