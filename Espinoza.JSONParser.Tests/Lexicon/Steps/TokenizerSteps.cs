using Espinoza.JSONParser.Lexicon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Espinoza.JSONParser.Tests.Lexicon.Steps
{
    [Binding]
    public class TokenizerSteps
    {
        [Given(@"a source code string")]
        public void GivenASourceCodeString(string sourceCodeText)
        {
            var sourceCodeProvider = new SourceCodeReader(sourceCodeText);
            ScenarioContext.Current.Add("sourceCodeText", sourceCodeText);
            ScenarioContext.Current.Add("sourceCodeProvider", sourceCodeProvider);
        }

        [Given(@"a new Lexicon component")]
        public void GivenANewLexiconComponent()
        {
            var sourceCodeProvider = ScenarioContext.Current.Get<ISourceCodeReader>("sourceCodeProvider");
            var lexer = new Lexer(sourceCodeProvider);
            ScenarioContext.Current.Add("newLexer", lexer);
        }

        [Given(@"a new Lexicon component in (.*) mode")]
        public void GivenANewLexiconComponentInMode(string lexerModeName)
        {
            GivenANewLexiconComponent();
        }

        [When(@"I get the next available token")]
        public void WhenIGetTheNextAvailableToken()
        {
            var lexer = ScenarioContext.Current.Get<Lexer>("newLexer");
            try
            {
                var token = lexer.GetNextToken();
                if (ScenarioContext.Current.ContainsKey("nextToken"))
                {
                    ScenarioContext.Current.Set(token, "nextToken");
                }
                else
                {
                    ScenarioContext.Current.Add("nextToken", token);
                }
            }
            catch (CompilerException exception)
            {
                ScenarioContext.Current.Add("exception", exception);
            }
        }

        [When(@"I parse the whole source code")]
        public void WhenIParseTheWholeSourceCode()
        {
            var lexer = ScenarioContext.Current.Get<Lexer>("newLexer");
            var tokenList = new List<Token>();
            try
            {
                Token token = null;
                do
                {
                    token = lexer.GetNextToken();
                    tokenList.Add(token);
                } while (token.TokenType != TokenType.EndOfFile);
                ScenarioContext.Current.Add("tokenList", tokenList);
            }
            catch (CompilerException exception)
            {
                ScenarioContext.Current.Add("exception", exception);
            }
        }

        [Then(@"the Token should be of type (.*)")]
        public void ThenTheTokenShouldBeOfType(TokenType expectedType)
        {
            var token = ScenarioContext.Current.Get<Token>("nextToken");
            Assert.AreEqual(expectedType, token.TokenType);
        }

        [Then(@"the Token should have ""(.*)"" as lexemme")]
        public void ThenTheTokenShouldHaveAsLexemme(string expectedLexemme)
        {
            var token = ScenarioContext.Current.Get<Token>("nextToken");
            Assert.AreEqual(expectedLexemme.Replace("\r\n", "\n"), token.Lexemme);
        }

        [Then(@"the tokens should be these")]
        public void ThenTheTokensShouldBeThese(List<Token> expectedTokenList)
        {
            var orderedExpectedTokenList = expectedTokenList.OrderBy(t => t.Line).ThenBy(t => t.Column).ToList();

            var actualTokenList = ScenarioContext.Current.Get<List<Token>>("tokenList");

            var orderedActualTokenList = actualTokenList.OrderBy(t => t.Line).ThenBy(t => t.Column).ToList();

            Assert.AreEqual(orderedExpectedTokenList.Count(), orderedActualTokenList.Count(), "Element count differ");

            for (int index = 0; index < orderedActualTokenList.Count(); index++)
            {
                var expectedToken = orderedExpectedTokenList.ElementAt(index);
                var actualToken = orderedActualTokenList.ElementAt(index);
                if (expectedToken.TokenType == TokenType.EndOfFile)
                {
                    Assert.AreEqual(expectedToken.TokenType, actualToken.TokenType, "End of File token does not match");
                }
                else
                {
                    Assert.AreEqual(expectedToken, actualToken, "Token Types differ");
                }
            }
        }

        [Then(@"the operation should complete without error")]
        public void ThenTheOperationShouldCompleteWithoutError()
        {
            var exceptionIsPresent = ScenarioContext.Current.ContainsKey("exception");
            var message = string.Empty;
            if (exceptionIsPresent)
            {
                message = ScenarioContext.Current.Get<CompilerException>("exception").Message;
            }
            Assert.IsFalse(exceptionIsPresent, message);
        }

        [Then(@"it should raise a lexical exception")]
        public void ThenItShouldRaiseALexicalException()
        {
            var exception = ScenarioContext.Current.Get<CompilerException>("exception");
            Assert.IsTrue(exception.ExceptionKind == ExceptionKind.Lexical, "No exception was thrown.");
        }

        [Then(@"the resulting tokens should contains these")]
        public void ThenTheResultingTokensShouldContainsThese(List<Token> expectedTokenList)
        {
            var actualTokenList = ScenarioContext.Current.Get<List<Token>>("tokenList");

            foreach (var token in expectedTokenList)
            {
                if (token.TokenType != TokenType.EndOfFile)
                {
                    var tokensOnSameLine = actualTokenList.Where(t => t.Line == token.Line);
                    var tokensOnExactColumn = tokensOnSameLine.Where(t => t.Column == token.Column);
                    var tokenListContainsToken = actualTokenList.Contains(token);
                    Assert.IsTrue(tokenListContainsToken, "Token Types differ");
                }
                else
                {
                    var tokenExists = actualTokenList.Any(t => t.TokenType == TokenType.EndOfFile);
                    Assert.IsTrue(tokenExists);
                }
            }
        }

        [Then(@"the Token should have this lexemme")]
        public void ThenTheTokenShouldHaveThisLexemme(string expectedLexemme)
        {
            ThenTheTokenShouldHaveAsLexemme(expectedLexemme);
        }

        [Then(@"the resulting tokens should be (\d+)")]
        public void ThenTheResultingTokensShouldBe(int expectedTokenCount)
        {
            var tokenList = ScenarioContext.Current.Get<List<Token>>("tokenList");

            Assert.AreEqual(expectedTokenCount, tokenList.Count, "Token count differs");
        }
        [When(@"I get the next available symbol")]
        public void WhenIGetTheNextAvailableSymbol()
        {
            var sourceCodeProvider = ScenarioContext.Current.Get<ISourceCodeReader>("sourceCodeProvider");
            var nextSymbol = sourceCodeProvider.ReadNextSymbol();
            ScenarioContext.Current.Add("nextSymbol", nextSymbol);
        }

        [When(@"I get the next available symbol (.*) times")]
        public void WhenIGetTheNextAvailableSymbolTimes(int numberOfTimes)
        {
            var sourceCodeProvider = ScenarioContext.Current.Get<ISourceCodeReader>("sourceCodeProvider");
            var nextSymbol = SusyConstants.EndOfFile;
            for (int callCount = 1; callCount <= numberOfTimes; callCount++)
            {
                nextSymbol = sourceCodeProvider.ReadNextSymbol();
            }
            ScenarioContext.Current.Add("nextSymbol", nextSymbol);
        }

        [Then(@"the current symbol should be the EndOfFile character")]
        public void ThenTheSymbolShouldBeTheEndOfFileCharacter()
        {
            var nextSymbol = ScenarioContext.Current.Get<char>("nextSymbol");
            Assert.AreEqual(SusyConstants.EndOfFile, nextSymbol);
        }

        [Then(@"the current symbol should be a new line")]
        public void ThenTheCurrentSymbolShouldBeANewLine()
        {
            var nextSymbol = ScenarioContext.Current.Get<char>("nextSymbol");
            Assert.IsTrue(SusyConstants.NewLine == nextSymbol);
        }


        [Then(@"the current symbol should be '(.*)'")]
        public void ThenTheCurrentSymbolShouldBe(char expectedCharacter)
        {
            var nextSymbol = ScenarioContext.Current.Get<char>("nextSymbol");
            Assert.AreEqual(expectedCharacter, nextSymbol);
        }

        [Then(@"the current column should be (\d+)")]
        public void ThenTheCurrentColumnShouldBe(int expectedColumnCount)
        {
            var sourceCodeProvider = ScenarioContext.Current.Get<ISourceCodeReader>("sourceCodeProvider");
            var currentColumn = sourceCodeProvider.CurrentColumn;

            Assert.AreEqual(expectedColumnCount, currentColumn);
        }

        [Then(@"the current line should be (\d+)")]
        public void ThenTheCurrentLineShouldBe(int expectedLineCount)
        {
            var sourceCodeProvider = ScenarioContext.Current.Get<ISourceCodeReader>("sourceCodeProvider");
            var currentLine = sourceCodeProvider.CurrentLine;

            Assert.AreEqual(expectedLineCount, currentLine);
        }
    }
}
