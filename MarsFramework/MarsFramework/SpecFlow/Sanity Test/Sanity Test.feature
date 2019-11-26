Feature: Sanity Test
	In order to Test a service
	As a skill trader
	I want to use Test the function after new updates

@mytag
Scenario: Check if functions are still working correctly after new updates
	Given I have clicked on sign out button
	When I sign in and click on each tabs
	Then all the functions should still work correctly to the end
