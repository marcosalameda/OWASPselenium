namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Propr01Form: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Address
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#PROPR01_PSEUDNOVOGR01-container");
	/// <summary>
	/// Address
	/// </summary>
	public BaseInputControl ProprEndereco => new BaseInputControl(driver, formLocator, "#PROPR01_PROPRENDERECO");
	/// <summary>
	/// Localization
	/// </summary>
	public BaseInputControl ProprLocalida => new BaseInputControl(driver, formLocator, "#PROPR01_PROPRLOCALIDA");
	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl ProprPostalco => new BaseInputControl(driver, formLocator, "#PROPR01_PROPRPOSTALCO");
	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl ProprPostallo => new BaseInputControl(driver, formLocator, "#PROPR01_PROPRPOSTALLO");
	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, formLocator, "container-PROPR01_CNTRYCOUNTRY_");
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "PROPR01", "CNTRY.COUNTRY");
	/// <summary>
	/// Region
	/// </summary>
	public LookupControl RegioRegiao => new LookupControl(driver, formLocator, "container-PROPR01_REGIOREGIAO__");
	public SeeMorePage RegioRegiaoSeeMorePage => new SeeMorePage(driver, "PROPR01", "REGIO.REGIAO");
	/// <summary>
	/// Geographic Coordinates
	/// </summary>
	public BaseInputControl ProprCoordgeo => new BaseInputControl(driver, formLocator, "#PROPR01_PROPRCOORDGEO");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public Propr01Form(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("PROPR01")).GetAttribute("data-loading") != "true");
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
