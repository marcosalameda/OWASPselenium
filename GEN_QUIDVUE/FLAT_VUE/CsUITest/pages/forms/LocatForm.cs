namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LocatForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Location
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#LOCAT___PSEUDNOVOGR01-container");
	/// <summary>
	/// Legal name
	/// </summary>
	public LookupControl EntitName => new LookupControl(driver, formLocator, "container-LOCAT___ENTITNAME____");
	public SeeMorePage EntitNameSeeMorePage => new SeeMorePage(driver, "LOCAT", "ENTIT.NAME");
	/// <summary>
	/// Facility name
	/// </summary>
	public LookupControl FacilName => new LookupControl(driver, formLocator, "container-LOCAT___FACILNAME____");
	public SeeMorePage FacilNameSeeMorePage => new SeeMorePage(driver, "LOCAT", "FACIL.NAME");
	/// <summary>
	/// Global Location Number
	/// </summary>
	public BaseInputControl LocatGln => new BaseInputControl(driver, formLocator, "#LOCAT___LOCATGLN_____");
	/// <summary>
	/// Location Extension Components
	/// </summary>
	public ListControl PseudLocalext => new ListControl(driver, formLocator, "#LOCAT___PSEUDLOCALEXT");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public LocatForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("LOCAT")).GetAttribute("data-loading") != "true");
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
