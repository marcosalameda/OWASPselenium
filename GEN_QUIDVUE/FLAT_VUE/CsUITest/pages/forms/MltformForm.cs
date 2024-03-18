namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class MltformForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Warehouse
	/// </summary>
	public BaseInputControl WarehWarehdes => new BaseInputControl(driver, formLocator, "#MLTFORM_WAREHWAREHDES");
	/// <summary>
	/// Acronym
	/// </summary>
	public BaseInputControl WarehWarehcod => new BaseInputControl(driver, formLocator, "#MLTFORM_WAREHWAREHCOD");
	/// <summary>
	/// Warehouse employees
	/// </summary>
	public IWebElement PseudMltform1 => throw new NotImplementedException();

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public MltformForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("MLTFORM")).GetAttribute("data-loading") != "true");
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
