namespace Project1.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OpenQA.Selenium;
    using NUnit.Framework;

    public class EtsyTreasuryPageModel : BasePageModel
    {
        private static readonly By EtsyHeadingSelector = By.ClassName("heading");
        private static readonly By GallerySelector = By.ClassName("list-treasury");
        private static readonly By ItemSelector = By.ClassName("item-treasury");
        private static readonly By HotnessSelector = By.ClassName("item-treasury-hotness");
        private static readonly By InfoSelector = By.ClassName("item-treasury-info");
        private static readonly By StatsSelector = By.ClassName("item-treasury-stats");
        private static readonly By PreviewSelector = By.ClassName("item-treasury-preview");

        public EtsyTreasuryPageModel(IWebDriver driver)
            : base(driver, EtsyHeadingSelector)
        {
        }

        private IWebElement TreasuryListing
        {
            get { return Driver.GetElement(GallerySelector); }
        }

        private IWebElement TreasuryItem
        {
            get { return TreasuryListing.GetElement(ItemSelector); }
        }

        private IWebElement HotnessElement
        {
            get { return TreasuryItem.GetElement(HotnessSelector); }
        }

        private IWebElement InfoElement
        {
            get { return TreasuryItem.GetElement(InfoSelector); }
        }

        private IWebElement StatsElement
        {
            get { return TreasuryItem.GetElement(StatsSelector); }
        }

        private IWebElement PreviewElement
        {
            get { return TreasuryItem.GetElement(PreviewSelector); }
        }

        public void AssertGalleryPresent()
        {
            Assert.IsTrue(TreasuryListing.Enabled);
            Assert.IsTrue(TreasuryItem.Enabled);
            Assert.IsTrue(HotnessElement.Enabled);
            Assert.IsTrue(InfoElement.Enabled);
            Assert.IsTrue(StatsElement.Enabled);
            Assert.IsTrue(PreviewElement.Enabled);
        }
    }
}
