Feature: CheckCategory

Scenario: Check category search
	Given I Navigate to the Home Page
	When I fill the search field
	Then the result should correspond category
