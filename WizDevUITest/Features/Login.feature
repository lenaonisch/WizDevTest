Feature: Login
	In order to save translations
	As a user
	I want to login

@mytag
Scenario: Login with google account
	Given I have opened google translate in browser
	And Nobody is logged in
	When I press Войти
	Then Login page is opened
	And I enter itanet181@gmail.com email
	And I press Далее
	Then Password page is opened
	And I enter Aa111111! password
	And I press Далее
	Then Translation page is opened
