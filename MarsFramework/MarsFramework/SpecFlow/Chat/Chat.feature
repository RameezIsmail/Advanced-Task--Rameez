Feature: Chat
	In order to view the chat
	As a skill trader
	I want to chat and view chat history

@mytag
Scenario: Check if user is able to chat someone
	Given I am in profile page and click on manage listings tab
	When I click on view for one of the listing and click chat
	Then it should display chat for that listing

Scenario: Check if user is able to view chat history
	Given I am in profile page
	When I click on chat 
	Then it should display chat history
