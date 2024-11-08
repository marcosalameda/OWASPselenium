using System;
using OpenQA.Selenium;
using quidgest.uitests.core;
using quidgest.uitests.controls;

namespace quidgest.uitests.pages;


public class ConfirmationPopup: PageObject {

    IWebElement dialog => driver.FindElement(By.CssSelector("[role='dialog'] .modal-dialog"));
    IWebElement buttonOk => dialog.FindElement(By.CssSelector("button.b-icon-text--primary"));
    IWebElement buttonCancel => dialog.FindElement(By.CssSelector("button.b-icon-text--secondary"));

	public ConfirmationPopup(IWebDriver driver): base(driver) {
		wait.Until(c => dialog != null );
        wait.Until(c => dialog.Displayed);
	}

    public void Confirm()
    {
        buttonOk.Click();
    }

    public void Deny()
    {
        buttonCancel.Click();
    }

}
