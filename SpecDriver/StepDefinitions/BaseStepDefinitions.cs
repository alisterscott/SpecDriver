using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Project1.Pages;

namespace Project1.StepDefinitions
{
    [Binding]
    public class BaseStepDefinitions
    {
        private const string CurrentPageKey = "Current.Page";
        public static IWebDriver Driver { get; set; }
        protected GoogleHomePageModel GoogleHomePage
        {
            get { return (GoogleHomePageModel)ScenarioContext.Current[CurrentPageKey]; }
            set { ScenarioContext.Current[CurrentPageKey] = value; }
        }
        protected GoogleSearchResultsPageModel GoogleSearchResultsPage
        {
            get { return (GoogleSearchResultsPageModel)ScenarioContext.Current[CurrentPageKey]; }
            set { ScenarioContext.Current[CurrentPageKey] = value; }
        }
    }
}
