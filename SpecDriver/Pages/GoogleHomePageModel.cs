namespace Project1.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OpenQA.Selenium;

    public class GoogleHomePageModel : BasePageModel
    {
        private static readonly By SearchEditSelector = By.Name("q");
        private static readonly By SearchButtonSelector = By.Name("btnG");

        public GoogleHomePageModel(IWebDriver driver)
            : base(driver, SearchEditSelector)
        {
        }

        private IWebElement SearchEditElement
        {
             get { return Driver.FindElement(SearchEditSelector); }
        }

        private IWebElement SearchButtonElement
        {
            get { return Driver.FindElement(SearchButtonSelector); }
        }

        public GoogleSearchResultsPageModel Search(string term)
        {
            this.SearchEditElement.Set(term);
            this.SearchEditElement.SendKeys(Keys.Escape);
            this.SearchButtonElement.Click();
            return new GoogleSearchResultsPageModel(Driver);
        }
    }
}
