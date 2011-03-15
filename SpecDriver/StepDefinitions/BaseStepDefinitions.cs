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
        //private const string CurrentPageKey = "current.page";

        //protected dynamic CurrentPage
        //{
        //    get
        //    {
        //        return (BasePageModel)ScenarioContext.Current[CurrentPageKey];
         //   }

         //   set
          //  {
           //     ScenarioContext.Current[CurrentPageKey] = value;
           // }
        //}

        public static IWebDriver Driver { get; set; }
        protected GoogleHomePageModel GoogleHomePage { get; set; }
        protected GoogleSearchResultsPageModel GoogleSearchResultsPage { get; set; }

    }
}
