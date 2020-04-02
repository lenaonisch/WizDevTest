Feature: SimpleTranslateAnyWordForbidden
	In order to break the google:)
	As a person who doesn't know how API is constructed 
	I want to send invalid word instead of "Привет" translation

@mytag
Scenario: Unsuccessfull translation "Bye" from Russian to English
	Given I have sent Пока text into google translator
	And I used the same parameters as I sent with Привет
	Then I get Forbidden status
