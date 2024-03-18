namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DocsdForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Number:
	/// </summary>
	public BaseInputControl OudocNrdocsda => new BaseInputControl(driver, formLocator, "#DOCSD___OUDOCNRDOCSDA");
	/// <summary>
	/// Date:
	/// </summary>
	public DateInputControl OudocDtdocsda => new DateInputControl(driver, formLocator, "#DOCSD___OUDOCDTDOCSDA", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl OudocTitle => new BaseInputControl(driver, formLocator, "#DOCSD___OUDOCTITLE___");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public DocsdForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("DOCSD")).GetAttribute("data-loading") != "true");
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
