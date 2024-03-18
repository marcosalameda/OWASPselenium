namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ProdusimForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Product identification
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#PRODUSIMPSEUDNOVOGR01-container");
	/// <summary>
	/// Product
	/// </summary>
	public BaseInputControl ProduProduct => new BaseInputControl(driver, formLocator, "#PRODUSIMPRODUPRODUCT_");
	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl ProduDescript => new BaseInputControl(driver, formLocator, "#PRODUSIMPRODUDESCRIPT");
	/// <summary>
	/// SKU
	/// </summary>
	public BaseInputControl ProduSku => new BaseInputControl(driver, formLocator, "#PRODUSIMPRODUSKU_____");
	/// <summary>
	/// GTIN
	/// </summary>
	public BaseInputControl ProduGtin => new BaseInputControl(driver, formLocator, "#PRODUSIMPRODUGTIN____");
	/// <summary>
	/// Size
	/// </summary>
	public BaseInputControl ProduSize => new BaseInputControl(driver, formLocator, "#PRODUSIMPRODUSIZE____");
	/// <summary>
	/// Weight
	/// </summary>
	public BaseInputControl ProduWeight => new BaseInputControl(driver, formLocator, "#PRODUSIMPRODUWEIGHT__");
	/// <summary>
	/// Location
	/// </summary>
	public IWebElement PseudNovogr02 => throw new NotImplementedException();
	/// <summary>
	/// Global Location Number
	/// </summary>
	public LookupControl LocatGln => new LookupControl(driver, formLocator, "container-PRODUSIMLOCATGLN_____");
	public SeeMorePage LocatGlnSeeMorePage => new SeeMorePage(driver, "PRODUSIM", "LOCAT.GLN");
	/// <summary>
	/// GLN Extension Component
	/// </summary>
	public LookupControl LcextGlnext => new LookupControl(driver, formLocator, "container-PRODUSIMLCEXTGLNEXT__");
	public SeeMorePage LcextGlnextSeeMorePage => new SeeMorePage(driver, "PRODUSIM", "LCEXT.GLNEXT");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public ProdusimForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("PRODUSIM")).GetAttribute("data-loading") != "true");
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
