Feature: CheckEmailError

Scenario: Check Email Error
	Given I have navigated to the lorem and grab some text and redirected to the BBC page
	When I fill the form and leave email field blank
	Then check error message
