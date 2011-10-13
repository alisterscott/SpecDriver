namespace Project1
{
    using System;
    using OpenQA.Selenium;

    public static class WebElementExtensions
    {
        public static void Set(this IWebElement me, string text)
        {
            me.Clear();
            me.SendKeys(text);
        }

        public static IWebElement GetElement(this IWebDriver driver, By selector)
        {
            for (int i = 1; i <= 20; i++)
            {
                try
                {
                    return driver.FindElement(selector);
                }
                catch (OpenQA.Selenium.WebDriverException e)
                {
                    Console.WriteLine("Error " + i + " raised: " + e.Message);
                }
            }
            return null;
        }

        public static IWebElement GetElement(this IWebElement element, By selector)
        {
            for (int i = 1; i <= 20; i++)
            {
                try
                {
                    return element.FindElement(selector);
                }
                catch (OpenQA.Selenium.WebDriverException e)
                {
                    if (e.Message.Contains("No response from server for url"))
                    {
                        Console.WriteLine("Error " + i + " raised: " + e.Message);
                    }
                    else
                    {
                        throw e;
                    }
                }
            }
            return null;
        }
    }
}
