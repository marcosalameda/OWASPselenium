namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LdentForm: PageObject {

	private By formLocator = By.CssSelector("#q-modal-form-LDENT");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// 
	/// </summary>
	public LookupControl IndocDocumenr => new LookupControl(driver, formLocator, "container-LDENT___INDOCDOCUMENR");
	public SeeMorePage IndocDocumenrSeeMorePage => new SeeMorePage(driver, "LDENT", "INDOC.DOCUMENR");
	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, formLocator, "container-LDENT___WAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "LDENT", "WAREH.WAREHDES");
	/// <summary>
	/// Line
	/// </summary>
	public BaseInputControl LdentLine => new BaseInputControl(driver, formLocator, "#LDENT___LDENTLINE____");
	/// <summary>
	/// Items in use
	/// </summary>
	public CheckboxInputControl LdentEmuso => new CheckboxInputControl(driver, formLocator, "#container-LDENT___LDENTEMUSO___");
	/// <summary>
	/// Item
	/// </summary>
	public LookupControl ItemItemdes => new LookupControl(driver, formLocator, "container-LDENT___ITEM_ITEMDES_");
	public SeeMorePage ItemItemdesSeeMorePage => new SeeMorePage(driver, "LDENT", "ITEM.ITEMDES");
	/// <summary>
	/// Input Quantity
	/// </summary>
	public BaseInputControl LdentQtdentra => new BaseInputControl(driver, formLocator, "#LDENT___LDENTQTDENTRA");
	/// <summary>
	/// 
	/// </summary>
	public IWebElement IndocCodwareh => throw new NotImplementedException();

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public LdentForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("LDENT")).GetAttribute("data-loading") != "true");
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
