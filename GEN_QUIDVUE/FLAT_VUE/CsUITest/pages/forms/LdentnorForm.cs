namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LdentnorForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// 
	/// </summary>
	public LookupControl IndocDocumenr => new LookupControl(driver, formLocator, "container-LDENTNORINDOCDOCUMENR");
	public SeeMorePage IndocDocumenrSeeMorePage => new SeeMorePage(driver, "LDENTNOR", "INDOC.DOCUMENR");
	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, formLocator, "container-LDENTNORWAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "LDENTNOR", "WAREH.WAREHDES");
	/// <summary>
	/// Line
	/// </summary>
	public BaseInputControl LdentLine => new BaseInputControl(driver, formLocator, "#LDENTNORLDENTLINE____");
	/// <summary>
	/// Item
	/// </summary>
	public LookupControl ItemItemdes => new LookupControl(driver, formLocator, "container-LDENTNORITEM_ITEMDES_");
	public SeeMorePage ItemItemdesSeeMorePage => new SeeMorePage(driver, "LDENTNOR", "ITEM.ITEMDES");
	/// <summary>
	/// Input Quantity
	/// </summary>
	public BaseInputControl LdentQtdentra => new BaseInputControl(driver, formLocator, "#LDENTNORLDENTQTDENTRA");
	/// <summary>
	/// 
	/// </summary>
	public IWebElement IndocCodwareh => throw new NotImplementedException();

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public LdentnorForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("LDENTNOR")).GetAttribute("data-loading") != "true");
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
