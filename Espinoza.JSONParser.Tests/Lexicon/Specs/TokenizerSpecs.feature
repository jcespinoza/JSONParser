Feature: Tokenizer Specs
	In order interpret C code
	As a Compiler designer
	I want to be able to parse a C source code file

	@Lexicon
	@HappyPath
	Scenario: When the end of the file is reached it should handle it correctly
		Given a source code string
        """

        """
		And a new Lexicon component
		When I get the next available token
		Then the Token should be of type EndOfFile

	@Lexicon
	@HappyPath
	Scenario: Parsing a Single Line Succeeds
		Given a source code string
		"""
		{
			"name" : "test"
		}
		"""
		And a new Lexicon component 
		When I get the next available token
		Then the Token should be of type PunctLeftCurlyBrace
		And the Token should have "{" as lexemme
		When I get the next available token
		Then the Token should be of type DoubleQuotedString
		And the Token should have ""name"" as lexemme
		When I get the next available token
		Then the Token should be of type PunctColon
		And the Token should have ":" as lexemme
		When I get the next available token
		Then the Token should be of type DoubleQuotedString
		And the Token should have ""test"" as lexemme
		When I get the next available token
		Then the Token should be of type PunctRightCurlyBrace
		And the Token should have "}" as lexemme

	@Lexicon
	@HappyPath
	Scenario: Lexer is able to parse valid Jsons
		Given a source code string
		"""
		{ "name" : "test" }
		"""
		And a new Lexicon component
		When I parse the whole source code
		Then the tokens should be these
		| Lexemme | TokenType            | Column | Line |
		| {       | PunctLeftCurlyBrace  | 1      | 1    |
		| "name"  | DoubleQuotedString    | 3      | 1    |
		| :       | PunctColon           | 10      | 1    |
		| "test"  | DoubleQuotedString    | 12     | 1    |
		| }       | PunctRightCurlyBrace | 19     | 1    |
		| EOF     | EndOfFile            | 20     | 1    |

	@Lexicon
	@HappyPath
	Scenario: Lexer is able to parse all reserved words
		Given a source code string
		"""
		null
		"""
		And a new Lexicon component
		When I parse the whole source code
		Then the tokens should be these
		| Lexemme | TokenType        | Column | Line |
		| null    | ReservedWordNull | 1      | 1    |
		| EOF     | EndOfFile        | 5      | 1    |


	@Lexicon
	@HappyPath
	Scenario: Ability to parse a complete source code file
		Given a source code string
		"""

		"""
		And a new Lexicon component
		When I parse the whole source code
		Then the tokens should be these
		| Lexemme | TokenType | Column | Line |
		| EOF     | EndOfFile | 1      | 1    |