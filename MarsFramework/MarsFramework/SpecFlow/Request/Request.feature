Feature: Request
	In order to view the request
	As a skill trader
	I want to view the requests

@mytag
Scenario: Check if user is able to view Received Request
	Given I am in profile page and hover over Manage Requests
	When I click on Received Requests
	Then it should display Received Requests

Scenario: Check if user is able to view Sent Request
	Given I am in profile page and hover over Manage Request
	When I click on Sent Requests
	Then it should display Sent Requests
