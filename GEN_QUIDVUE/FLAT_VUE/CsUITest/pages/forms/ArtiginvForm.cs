namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArtiginvForm: PageObject {

	private By formLocator = By.CssSelector("#q-modal-form-ARTIGINV");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Image
	/// </summary>
	public BaseInputControl ItemImage => new BaseInputControl(driver, formLocator, "#ARTIGINVITEM_IMAGE___");
	/// <summary>
	/// Global Item
	/// </summary>
	public LookupControl GitemItemdes => new LookupControl(driver, formLocator, "container-ARTIGINVGITEMITEMDES_");
	public SeeMorePage GitemItemdesSeeMorePage => new SeeMorePage(driver, "ARTIGINV", "GITEM.ITEMDES");
	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, formLocator, "container-ARTIGINVWAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "ARTIGINV", "WAREH.WAREHDES");
	/// <summary>
	/// Tipo
	/// </summary>
	public EnumControl ItemItemtype => new EnumControl(driver, formLocator, "container-ARTIGINVITEM_ITEMTYPE");
	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl ItemItemcod => new BaseInputControl(driver, formLocator, "#ARTIGINVITEM_ITEMCOD_");
	/// <summary>
	/// Item
	/// </summary>
	public BaseInputControl ItemItemdes => new BaseInputControl(driver, formLocator, "#ARTIGINVITEM_ITEMDES_");
	/// <summary>
	/// In use
	/// </summary>
	public CheckboxInputControl ItemValid => new CheckboxInputControl(driver, formLocator, "#container-ARTIGINVITEM_VALID___");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public ArtiginvForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ARTIGINV")).GetAttribute("data-loading") != "true");
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
