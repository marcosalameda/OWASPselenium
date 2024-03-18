namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RegiaproForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, formLocator, "container-REGIAPROCNTRYCOUNTRY_");
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "REGIAPRO", "CNTRY.COUNTRY");
	/// <summary>
	/// Region
	/// </summary>
	public BaseInputControl RegioRegiao => new BaseInputControl(driver, formLocator, "#REGIAPROREGIOREGIAO__");
	/// <summary>
	/// Country
	/// </summary>
	public LookupControl Pais1Country => new LookupControl(driver, formLocator, "container-REGIAPROPAIS1COUNTRY_");
	public SeeMorePage Pais1CountrySeeMorePage => new SeeMorePage(driver, "REGIAPRO", "PAIS1.COUNTRY");
	/// <summary>
	/// Non Limited Properties
	/// </summary>
	public ListControl PseudImoveiss => new ListControl(driver, formLocator, "#REGIAPROPSEUDIMOVEISS");
	/// <summary>
	/// Properties
	/// </summary>
	public ListControl PseudImoveisl => new ListControl(driver, formLocator, "#REGIAPROPSEUDIMOVEISL");
	/// <summary>
	/// Properties
	/// </summary>
	public ListControl PseudImoveisg => new ListControl(driver, formLocator, "#REGIAPROPSEUDIMOVEISG");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public RegiaproForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("REGIAPRO")).GetAttribute("data-loading") != "true");
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
