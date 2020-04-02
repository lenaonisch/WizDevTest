Feature: SimpleTranslate
	In order to get english equivalent
	As a russian speaker
	I want to be told "Привет" translation

@mytag
Scenario: Translate "Hello" from Russian to English
	Given I have sent Привет text into google translator
	Then I get Hello among possible translations
