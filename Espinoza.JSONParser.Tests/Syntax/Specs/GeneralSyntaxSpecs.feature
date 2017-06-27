Feature: General Syntax Specs
	In order to ensure JSON is written correctly
	As a compilers designer
	I want to be able to validate the syntax of a json file

	@Syntax
	@CompleteJSON
	@HappyPath
	Scenario: An empty file is valid
		Given a source code string
		"""
		"""

		And a new Lexicon component
		And a new Syntax Component
		When I run syntax analysis on it
		Then the operation should complete without error

	@Syntax
	@CompleteJSON
	@HappyPath
	Scenario: A JSON can be an empty object
		Given a source code string
		"""
		{

		}
		"""
		And a new Lexicon component
		And a new Syntax Component
		When I run syntax analysis on it
		Then the operation should complete without error

	@Syntax
	@CompleteJSON
	@HappyPath
	Scenario: A JSON file can be an string
		Given a source code string
		"""
		"this is a string"
		"""
		And a new Lexicon component
		And a new Syntax Component
		When I run syntax analysis on it
		Then the operation should complete without error

	@Syntax
	@CompleteJSON
	@HappyPath
	Scenario: A JSON file can be an empty array
		Given a source code string
		"""
		[]
		"""
		And a new Lexicon component
		And a new Syntax Component
		When I run syntax analysis on it
		Then the operation should complete without error


	@Syntax
	@CompleteJSON
	@HappyPath
	Scenario: A JSON file can be an integer
		Given a source code string
		"""
		15
		"""
		And a new Lexicon component
		And a new Syntax Component
		When I run syntax analysis on it
		Then the operation should complete without error

	@Syntax
	@CompleteJSON
	@HappyPath
	Scenario: A JSON file can be a floating point number
		Given a source code string
		"""
		3.141592654
		"""
		And a new Lexicon component
		And a new Syntax Component
		When I run syntax analysis on it
		Then the operation should complete without error

	@Syntax
	@CompleteJSON
	@ExceptionPath
	Scenario: A JSON object must have a key value pair after each comma
		Given a source code string
		"""
		{
		  "test": "name",
		}
		"""
		And a new Lexicon component
		And a new Syntax Component
		When I run syntax analysis on it
		Then the operation should raise a syntax error

	@Syntax
	@CompleteJSON
	@HappyPath
	Scenario: A JSON file might be a complex JSON object
		Given a source code string
		"""
		{
		  "firstName": "Juan",
		  "middleName": "Carlos",
		  "lastName": "Espinoza",
		  "age": 23,
		  "pendingClasses":[
			"Compilers II",
			"Database Theory II",
			"Networking"
		  ],
		  "averageIndex": 81.5,
		  "universityDegree": null
		}
		"""
		And a new Lexicon component
		And a new Syntax Component
		When I run syntax analysis on it
		Then the operation should complete without error

	@Syntax
	@CompleteJSON
	@ExceptionPath
	Scenario: An object must be completed
		Given a source code string
		"""
		{ {
		"""
		And a new Lexicon component
		And a new Syntax Component
		When I run syntax analysis on it
		Then the operation should raise a syntax error