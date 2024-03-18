namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArmazpopForm: PageObject {

	private By formLocator = By.CssSelector("#q-modal-form-ARMAZPOP");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Identification
	/// </summary>
	public TabControl PseudArmaz01 => new TabControl(driver, formLocator, "#tab-container-ARMAZPOPPSEUDARMAZ01_");
	/// <summary>
	/// Item
	/// </summary>
	public TabControl PseudArmaz02 => new TabControl(driver, formLocator, "#tab-container-ARMAZPOPPSEUDARMAZ02_");
	/// <summary>
	/// Code:
	/// </summary>
	public BaseInputControl Armaz01WarehWarehcod => new BaseInputControl(driver, formLocator, "#ARMAZ01_WAREHWAREHCOD");
	/// <summary>
	/// Activity:
	/// </summary>
	public BaseInputControl Armaz01WarehActivity => new BaseInputControl(driver, formLocator, "#ARMAZ01_WAREHACTIVITY");
	/// <summary>
	/// Warehouse:
	/// </summary>
	public BaseInputControl Armaz01WarehWarehdes => new BaseInputControl(driver, formLocator, "#ARMAZ01_WAREHWAREHDES");
	/// <summary>
	/// Support
	/// </summary>
	public ArtigextForm  Armaz02PseudArtigapo => new ArtigextForm(driver, FORM_MODE.EDIT, By.Id("ARMAZ02_PSEUDARTIGAPO"));
	/// <summary>
	/// Catalog articles
	/// </summary>
	public ListControl Armaz02PseudArtigos => new ListControl(driver, formLocator, "#ARMAZ02_PSEUDARTIGOS_");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public ArmazpopForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ARMAZPOP")).GetAttribute("data-loading") != "true");
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
