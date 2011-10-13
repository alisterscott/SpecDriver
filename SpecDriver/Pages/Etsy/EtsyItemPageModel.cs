namespace Project1.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using OpenQA.Selenium;

    public class EtsyItemPageModel : BasePageModel
    {
        private static readonly By AddToCartSelector = By.ClassName("buy-button");
        private static readonly By ItemTitleSelector = By.Id("item-title");

        public EtsyItemPageModel(IWebDriver driver)
           : base(driver, AddToCartSelector)
        {
        }

        private IWebElement ItemTitleElement
        {
            get { return Driver.GetElement(ItemTitleSelector); }
        }

        private IWebElement AddToCartElement
        {
            get { return Driver.GetElement(AddToCartSelector); }
        }

        public EtsyCartPageModel ClickAddToCart()
        {
            AddToCartElement.Click();
            return new EtsyCartPageModel(Driver);
        }

        public string ItemTitle()
        {
            return ItemTitleElement.Text;
        }
    }
}