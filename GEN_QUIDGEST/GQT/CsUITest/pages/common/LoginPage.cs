using System;
using quidgest.uitests.core;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;

public class LoginPage: PageObject {

	private IWebElement username => driver.FindElement(By.Id("UserName"));
	private IWebElement password => driver.FindElement(By.Id("Password"));
	private IWebElement submitButton => driver.FindElement(By.CssSelector("button.b-icon-text--login"));


	public LoginPage(IWebDriver driver) : base(driver) {

		// Check if we are on the right page.
		if (!driver.Url.Contains("Account/LogOn")) {
			// Alternatively, we could navigate to the login page, perhaps logging out first.
			throw new Exception("WebDriver is not on the login page.");
		}

		wait.Until(c => submitButton != null);
	}
/*
	public bool isInitialized() {
		wait.Until(c => submitButton.Displayed);
		return this.submitButton.Displayed;
	}
*/
	public void login(string username, string password) {
		//wait.Until(c => submitButton.Displayed);

		this.username.Clear();
		this.username.SendKeys(username);

		this.password.Clear();
		this.password.SendKeys(password);

		this.submitButton.Click();

/*
		// HACK: wait a bit for the result page to load
		try {
			Thread.sleep(1000);
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
*/
		//return new LoginReceiptPage(driver);
	}
/*
	public LoginReceiptPage login(string username, string password) {
		// TODO: document, maybe move the timeout to a config variable
		return login(username, password, TimeSpan.FromMilliseconds(10));
	}
	*/
}
