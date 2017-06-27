Feature: Source Code Provider Specs
	In order to parse source code
	As a Compilers writer
	I want to have an accurate source code manager

	@Lexicon
	@HappyPath
	Scenario: Reading one symbol yields the right character
		Given a source code string
		"""
		"""
		When I get the next available symbol
		Then the current symbol should be the EndOfFile character

	@Lexicon
	@HappyPath
	Scenario: Reading one symbol increments the right counters
		Given a source code string
		"""
		[]
		"""
		When I get the next available symbol
		Then the current symbol should be '['
		And the current column should be 1

	@Lexicon
	@HappyPath
	Scenario: Reading one symbol many times increments the column counter
		Given a source code string
		"""
		{ "name": "test" }
		"""
		When I get the next available symbol 5 times
		Then the current symbol should be 'a'
		And the current column should be 5
		And the current line should be 1

	@Lexicon
	@HappyPath
	Scenario: Reading repeatedly one symbol until the new line keeps the line counter
		Given a source code string
		"""
		{ "name": "test" }
		[]
		"""
		When I get the next available symbol 19 times
		Then the current symbol should be a new line
		And the current column should be 19
		And the current line should be 1

	@Lexicon
	@HappyPath
	Scenario: Reading repeatedly one symbol until the next line updates the line and column counters
		Given a source code string
		"""
		{ "name": "test" }
		[]
		"""
		When I get the next available symbol 20 times
		Then the current symbol should be '['
		And the current column should be 1
		And the current line should be 2