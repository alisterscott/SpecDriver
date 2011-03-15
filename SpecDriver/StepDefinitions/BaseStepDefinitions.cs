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
        public static IWebDriver Driver { get; set; }
        protected GoogleHomePageModel GoogleHomePage { get; set; }
        protected GoogleSearchResultsPageModel GoogleSearchResultsPage { get; set; }

    }
}
