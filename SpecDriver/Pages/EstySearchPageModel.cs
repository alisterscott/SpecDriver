namespace Project1.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OpenQA.Selenium;

    public class EtsySearchPageModel : BasePageModel
    {
        private static readonly String Url = "http://www.etsy.com/search_advanced.php";
        private static readonly By AdvancedSearchDivSelector = By.Id("advanced-search");
        private static readonly By SearchCategoryDivSelector = By.ClassName("search-category");
        private static readonly By SearchSelector = By.Id("search_query");
        private static readonly By SearchButtonSelector = By.TagName("button");

        public EtsySearchPageModel(IWebDriver driver)
            : base(driver, AdvancedSearchDivSelector, Url)
        {
        }

        private IWebElement SearchCategoryComboElement
        {
            get { return Driver.FindElement(SearchCategoryDivSelector).FindElement(By.TagName("select")); }
        }

        private IWebElement AdvancedSearchFieldElement
        {
            get { return Driver.FindElement(AdvancedSearchDivSelector).FindElement(SearchSelector); }
        }

        private IWebElement SearchButtonElement
        {
            get { return Driver.FindElement(AdvancedSearchDivSelector).FindElement(SearchButtonSelector); }
        }

        public void SpecifySubCategory(String subCategory)
        {
            this.SearchCategoryComboElement.Set(subCategory);
        }

        public EtsySearchResultsPageModel SearchForSomething(String term)
        {
            this.AdvancedSearchFieldElement.Set(term);
            this.SearchButtonElement.Click();
            return new EtsySearchResultsPageModel(Driver);
        }
    }
}
