Feature: Search
	In order to search a service
	As a skill trader
	I want to use search function to search a service

@mytag
Scenario: Check if user is able to search by using catergory and subcategory
	Given I have clicked on Magnifying glass and in a search page
	When I click on category and subcaterogy
	Then it should show the service

Scenario: Check if user is able to search by using filters
	Given I have clicked on Magnifying glass and I'm in search page
	When I click on filter (Online, OnSite, Show all)
	Then it should show the services


Scenario: Check if user is able to search by search function
	Given I have clicked on Magnifying glass and in search page
	When I search the service in search bar and click on the service
	Then it should show the service detail
