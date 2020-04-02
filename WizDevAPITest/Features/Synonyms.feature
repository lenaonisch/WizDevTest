Feature: Synonyms
	In order to get related words
	As a person who doesn't want to repeat
	I want to find equivalents

@mytag
Scenario: Get synonyms
	Given I have sent Привет text into google translator
	Then I get at least 3 synonyms
	And Hi! is among them
