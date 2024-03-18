namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Vendaw01Form: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Organization
	/// </summary>
	public LookupControl OrganOrganiza => new LookupControl(driver, formLocator, "container-VENDAW01ORGANORGANIZA");
	public SeeMorePage OrganOrganizaSeeMorePage => new SeeMorePage(driver, "VENDAW01", "ORGAN.ORGANIZA");
	/// <summary>
	/// Prospecting
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#VENDAW01PSEUDNOVOGR01-container");
	/// <summary>
	/// Identification of business opportunity
	/// </summary>
	public BaseInputControl SaleIdentifi => new BaseInputControl(driver, formLocator, "#VENDAW01SALE_IDENTIFI");
	/// <summary>
	/// Potential buyers
	/// </summary>
	public BaseInputControl SalePotcompr => new BaseInputControl(driver, formLocator, "#VENDAW01SALE_POTCOMPR");
	/// <summary>
	/// Prospecting carried out
	/// </summary>
	public CheckboxInputControl SaleProspecc => new CheckboxInputControl(driver, formLocator, "#container-VENDAW01SALE_PROSPECC");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public Vendaw01Form(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("VENDAW01")).GetAttribute("data-loading") != "true");
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
