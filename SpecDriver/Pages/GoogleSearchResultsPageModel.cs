using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace Project1.Pages
{
    public class GoogleSearchResultsPageModel : BasePageModel
    {
        private static readonly By NumberResultsDivSelector = By.Id("resultStats");
        private static readonly By ConversionResultsH2Selector = By.ClassName("r");

        public GoogleSearchResultsPageModel(IWebDriver driver)
            : base(driver, NumberResultsDivSelector)
        {
        }

        private IWebElement NumberResultsDivElement
        {
            get { return Driver.FindElement(NumberResultsDivSelector); }
        }

        private IWebElement ConversionResultsH2Element
        {
            get { return Driver.FindElement(ConversionResultsH2Selector); }
        }

        public string NumberOfResults
        {
            get
            {
                Match match = (new Regex(@"About (.+) results")).Match(this.NumberResultsDivElement.Text);
                return match.Groups[1].Value.Replace(",","");
            }
        }

        public string ConversionResult
        {
            get { return this.ConversionResultsH2Element.Text; }
        }
    }
}
