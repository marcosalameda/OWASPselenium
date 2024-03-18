namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArmazForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Acronym
	/// </summary>
	public BaseInputControl WarehWarehcod => new BaseInputControl(driver, formLocator, "#ARMAZ___WAREHWAREHCOD");
	/// <summary>
	/// Warehouse
	/// </summary>
	public BaseInputControl WarehWarehdes => new BaseInputControl(driver, formLocator, "#ARMAZ___WAREHWAREHDES");
	/// <summary>
	/// Activity
	/// </summary>
	public EnumControl WarehActivity => new EnumControl(driver, formLocator, "container-ARMAZ___WAREHACTIVITY");
	/// <summary>
	/// Show Record
	/// </summary>
	public CheckboxInputControl WarehShowreco => new CheckboxInputControl(driver, formLocator, "#container-ARMAZ___WAREHSHOWRECO");
	/// <summary>
	/// Employee
	/// </summary>
	public ListControl PseudPessarma => new ListControl(driver, formLocator, "#ARMAZ___PSEUDPESSARMA");
	/// <summary>
	/// Open form
	/// </summary>
	public ButtonControl PseudExposetb => new ButtonControl(driver, formLocator, "#ARMAZ___PSEUDEXPOSETB");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public ArmazForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ARMAZ")).GetAttribute("data-loading") != "true");
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
