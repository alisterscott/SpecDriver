namespace Project1.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OpenQA.Selenium;

    public class EtsyHomePageModel : BasePageModel
    {
        private static readonly String Url = "http://www.etsy.com";
        private static readonly By EtsyDivSelector = By.Id("etsy");
        private static readonly By EtsyBuyLinkSelector = By.LinkText("Buy");

        public EtsyHomePageModel(IWebDriver driver)
            : base(driver, EtsyDivSelector, Url)
        {
        }

        private IWebElement BuyLinkElement
        {
            get { return Driver.FindElement(EtsyBuyLinkSelector); }
        }

        public EtsyBuyPageModel clickBuy()
        {
            BuyLinkElement.Click();
            return new EtsyBuyPageModel(Driver);
        }


    }
}
