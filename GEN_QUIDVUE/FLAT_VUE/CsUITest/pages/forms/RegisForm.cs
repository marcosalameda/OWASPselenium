namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RegisForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// REGISTRATION IN THE PLATFORM
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#REGIS___PSEUDNOVOGR01-container");
	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl RegisName => new BaseInputControl(driver, formLocator, "#REGIS___REGISNAME____");
	/// <summary>
	/// Tax ID No:
	/// </summary>
	public BaseInputControl RegisNif => new BaseInputControl(driver, formLocator, "#REGIS___REGISNIF_____");
	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl RegisTelephon => new BaseInputControl(driver, formLocator, "#REGIS___REGISTELEPHON");
	/// <summary>
	/// Email:
	/// </summary>
	public BaseInputControl RegisEmail1 => new BaseInputControl(driver, formLocator, "#REGIS___REGISEMAIL1__");
	/// <summary>
	/// Alternative Email
	/// </summary>
	public BaseInputControl RegisEmail2 => new BaseInputControl(driver, formLocator, "#REGIS___REGISEMAIL2__");
	/// <summary>
	/// @required
	/// </summary>
	public IWebElement PseudObrigato => throw new NotImplementedException();

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public RegisForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("REGIS")).GetAttribute("data-loading") != "true");
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
