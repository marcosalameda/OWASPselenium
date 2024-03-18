namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FacilForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Legal name
	/// </summary>
	public LookupControl EntitName => new LookupControl(driver, formLocator, "container-FACIL___ENTITNAME____");
	public SeeMorePage EntitNameSeeMorePage => new SeeMorePage(driver, "FACIL", "ENTIT.NAME");
	/// <summary>
	/// Incorporation
	/// </summary>
	public DateInputControl FacilIncorpor => new DateInputControl(driver, formLocator, "#FACIL___FACILINCORPOR");
	/// <summary>
	/// Facility name
	/// </summary>
	public BaseInputControl FacilName => new BaseInputControl(driver, formLocator, "#FACIL___FACILNAME____");
	/// <summary>
	/// Facility type
	/// </summary>
	public EnumControl FacilFaciltyp => new EnumControl(driver, formLocator, "container-FACIL___FACILFACILTYP");
	/// <summary>
	/// Facility type
	/// </summary>
	public LookupControl FactyType => new LookupControl(driver, formLocator, "container-FACIL___FACTYTYPE____");
	public SeeMorePage FactyTypeSeeMorePage => new SeeMorePage(driver, "FACIL", "FACTY.TYPE");
	/// <summary>
	/// Address
	/// </summary>
	public BaseInputControl FacilAddress => new BaseInputControl(driver, formLocator, "#FACIL___FACILADDRESS_");
	/// <summary>
	/// Image
	/// </summary>
	public BaseInputControl FacilImage => new BaseInputControl(driver, formLocator, "#FACIL___FACILIMAGE___");
	/// <summary>
	/// GPS input
	/// </summary>
	public RadiobuttonControl FacilGpsinput => new RadiobuttonControl(driver, formLocator, "container-FACIL___FACILGPSINPUT");
	/// <summary>
	/// Latitude
	/// </summary>
	public BaseInputControl FacilLatitude => new BaseInputControl(driver, formLocator, "#FACIL___FACILLATITUDE");
	/// <summary>
	/// Longitude
	/// </summary>
	public BaseInputControl FacilLongitud => new BaseInputControl(driver, formLocator, "#FACIL___FACILLONGITUD");
	/// <summary>
	/// Geographical coordinate
	/// </summary>
	public BaseInputControl FacilGeocoori => new BaseInputControl(driver, formLocator, "#FACIL___FACILGEOCOORI");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public FacilForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("FACIL")).GetAttribute("data-loading") != "true");
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
