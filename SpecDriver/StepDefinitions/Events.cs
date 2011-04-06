namespace Project1.StepDefinitions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using TechTalk.SpecFlow;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;

    [Binding]
    public class Events : BaseStepDefinitions
    {
        private const string GoogleUrl = "http://google.com";

        [BeforeTestRun]
        public static void StartWebDriver()
        {
            // Using BeforeFeature, because AfterTestRun doesn't work (SpecFlow Defect#26)
            // Driver = new FirefoxDriver();
            // Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 5));
        }

        [BeforeFeature]
        public static void StartWebDriverForReal()
        {
            Driver = new FirefoxDriver();
            Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 5));
        }

        [BeforeScenario]
        public static void GoToHomePage()
        {
            Thread.Sleep(1000); // between scenarios can be problematic when running too fast 
            Driver.Navigate().GoToUrl(GoogleUrl);
        }

        [AfterScenario]
        public static void AfterScenario()
        {
        }

        [AfterFeature]
        public static void killBrowser()
        {
            Driver.Close();
        }

        [AfterTestRun]
        public static void TerminateWebDriver()
        {
            // Never Triggered due to Defect https://github.com/techtalk/SpecFlow/issues/#issue/26
            Driver.Close();
        }
    }
}
