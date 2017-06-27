Feature: Token Specs
	In order to avoid mistakes
	As a Compilers writer
	I want to be able to check for equality between Token objects

@HappyPath
@Token
Scenario: Comparison of two equal tokens
	Given the following Token called "token1"
	| Lexemme | TokenType        | Line | Column |
	| null    | ReservedWordNull | 2    | 2      |
	And the following Token called "token2"
	| Lexemme | TokenType        | Line | Column |
	| null    | ReservedWordNull | 2    | 2      |
	When I check the two tokens "token1" and "token2" for equality
	Then the result should be true

@HappyPath
@Token
Scenario: Comparison of two different tokens
	Given the following Token called "token1"
	| Lexemme | TokenType        | Line | Column |
	| null    | ReservedWordNull | 2    | 2      |
	And the following Token called "token2"
	| Lexemme | TokenType     | Line | Column |
	| "main"  | DoubleQuotedString | 2    | 2      |
	When I check the two tokens "token1" and "token2" for equality
	Then the result should be false