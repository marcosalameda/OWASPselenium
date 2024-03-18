namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Propr02Form: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Bathroom
	/// </summary>
	public BaseInputControl ProprQtd_wc => new BaseInputControl(driver, formLocator, "#PROPR02_PROPRQTD_WC__");
	/// <summary>
	/// Quartos
	/// </summary>
	public BaseInputControl ProprQtdquart => new BaseInputControl(driver, formLocator, "#PROPR02_PROPRQTDQUART");
	/// <summary>
	/// Square meters
	/// </summary>
	public BaseInputControl ProprM2 => new BaseInputControl(driver, formLocator, "#PROPR02_PROPRM2______");
	/// <summary>
	/// Available from
	/// </summary>
	public DateInputControl ProprDtdispon => new DateInputControl(driver, formLocator, "#PROPR02_PROPRDTDISPON");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public Propr02Form(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("PROPR02")).GetAttribute("data-loading") != "true");
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
