namespace Project1
{
    using OpenQA.Selenium;

    public static class WebElementExtensions
    {
        public static void Set(this IWebElement me, string text)
        {
            me.Clear();
            me.SendKeys(text);
        }
    }
}
