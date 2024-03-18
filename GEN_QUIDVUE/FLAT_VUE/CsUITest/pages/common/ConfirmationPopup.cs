namespace quidgest.uitests.pages;

public class ConfirmationPopup: PageObject {

    IWebElement dialog => driver.FindElement(By.CssSelector(".swal2-popup[role='dialog']"));
    IWebElement buttonOk => dialog.FindElement(By.CssSelector("button.swal2-confirm"));
    IWebElement buttonCancel => dialog.FindElement(By.CssSelector("button.swal2-cancel"));
    IWebElement buttonDeny => dialog.FindElement(By.CssSelector("button.swal2-deny"));

    public ConfirmationPopup(IWebDriver driver): base(driver) {
		wait.Until(c => dialog );
        wait.Until(c => dialog.Displayed);
	}

    public void Confirm()
    {
        buttonOk.AnimatedClick();
    }

    public void Cancel()
    {
        buttonCancel.AnimatedClick();
    }

    public void Deny()
    {
        buttonDeny.AnimatedClick();
    }

}
