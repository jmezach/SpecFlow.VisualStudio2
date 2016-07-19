using System;
using TechTalk.SpecFlow;

namespace SpecFlow.VisualStudio.Tests
{
    [Binding]
    public class TableFormattingSteps
    {
        [Given(@"a valid feature file with the following steps exists:")]
        public void GivenAValidFeatureFileWithTheFollowingStepsExists(string multilineText)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I execute the formatting shortcut")]
        public void WhenIExecuteTheFormattingShortcut()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the following formatted feature exists:")]
        public void ThenTheFollowingFormattedFeatureExists(string multilineText)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
