﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Espinoza.JSONParser.Tests.Lexicon.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class SourceCodeProviderSpecsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SourceCodeReaderSpecs.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Source Code Provider Specs", "\tIn order to parse source code\r\n\tAs a Compilers writer\r\n\tI want to have an accura" +
                    "te source code manager", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Source Code Provider Specs")))
            {
                Espinoza.JSONParser.Tests.Lexicon.Specs.SourceCodeProviderSpecsFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Reading one symbol yields the right character")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Source Code Provider Specs")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Lexicon")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("HappyPath")]
        public virtual void ReadingOneSymbolYieldsTheRightCharacter()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Reading one symbol yields the right character", new string[] {
                        "Lexicon",
                        "HappyPath"});
#line 8
 this.ScenarioSetup(scenarioInfo);
#line hidden
#line 9
  testRunner.Given("a source code string", "", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 12
  testRunner.When("I get the next available symbol", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
  testRunner.Then("the current symbol should be the EndOfFile character", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Reading one symbol increments the right counters")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Source Code Provider Specs")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Lexicon")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("HappyPath")]
        public virtual void ReadingOneSymbolIncrementsTheRightCounters()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Reading one symbol increments the right counters", new string[] {
                        "Lexicon",
                        "HappyPath"});
#line 17
 this.ScenarioSetup(scenarioInfo);
#line hidden
#line 18
  testRunner.Given("a source code string", "[]", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
  testRunner.When("I get the next available symbol", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
  testRunner.Then("the current symbol should be \'[\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
  testRunner.And("the current column should be 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Reading one symbol many times increments the column counter")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Source Code Provider Specs")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Lexicon")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("HappyPath")]
        public virtual void ReadingOneSymbolManyTimesIncrementsTheColumnCounter()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Reading one symbol many times increments the column counter", new string[] {
                        "Lexicon",
                        "HappyPath"});
#line 28
 this.ScenarioSetup(scenarioInfo);
#line hidden
#line 29
  testRunner.Given("a source code string", "{ \"name\": \"test\" }", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 33
  testRunner.When("I get the next available symbol 5 times", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
  testRunner.Then("the current symbol should be \'a\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
  testRunner.And("the current column should be 5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
  testRunner.And("the current line should be 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Reading repeatedly one symbol until the new line keeps the line counter")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Source Code Provider Specs")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Lexicon")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("HappyPath")]
        public virtual void ReadingRepeatedlyOneSymbolUntilTheNewLineKeepsTheLineCounter()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Reading repeatedly one symbol until the new line keeps the line counter", new string[] {
                        "Lexicon",
                        "HappyPath"});
#line 40
 this.ScenarioSetup(scenarioInfo);
#line hidden
#line 41
  testRunner.Given("a source code string", "{ \"name\": \"test\" }\r\n[]", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 46
  testRunner.When("I get the next available symbol 19 times", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
  testRunner.Then("the current symbol should be a new line", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
  testRunner.And("the current column should be 19", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
  testRunner.And("the current line should be 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Reading repeatedly one symbol until the next line updates the line and column cou" +
            "nters")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Source Code Provider Specs")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Lexicon")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("HappyPath")]
        public virtual void ReadingRepeatedlyOneSymbolUntilTheNextLineUpdatesTheLineAndColumnCounters()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Reading repeatedly one symbol until the next line updates the line and column cou" +
                    "nters", new string[] {
                        "Lexicon",
                        "HappyPath"});
#line 53
 this.ScenarioSetup(scenarioInfo);
#line hidden
#line 54
  testRunner.Given("a source code string", "{ \"name\": \"test\" }\r\n[]", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 59
  testRunner.When("I get the next available symbol 20 times", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
  testRunner.Then("the current symbol should be \'[\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
  testRunner.And("the current column should be 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
  testRunner.And("the current line should be 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
