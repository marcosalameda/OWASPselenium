namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ProppaisForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Country
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, formLocator, "#PROPPAISPSEUDNOVOGR02-container");
	/// <summary>
	/// Designation:
	/// </summary>
	public BaseInputControl CntryCountry => new BaseInputControl(driver, formLocator, "#PROPPAISCNTRYCOUNTRY_");
	/// <summary>
	/// Active
	/// </summary>
	public CheckboxInputControl CntryActive => new CheckboxInputControl(driver, formLocator, "#container-PROPPAISCNTRYACTIVE__");
	/// <summary>
	/// Country code
	/// </summary>
	public IWebElement PseudNovogr01 => throw new NotImplementedException();
	/// <summary>
	/// Numeric
	/// </summary>
	public BaseInputControl CntryCodigonr => new BaseInputControl(driver, formLocator, "#PROPPAISCNTRYCODIGONR");
	/// <summary>
	/// Alphabetic 2:
	/// </summary>
	public BaseInputControl CntryAlfa2 => new BaseInputControl(driver, formLocator, "#PROPPAISCNTRYALFA2___");
	/// <summary>
	/// Alphabetic 3:
	/// </summary>
	public BaseInputControl CntryAlfa3 => new BaseInputControl(driver, formLocator, "#PROPPAISCNTRYALFA3___");
	/// <summary>
	/// Properties
	/// </summary>
	public IWebElement PseudPropried => throw new NotImplementedException();

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public ProppaisForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("PROPPAIS")).GetAttribute("data-loading") != "true");
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
