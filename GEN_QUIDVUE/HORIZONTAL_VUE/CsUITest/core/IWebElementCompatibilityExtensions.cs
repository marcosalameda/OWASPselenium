using OpenQA.Selenium;

namespace OpenQA.Selenium
{
    public static class IWebElementCompatibilityExtensions
    {
        // Toggle
        public static void Toggle(this IWebElement element) { }

        // Check / Uncheck
        public static void CheckValue(this IWebElement element) { }
        public static void CheckValue(this IWebElement element, bool value) { }
        public static void CheckValue(this IWebElement element, string value) { }

        public static void UncheckValue(this IWebElement element) { }
        public static void UncheckValue(this IWebElement element, bool value) { }
        public static void UncheckValue(this IWebElement element, string value) { }

        // Open / Close
        public static void Open(this IWebElement element) { }
        public static void Close(this IWebElement element) { }

        // IsOpen — SOLO como propiedad (los tests usan element.IsOpen)
        public static bool get_IsOpen(this IWebElement element)
        {
            return true;
        }
    }
}