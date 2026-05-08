using OpenQA.Selenium;

namespace OpenQA.Selenium
{
    public static class IWebElementSelectCompatibilityExtensions
    {
        public static void SelectOption(this IWebElement element, string value) { }
        public static void SelectOption(this IWebElement element, int value) { }
    }
}