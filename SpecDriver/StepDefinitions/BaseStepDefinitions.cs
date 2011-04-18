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
        protected EtsySearchPageModel EtsySearchPage
        {
            get { return (EtsySearchPageModel)ScenarioContext.Current[CurrentPageKey]; }
            set { ScenarioContext.Current[CurrentPageKey] = value; }
        }
        protected EtsySearchResultsPageModel EtsySearchResultsPage
        {
            get { return (EtsySearchResultsPageModel)ScenarioContext.Current[CurrentPageKey]; }
            set { ScenarioContext.Current[CurrentPageKey] = value; }
        }
        protected EtsyHomePageModel EtsyHomePage
        {
            get { return (EtsyHomePageModel)ScenarioContext.Current[CurrentPageKey]; }
            set { ScenarioContext.Current[CurrentPageKey] = value; }
        }
        protected EtsyBuyPageModel EtsyBuyPage
        {
            get { return (EtsyBuyPageModel)ScenarioContext.Current[CurrentPageKey]; }
            set { ScenarioContext.Current[CurrentPageKey] = value; }
        }
        protected EtsyTreasuryPageModel EtsyTreasuryPage
        {
            get { return (EtsyTreasuryPageModel)ScenarioContext.Current[CurrentPageKey]; }
            set { ScenarioContext.Current[CurrentPageKey] = value; }
        }
        protected EtsyCartPageModel EtsyCartPage
        {
            get { return (EtsyCartPageModel)ScenarioContext.Current[CurrentPageKey]; }
            set { ScenarioContext.Current[CurrentPageKey] = value; }
        }
        protected EtsyItemPageModel EtsyItemPage
        {
            get { return (EtsyItemPageModel)ScenarioContext.Current[CurrentPageKey]; }
            set { ScenarioContext.Current[CurrentPageKey] = value; }
        }



    }
}
