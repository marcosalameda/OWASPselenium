namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ProduForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Product identification
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#PRODU___PSEUDNOVOGR01-container");
	/// <summary>
	/// Product
	/// </summary>
	public BaseInputControl ProduProduct => new BaseInputControl(driver, formLocator, "#PRODU___PRODUPRODUCT_");
	/// <summary>
	/// In use
	/// </summary>
	public EnumControl ProduIn_use => new EnumControl(driver, formLocator, "container-PRODU___PRODUIN_USE__");
	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl ProduDescript => new BaseInputControl(driver, formLocator, "#PRODU___PRODUDESCRIPT");
	/// <summary>
	/// SKU
	/// </summary>
	public BaseInputControl ProduSku => new BaseInputControl(driver, formLocator, "#PRODU___PRODUSKU_____");
	/// <summary>
	/// GTIN
	/// </summary>
	public BaseInputControl ProduGtin => new BaseInputControl(driver, formLocator, "#PRODU___PRODUGTIN____");
	/// <summary>
	/// Size
	/// </summary>
	public BaseInputControl ProduSize => new BaseInputControl(driver, formLocator, "#PRODU___PRODUSIZE____");
	/// <summary>
	/// Weight
	/// </summary>
	public BaseInputControl ProduWeight => new BaseInputControl(driver, formLocator, "#PRODU___PRODUWEIGHT__");
	/// <summary>
	/// Price
	/// </summary>
	public BaseInputControl ProduPrice => new BaseInputControl(driver, formLocator, "#PRODU___PRODUPRICE___");
	/// <summary>
	/// Inputs
	/// </summary>
	public BaseInputControl ProduInputs => new BaseInputControl(driver, formLocator, "#PRODU___PRODUINPUTS__");
	/// <summary>
	/// Outputs
	/// </summary>
	public BaseInputControl ProduOutputs => new BaseInputControl(driver, formLocator, "#PRODU___PRODUOUTPUTS_");
	/// <summary>
	/// Stock
	/// </summary>
	public BaseInputControl ProduStock => new BaseInputControl(driver, formLocator, "#PRODU___PRODUSTOCK___");
	/// <summary>
	/// Image
	/// </summary>
	public IWebElement PseudNovogr02 => throw new NotImplementedException();
	/// <summary>
	/// Image
	/// </summary>
	public BaseInputControl ProduImage => new BaseInputControl(driver, formLocator, "#PRODU___PRODUIMAGE___");
	/// <summary>
	/// ACCORDEON
	/// </summary>
	public IWebElement PseudNovogr06 => throw new NotImplementedException();
	/// <summary>
	/// Stock
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, formLocator, "#PRODU___PSEUDNOVOGR04-container");
	/// <summary>
	/// Location
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, formLocator, "#PRODU___PSEUDNOVOGR03-container");
	/// <summary>
	/// Global Location Number
	/// </summary>
	public LookupControl LocatGln => new LookupControl(driver, formLocator, "container-PRODU___LOCATGLN_____");
	public SeeMorePage LocatGlnSeeMorePage => new SeeMorePage(driver, "PRODU", "LOCAT.GLN");
	/// <summary>
	/// GLN Extension Component
	/// </summary>
	public LookupControl LcextGlnext => new LookupControl(driver, formLocator, "container-PRODU___LCEXTGLNEXT__");
	public SeeMorePage LcextGlnextSeeMorePage => new SeeMorePage(driver, "PRODU", "LCEXT.GLNEXT");
	/// <summary>
	/// Stock evolution
	/// </summary>
	public ListControl PseudStockevo => new ListControl(driver, formLocator, "#PRODU___PSEUDSTOCKEVO");
	/// <summary>
	/// Details
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, formLocator, "#PRODU___PSEUDNOVOGR05-container");
	/// <summary>
	/// Inputs
	/// </summary>
	public ListControl PseudInputsre => new ListControl(driver, formLocator, "#PRODU___PSEUDINPUTSRE");
	/// <summary>
	/// Outputs
	/// </summary>
	public ListControl PseudOutputsd => new ListControl(driver, formLocator, "#PRODU___PSEUDOUTPUTSD");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public ProduForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("PRODU")).GetAttribute("data-loading") != "true");
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
