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

        public static void SelectValue(this IWebElement me, string text)
        {
            me.ItemInCombo(text).Select();
        }

        private static IWebElement ItemInCombo(this IWebElement me, string text)
        {
            var itemsInCombo = me.FindElements(By.TagName("option"));
            foreach (var item in itemsInCombo)
            {
                if (item.Text == text)
                {
                    return item;
                }
            }

            throw new Exception("Could not locate item of '" + text + "'in Combobox: '" + me.ToString() + "'");
        }



    }

    

}
