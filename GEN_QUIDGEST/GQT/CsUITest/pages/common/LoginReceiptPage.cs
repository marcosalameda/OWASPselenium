using System;
using quidgest.uitests.core;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;

public class LoginReceiptPage: PageObject {

	//private final static Logger LOGGER = LoggerFactory.getLogger(LoginReceiptPage.class.getName());

	private IWebElement userAvatar;

	private IWebElement textError;

	public LoginReceiptPage(IWebDriver driver): base(driver) {
		userAvatar = driver.FindElement(By.CssSelector("button.UserAvatar"));
		textError = driver.FindElement(By.CssSelector("#formLoginValidation.i-text__error"));
	}

	public bool checkUserAvatar() {
		wait.Until(c => userAvatar.Displayed);
		return userAvatar.Displayed;
	}

	public bool checkErrorMessage() {
		wait.Until(c => textError.Displayed);
		return textError.Displayed;
	}

	public bool checkValid() {
		try {
			return checkUserAvatar();
		} catch(TimeoutException) {
			//LOGGER.warn("User avatar not found.");
		}
		return checkErrorMessage();
	}

	public bool checkInvalid() {
		try {
			return checkErrorMessage();
		} catch(TimeoutException) {
			//LOGGER.warn("Login error message not found.");
		}
		return !checkUserAvatar();
	}

}
