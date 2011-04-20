

namespace Project1.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using OpenQA.Selenium;

    public class EtsySearchResultsPageModel : BasePageModel
    {
        private static readonly By SearchResultsDivSelector = By.Id("primary");
        private static readonly By SearchResultsSelector = By.ClassName("summary");
        private static readonly By SpellingSelector = By.ClassName("spelling");
        private static readonly By FirstResultLinkSelector = By.ClassName("listing-thumb");

        public EtsySearchResultsPageModel(IWebDriver driver)
           : base(driver, SearchResultsDivSelector)
        {
        }
            
        private IWebElement SearchResultsElement
        {
            get { return Driver.FindElement(SearchResultsSelector); }
        }

        private IWebElement SpellingElement
        {
            get { return Driver.FindElement(SpellingSelector); }
        }

        private IWebElement FirstResultLink
        {
            get { return Driver.FindElement(FirstResultLinkSelector); }
        }

        
        public string SearchResultsText()
        {
            return SearchResultsElement.Text;
        }

        public string SpellingText()
        {
            return SpellingElement.Text;
        }

        public EtsyItemPageModel ClickFirstResult()
        {
            FirstResultLink.Click();
            return new EtsyItemPageModel(Driver);
        }
    }
}