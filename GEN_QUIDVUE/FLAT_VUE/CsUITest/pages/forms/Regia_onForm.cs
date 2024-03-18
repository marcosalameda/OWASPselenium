namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Regia_onForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// País:
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, formLocator, "container-REGIA_ONCNTRYCOUNTRY_");
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "REGIA_ON", "CNTRY.COUNTRY");
	/// <summary>
	/// Região:
	/// </summary>
	public BaseInputControl RegioRegiao => new BaseInputControl(driver, formLocator, "#REGIA_ONREGIOREGIAO__");
	/// <summary>
	/// País pessoa
	/// </summary>
	public LookupControl Pais1Country => new LookupControl(driver, formLocator, "container-REGIA_ONPAIS1COUNTRY_");
	public SeeMorePage Pais1CountrySeeMorePage => new SeeMorePage(driver, "REGIA_ON", "PAIS1.COUNTRY");
	/// <summary>
	/// Imóveis
	/// </summary>
	public ListControl PseudImoveisl => new ListControl(driver, formLocator, "#REGIA_ONPSEUDIMOVEISL");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public Regia_onForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("REGIA_ON")).GetAttribute("data-loading") != "true");
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
