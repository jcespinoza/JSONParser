using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Espinoza.JSONParser.Tests.Common.Steps
{
    [Binding]
    public class TokenSteps
    {
        [Given(@"the following Token called ""(.*)""")]
        public void GivenTheFollowingTokenCalled(string tokenName, Token token)
        {
            ScenarioContext.Current.Add(tokenName, token);
        }

        [When(@"I check the two tokens ""(.*)"" and ""(.*)"" for equality")]
        public void WhenICheckTheTwoTokensAndForEquality(string tokenName1, string tokenName2)
        {
            var token1 = ScenarioContext.Current.Get<Token>(tokenName1);
            var token2 = ScenarioContext.Current.Get<Token>(tokenName2);

            var comparisonResult = token1 == token2;
            ScenarioContext.Current.Add("comparisonResult", comparisonResult);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(bool expectation)
        {
            var comparisonResult = ScenarioContext.Current.Get<bool>("comparisonResult");
            Assert.AreEqual(expectation, comparisonResult);
        }
    }
}
