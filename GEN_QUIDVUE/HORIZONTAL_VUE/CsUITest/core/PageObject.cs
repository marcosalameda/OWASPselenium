using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Linq;
using System;

namespace quidgest.uitests.core;

/// <summary>
/// Base class for every Page Object Model (POM).
/// </summary>
public class PageObject
{
    protected IWebDriver driver;
    protected WebDriverWait wait;

    public PageObject(IWebDriver driver)
    {
        this.driver = driver;

        // --- MEJORA DE ROBUSTEZ ---
        // Extraemos el valor de ExplicitWait (que ahora es de 30s) de la configuración
        int timeoutMs = Configuration.Instance.ExplicitWait ?? 30000;

        this.wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeoutMs));

        // Mantenemos tu lógica original de ignorar excepciones durante las esperas
        this.wait.IgnoreExceptionTypes(
            typeof(StaleElementReferenceException),
            typeof(NoSuchElementException)
        );
    }

    // Mantenemos todos tus métodos GetElement originales exactamente como están
    protected IWebElement GetElement(IWebElement parent) => parent;

    protected IWebElement GetElement(IWebDriver driver) => null;

    public IWebElement GetElement(IWebElement element, By by)
    {
        if (element == null) return null;

        ReadOnlyCollection<IWebElement> elementList = element.FindElements(by);

        if (!elementList.Any()) return null;

        return elementList[0];
    }

    protected IWebElement GetElement(By by) => driver.FindElement(by);

    protected IWebElement GetElement(IWebDriver driver, By by) => driver.FindElement(by);

    protected IWebElement GetElement(By by, IWebDriver driver) => driver.FindElement(by);

    protected IWebElement GetElement(IWebDriver driver, IWebElement element) => element;
}