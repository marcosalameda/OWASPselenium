namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EmpreForm: PageObject {

	private By formLocator = By.CssSelector("#q-modal-form-EMPRE");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Logo
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, formLocator, "#EMPRE___PSEUDNOVOGR02-container");
	/// <summary>
	/// Logo
	/// </summary>
	public BaseInputControl CmpnyLogo => new BaseInputControl(driver, formLocator, "#EMPRE___CMPNYLOGO____");
	/// <summary>
	/// Company
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#EMPRE___PSEUDNOVOGR01-container");
	/// <summary>
	/// Designation
	/// </summary>
	public BaseInputControl CmpnyDesignat => new BaseInputControl(driver, formLocator, "#EMPRE___CMPNYDESIGNAT");
	/// <summary>
	/// Acronym
	/// </summary>
	public BaseInputControl CmpnyAcronym => new BaseInputControl(driver, formLocator, "#EMPRE___CMPNYACRONYM_");
	/// <summary>
	/// Tax identification:
	/// </summary>
	public BaseInputControl CmpnyNif => new BaseInputControl(driver, formLocator, "#EMPRE___CMPNYNIF_____");
	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl CmpnyTelephon => new BaseInputControl(driver, formLocator, "#EMPRE___CMPNYTELEPHON");
	/// <summary>
	/// Email:
	/// </summary>
	public BaseInputControl CmpnyEmail => new BaseInputControl(driver, formLocator, "#EMPRE___CMPNYEMAIL___");
	/// <summary>
	/// Origin
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, formLocator, "#EMPRE___PSEUDNOVOGR03-container");
	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, formLocator, "container-EMPRE___CNTRYCOUNTRY_");
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "EMPRE", "CNTRY.COUNTRY");
	/// <summary>
	/// Quantity of people
	/// </summary>
	public BaseInputControl CmpnyQtdpesso => new BaseInputControl(driver, formLocator, "#EMPRE___CMPNYQTDPESSO");
	/// <summary>
	/// Headquarter location
	/// </summary>
	public BaseInputControl CmpnyHeadloc => new BaseInputControl(driver, formLocator, "#EMPRE___CMPNYHEADLOC_");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public EmpreForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("EMPRE")).GetAttribute("data-loading") != "true");
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
