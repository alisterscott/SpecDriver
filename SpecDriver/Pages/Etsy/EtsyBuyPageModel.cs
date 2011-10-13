namespace Project1.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OpenQA.Selenium;

    public class EtsyBuyPageModel : BasePageModel
    {
        private static readonly By EtsyHeadingSelector = By.ClassName("heading");
        private static readonly By TreasuryPanelButtonSelector = By.Id("treasury-panel-button");

        public EtsyBuyPageModel(IWebDriver driver)
            : base(driver, EtsyHeadingSelector)
        {
        }

        private IWebElement TreasuryPanelButtonElement
        {
            get { return Driver.GetElement(TreasuryPanelButtonSelector); }
        }

        public EtsyTreasuryPageModel ClickTreasuryButton()
        {
            TreasuryPanelButtonElement.Click();
            return new EtsyTreasuryPageModel(Driver);
        }
    }
}
