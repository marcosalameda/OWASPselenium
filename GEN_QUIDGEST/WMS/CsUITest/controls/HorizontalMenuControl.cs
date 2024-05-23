using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using quidgest.uitests.core;

namespace quidgest.uitests.controls;

public class HorizontalMenuControl: PageObject, IMenuControl {

    private IWebElement navbar => driver.FindElement(By.Id("menuNavbar"));

    public HorizontalMenuControl(IWebDriver driver): base(driver) {
        wait.Until(c => navbar != null);
    }

    public void Navigate(string itemId)
    {
        navbar.FindElement(By.CssSelector("a[menu-id='"+itemId+"']"))
            .Click();
    }
}