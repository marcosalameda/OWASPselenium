using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using quidgest.uitests.core;

namespace quidgest.uitests.controls;


public class BaseInputControl: PageObject {

    IWebElement loginInput => driver.FindElement(By.CssSelector(css));

    private string css;

    public BaseInputControl(IWebDriver driver, string css): base(driver) {
        this.css = css;
    }

    public string GetValue() {
        return loginInput.GetAttribute("value");
    }

    public void SetValue(string val) {
        loginInput.SendKeys(val);
    }
}