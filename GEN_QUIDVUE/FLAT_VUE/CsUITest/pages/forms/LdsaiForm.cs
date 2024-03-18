namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LdsaiForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Document No.
	/// </summary>
	public LookupControl OutptDocumenr => new LookupControl(driver, formLocator, "container-LDSAI___OUTPTDOCUMENR");
	public SeeMorePage OutptDocumenrSeeMorePage => new SeeMorePage(driver, "LDSAI", "OUTPT.DOCUMENR");
	/// <summary>
	/// 
	/// </summary>
	public IWebElement OutptCodwareh => throw new NotImplementedException();
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#LDSAI___PSEUDNOVOGR01-container");
	/// <summary>
	/// Line
	/// </summary>
	public BaseInputControl OutpuLine => new BaseInputControl(driver, formLocator, "#LDSAI___OUTPULINE____");
	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, formLocator, "container-LDSAI___WAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "LDSAI", "WAREH.WAREHDES");
	/// <summary>
	/// Item
	/// </summary>
	public LookupControl ItemItemdes => new LookupControl(driver, formLocator, "container-LDSAI___ITEM_ITEMDES_");
	public SeeMorePage ItemItemdesSeeMorePage => new SeeMorePage(driver, "LDSAI", "ITEM.ITEMDES");
	/// <summary>
	/// Output quantity:
	/// </summary>
	public BaseInputControl OutpuExitqnty => new BaseInputControl(driver, formLocator, "#LDSAI___OUTPUEXITQNTY");
	/// <summary>
	/// Output No
	/// </summary>
	public LookupControl OudocNrdocsda => new LookupControl(driver, formLocator, "container-LDSAI___OUDOCNRDOCSDA");
	public SeeMorePage OudocNrdocsdaSeeMorePage => new SeeMorePage(driver, "LDSAI", "OUDOC.NRDOCSDA");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public LdsaiForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("LDSAI")).GetAttribute("data-loading") != "true");
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
