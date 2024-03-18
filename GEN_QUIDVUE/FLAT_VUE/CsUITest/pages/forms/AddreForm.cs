namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AddreForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Address Use
	/// </summary>
	public EnumControl AddreAddruse => new EnumControl(driver, formLocator, "container-ADDRE___ADDREADDRUSE_");
	/// <summary>
	/// Address Type
	/// </summary>
	public EnumControl AddreAddrtype => new EnumControl(driver, formLocator, "container-ADDRE___ADDREADDRTYPE");
	/// <summary>
	/// Entire address
	/// </summary>
	public BaseInputControl AddreAddrtext => new BaseInputControl(driver, formLocator, "#ADDRE___ADDREADDRTEXT");
	/// <summary>
	/// Address City
	/// </summary>
	public BaseInputControl AddreAddrcity => new BaseInputControl(driver, formLocator, "#ADDRE___ADDREADDRCITY");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public AddreForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ADDRE")).GetAttribute("data-loading") != "true");
    }

	public void Save() {
		WaitForLoading();
		saveBtn.Click();
	}

	public void Cancel() {
		WaitForLoading();
		cancelBtn.Click();
	}

}
