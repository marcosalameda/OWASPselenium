namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArtigextForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, formLocator, "container-ARTIGEXTWAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "ARTIGEXT", "WAREH.WAREHDES");
	/// <summary>
	/// Global Item
	/// </summary>
	public LookupControl GitemItemdes => new LookupControl(driver, formLocator, "container-ARTIGEXTGITEMITEMDES_");
	public SeeMorePage GitemItemdesSeeMorePage => new SeeMorePage(driver, "ARTIGEXT", "GITEM.ITEMDES");
	/// <summary>
	/// Code
	/// </summary>
	public IWebElement GitemItemgcod => throw new NotImplementedException();
	/// <summary>
	/// Item
	/// </summary>
	public BaseInputControl ItemItemdes => new BaseInputControl(driver, formLocator, "#ARTIGEXTITEM_ITEMDES_");
	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl ItemItemcod => new BaseInputControl(driver, formLocator, "#ARTIGEXTITEM_ITEMCOD_");
	/// <summary>
	/// Image
	/// </summary>
	public BaseInputControl ItemImage => new BaseInputControl(driver, formLocator, "#ARTIGEXTITEM_IMAGE___");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public ArtigextForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ARTIGEXT")).GetAttribute("data-loading") != "true");
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
