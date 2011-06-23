namespace Project1.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OpenQA.Selenium;
    using NUnit.Framework;

    public class EtsyCartPageModel : BasePageModel
    {
        private static readonly String Url = "https://www.etsy.com/cart?ref=so_cart";
        private static readonly By CartHeaderSelector = By.Id("checkout-header");
        private static readonly By RemoveItemSelector = By.LinkText("Remove");
        private static readonly By ItemDetailsDivSelector = By.ClassName("item-details");
       
        public EtsyCartPageModel(IWebDriver driver)
            : base(driver, CartHeaderSelector, Url)
        {
        }

        private IWebElement RemoveItemLinkElement
        {
            get { return Driver.FindElement(RemoveItemSelector); }
        }

        private IWebElement FirstItemTitleElement
        {
            get { return Driver.FindElement(ItemDetailsDivSelector).FindElement(By.TagName("h3")); }
        }

        private IWebElement CheckOutHeaderElement
        {
           get { return Driver.FindElement(CartHeaderSelector).FindElement(By.TagName("h1")); }
        }

        public string ItemsInCart()
        {
            System.Threading.Thread.Sleep(2000);
            return CheckOutHeaderElement.Text;       
        }

        public bool IsCartEmpty()
        {
            for (var i = 0; i < 5; i++)
            {
                if (ItemsInCart() == "0 items in your cart")
                {
                    return true;
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }
            return false;
        }

        public void RemoveOneItem()
        {
            RemoveItemLinkElement.Click();
        }

        public void EnsureCartEmpty()
        {
            for (var i = 0; i < 100; i++)
            {
                if (ItemsInCart() != "0 items in your cart")
                {
                    RemoveItemLinkElement.Click();
                }
                else
                {
                    break;
                }
            }
        }

        public string FirstItemTitle()
        {
            return FirstItemTitleElement.Text;
        }
    }
}
