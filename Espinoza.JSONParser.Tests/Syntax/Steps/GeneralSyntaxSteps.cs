using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace Espinoza.JSONParser.Tests.Syntax.Steps
{
    [Binding]
    public class GeneralSyntaxSteps
    {
        [Given(@"a new Syntax Component")]
        public void GivenANewSyntaxComponent()
        {
            var lexer = ScenarioContext.Current.Get<ILexer>("newLexer");
            var parser = new SyntaxAnalyzer(lexer);
            ScenarioContext.Current.Add("parser", parser);
        }

        [When(@"I run syntax analysis on it")]
        public void WhenIRunSyntaxAnalysisOnIt()
        {
            var parser = ScenarioContext.Current.Get<SyntaxAnalyzer>("parser");
            try
            {
                parser.Parse();
            }
            catch (CompilerException exception)
            {
                ScenarioContext.Current.Add("exception", exception);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [Then(@"the operation should raise a syntax error")]
        public void ThenTheOperationShouldRaiseASyntaxError()
        {
            var exception = ScenarioContext.Current.Get<CompilerException>("exception");
            Assert.IsTrue(exception.ExceptionKind == ExceptionKind.Syntactic, exception.Message);
        }
    }
}
