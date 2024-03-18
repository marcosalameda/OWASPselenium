namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CamenumForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Numeric enumeration
	/// </summary>
	public RadiobuttonControl FldsClassnum => new RadiobuttonControl(driver, formLocator, "container-CAMENUM_FLDS_CLASSNUM");
	/// <summary>
	/// Text Enumeration
	/// </summary>
	public EnumControl FldsClass => new EnumControl(driver, formLocator, "container-CAMENUM_FLDS_CLASS___");
	/// <summary>
	/// Logical Enumeration
	/// </summary>
	public EnumControl FldsLogicenu => new EnumControl(driver, formLocator, "container-CAMENUM_FLDS_LOGICENU");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public CamenumForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("CAMENUM")).GetAttribute("data-loading") != "true");
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
