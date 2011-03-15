using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Project1.Pages;

namespace Project1.StepDefinitions
{
    [Binding]
    public class GoogleSearchStepDefinitions : BaseStepDefinitions
    {

        [Given(@"I am on the Google Home Page")]
        public void GivenIAmOnTheGoogleHomePage()
        {
            GoogleHomePage = new GoogleHomePageModel(Driver);
            Assert.AreEqual("Google", GoogleHomePage.Title);
        }

        [When(@"I search for ""(.+)""")]
        public void WhenISearchForSomething(string searchTerm)
        {
            GoogleSearchResultsPage = GoogleHomePage.Search(searchTerm);
        }
        
        [When(@"I search for a ridiculously small number of results")]
        public void WhenISearchForARidiculouslySmallNumberOfResults()
        {
            GoogleSearchResultsPage = GoogleHomePage.Search("macrocryoglobulinemia marvel");
        }

        [When(@"I convert (.+)")]
        public void WhenIConvertSomething(string ConversionString)
        {
            GoogleSearchResultsPage = GoogleHomePage.Search("convert " + ConversionString);
        }

        [Then(@"I should see at most ([\d,]+) results")]
        public void ThenIShouldSeeAtMostNumberOfResults(string expMaxNumberResults)
        {
            expMaxNumberResults = expMaxNumberResults.Replace(",", "");
            Assert.LessOrEqual(Convert.ToInt32(GoogleSearchResultsPage.NumberOfResults), Convert.ToInt32(expMaxNumberResults));
        }

        [Then(@"I should see at least ([\d,]+) results")]
        public void ThenIShouldSeeAtLeastNumberOfResults(string expMinNumberResults)
        {
            expMinNumberResults = expMinNumberResults.Replace(",", "");
            Assert.GreaterOrEqual(Convert.ToInt32(GoogleSearchResultsPage.NumberOfResults), Convert.ToInt32(expMinNumberResults));
        }

        [Then(@"I should see the conversion result ""(.+)""")]
        public void ThenIShouldSeeTheConversionResult(string expectedConversionResult)
        {
            Assert.AreEqual(expectedConversionResult, GoogleSearchResultsPage.ConversionResult);
        }
    }
}