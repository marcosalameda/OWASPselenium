namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Propr00Form: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, formLocator, "#PROPR00_PSEUDNOVOGR04-container");
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, formLocator, "#PROPR00_PSEUDNOVOGR02-container");
	/// <summary>
	/// Real estate
	/// </summary>
	public BaseInputControl ProprName => new BaseInputControl(driver, formLocator, "#PROPR00_PROPRNAME____");
	/// <summary>
	/// Estimated price
	/// </summary>
	public BaseInputControl ProprPrecoest => new BaseInputControl(driver, formLocator, "#PROPR00_PROPRPRECOEST");
	/// <summary>
	/// Property Type
	/// </summary>
	public LookupControl TpproTppropri => new LookupControl(driver, formLocator, "container-PROPR00_TPPROTPPROPRI");
	public SeeMorePage TpproTppropriSeeMorePage => new SeeMorePage(driver, "PROPR00", "TPPRO.TPPROPRI");
	/// <summary>
	/// Furnished
	/// </summary>
	public CheckboxInputControl ProprMobilada => new CheckboxInputControl(driver, formLocator, "#container-PROPR00_PROPRMOBILADA");
	/// <summary>
	/// Seller
	/// </summary>
	public LookupControl PessoName => new LookupControl(driver, formLocator, "container-PROPR00_PESSONAME____");
	public SeeMorePage PessoNameSeeMorePage => new SeeMorePage(driver, "PROPR00", "PESSO.NAME");
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl ProprPhotogra => new BaseInputControl(driver, formLocator, "#PROPR00_PROPRPHOTOGRA");
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#PROPR00_PSEUDNOVOGR01-container");
	/// <summary>
	/// Details
	/// </summary>
	public TabControl PseudPropr02 => new TabControl(driver, formLocator, "#tab-container-PROPR00_PSEUDPROPR02_");
	/// <summary>
	/// Localization
	/// </summary>
	public TabControl PseudPropr01 => new TabControl(driver, formLocator, "#tab-container-PROPR00_PSEUDPROPR01_");
	/// <summary>
	/// Description
	/// </summary>
	public TabControl PseudPropr03 => new TabControl(driver, formLocator, "#tab-container-PROPR00_PSEUDPROPR03_");
	/// <summary>
	/// Bathroom
	/// </summary>
	public BaseInputControl Propr02ProprQtd_wc => new BaseInputControl(driver, formLocator, "#PROPR02_PROPRQTD_WC__");
	/// <summary>
	/// Quartos
	/// </summary>
	public BaseInputControl Propr02ProprQtdquart => new BaseInputControl(driver, formLocator, "#PROPR02_PROPRQTDQUART");
	/// <summary>
	/// Square meters
	/// </summary>
	public BaseInputControl Propr02ProprM2 => new BaseInputControl(driver, formLocator, "#PROPR02_PROPRM2______");
	/// <summary>
	/// Available from
	/// </summary>
	public DateInputControl Propr02ProprDtdispon => new DateInputControl(driver, formLocator, "#PROPR02_PROPRDTDISPON");
	/// <summary>
	/// Address
	/// </summary>
	public CollapsibleZoneControl Propr01PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#PROPR01_PSEUDNOVOGR01-container");
	/// <summary>
	/// Address
	/// </summary>
	public BaseInputControl Propr01ProprEndereco => new BaseInputControl(driver, formLocator, "#PROPR01_PROPRENDERECO");
	/// <summary>
	/// Localization
	/// </summary>
	public BaseInputControl Propr01ProprLocalida => new BaseInputControl(driver, formLocator, "#PROPR01_PROPRLOCALIDA");
	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl Propr01ProprPostalco => new BaseInputControl(driver, formLocator, "#PROPR01_PROPRPOSTALCO");
	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl Propr01ProprPostallo => new BaseInputControl(driver, formLocator, "#PROPR01_PROPRPOSTALLO");
	/// <summary>
	/// Country
	/// </summary>
	public LookupControl Propr01CntryCountry => new LookupControl(driver, formLocator, "container-PROPR01_CNTRYCOUNTRY_");
	public SeeMorePage Propr01CntryCountrySeeMorePage => new SeeMorePage(driver, "PROPR00", "CNTRY.COUNTRY");
	/// <summary>
	/// Region
	/// </summary>
	public LookupControl Propr01RegioRegiao => new LookupControl(driver, formLocator, "container-PROPR01_REGIOREGIAO__");
	public SeeMorePage Propr01RegioRegiaoSeeMorePage => new SeeMorePage(driver, "PROPR00", "REGIO.REGIAO");
	/// <summary>
	/// Geographic Coordinates
	/// </summary>
	public BaseInputControl Propr01ProprCoordgeo => new BaseInputControl(driver, formLocator, "#PROPR01_PROPRCOORDGEO");
	/// <summary>
	/// Description
	/// </summary>
	public IWebElement Propr03ProprDescript => throw new NotImplementedException();

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public Propr00Form(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("PROPR00")).GetAttribute("data-loading") != "true");
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
