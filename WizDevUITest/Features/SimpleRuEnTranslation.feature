Feature: SimpleRuEnTranslation
	In order to greet others
	As not a native speaker
	I want to know a translation of common greeting

@mytag
Scenario: Translate Привет into English
	Given I have opened google translate in browser
	When I have entered Привет into left side
	And Английский is selected to translate
	Then I see Hello in the right side