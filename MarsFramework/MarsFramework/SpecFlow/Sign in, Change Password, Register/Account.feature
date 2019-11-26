Feature: Account
	In order to access to account
	As a skill trader
	I want to register, sign in and change password

@mytag
Scenario: Check if user is able to sign in
	Given I am in home page and want to sign in
	When I enter login detail
	Then I should be in profile page

Scenario: Check if user is able to register
	Given I am in home page and want to register
	When I enter the register detail
	Then it should tell you to verify account (Unless the email is already taken)

Scenario: Check if user is able to change password
	Given I am in profile page and click change password
	When I enter the details and new password
	Then the new details should get saved