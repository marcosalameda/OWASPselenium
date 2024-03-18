namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FacilfexForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Entity legal name
	/// </summary>
	public LookupControl EntitName => new LookupControl(driver, formLocator, "container-FACILFEXENTITNAME____");
	public SeeMorePage EntitNameSeeMorePage => new SeeMorePage(driver, "FACILFEX", "ENTIT.NAME");
	/// <summary>
	/// Incorporation
	/// </summary>
	public DateInputControl FacilIncorpor => new DateInputControl(driver, formLocator, "#FACILFEXFACILINCORPOR");
	/// <summary>
	/// Facility name
	/// </summary>
	public BaseInputControl FacilName => new BaseInputControl(driver, formLocator, "#FACILFEXFACILNAME____");
	/// <summary>
	/// Facility type
	/// </summary>
	public EnumControl FacilFaciltyp => new EnumControl(driver, formLocator, "container-FACILFEXFACILFACILTYP");
	/// <summary>
	/// Facility type
	/// </summary>
	public LookupControl FactyType => new LookupControl(driver, formLocator, "container-FACILFEXFACTYTYPE____");
	public SeeMorePage FactyTypeSeeMorePage => new SeeMorePage(driver, "FACILFEX", "FACTY.TYPE");
	/// <summary>
	/// Latitude
	/// </summary>
	public BaseInputControl FacilLatitude => new BaseInputControl(driver, formLocator, "#FACILFEXFACILLATITUDE");
	/// <summary>
	/// Longitude
	/// </summary>
	public BaseInputControl FacilLongitud => new BaseInputControl(driver, formLocator, "#FACILFEXFACILLONGITUD");
	/// <summary>
	/// Address
	/// </summary>
	public BaseInputControl FacilAddress => new BaseInputControl(driver, formLocator, "#FACILFEXFACILADDRESS_");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public FacilfexForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("FACILFEX")).GetAttribute("data-loading") != "true");
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
