namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Armaz01Form: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Code:
	/// </summary>
	public BaseInputControl WarehWarehcod => new BaseInputControl(driver, formLocator, "#ARMAZ01_WAREHWAREHCOD");
	/// <summary>
	/// Activity:
	/// </summary>
	public BaseInputControl WarehActivity => new BaseInputControl(driver, formLocator, "#ARMAZ01_WAREHACTIVITY");
	/// <summary>
	/// Warehouse:
	/// </summary>
	public BaseInputControl WarehWarehdes => new BaseInputControl(driver, formLocator, "#ARMAZ01_WAREHWAREHDES");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public Armaz01Form(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ARMAZ01")).GetAttribute("data-loading") != "true");
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
