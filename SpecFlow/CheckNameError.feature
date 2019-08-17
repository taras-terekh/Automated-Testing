Feature: CheckNameError

Scenario: Check Name Error
	Given I have navigated to the Lorem and grab some text and redirected to the BBC page
	When I fill the form and leave Name field blank
	Then check error
