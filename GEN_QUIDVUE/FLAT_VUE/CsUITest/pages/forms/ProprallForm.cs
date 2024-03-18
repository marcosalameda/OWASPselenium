namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ProprallForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Photo
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, formLocator, "#PROPRALLPSEUDNOVOGR03-container");
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl ProprPhotogra => new BaseInputControl(driver, formLocator, "#PROPRALLPROPRPHOTOGRA");
	/// <summary>
	/// Identification
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, formLocator, "#PROPRALLPSEUDNOVOGR02-container");
	/// <summary>
	/// real estate
	/// </summary>
	public BaseInputControl ProprName => new BaseInputControl(driver, formLocator, "#PROPRALLPROPRNAME____");
	/// <summary>
	/// Estimated price
	/// </summary>
	public BaseInputControl ProprPrecoest => new BaseInputControl(driver, formLocator, "#PROPRALLPROPRPRECOEST");
	/// <summary>
	/// Property Type
	/// </summary>
	public LookupControl TpproTppropri => new LookupControl(driver, formLocator, "container-PROPRALLTPPROTPPROPRI");
	public SeeMorePage TpproTppropriSeeMorePage => new SeeMorePage(driver, "PROPRALL", "TPPRO.TPPROPRI");
	/// <summary>
	/// Localization
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#PROPRALLPSEUDNOVOGR01-container");
	/// <summary>
	/// Furnished
	/// </summary>
	public CheckboxInputControl ProprMobilada => new CheckboxInputControl(driver, formLocator, "#container-PROPRALLPROPRMOBILADA");
	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, formLocator, "container-PROPRALLCNTRYCOUNTRY_");
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "PROPRALL", "CNTRY.COUNTRY");
	/// <summary>
	/// Region
	/// </summary>
	public LookupControl RegioRegiao => new LookupControl(driver, formLocator, "container-PROPRALLREGIOREGIAO__");
	public SeeMorePage RegioRegiaoSeeMorePage => new SeeMorePage(driver, "PROPRALL", "REGIO.REGIAO");
	/// <summary>
	/// Address
	/// </summary>
	public BaseInputControl ProprEndereco => new BaseInputControl(driver, formLocator, "#PROPRALLPROPRENDERECO");
	/// <summary>
	/// Localization
	/// </summary>
	public BaseInputControl ProprLocalida => new BaseInputControl(driver, formLocator, "#PROPRALLPROPRLOCALIDA");
	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl ProprPostalco => new BaseInputControl(driver, formLocator, "#PROPRALLPROPRPOSTALCO");
	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl ProprPostallo => new BaseInputControl(driver, formLocator, "#PROPRALLPROPRPOSTALLO");
	/// <summary>
	/// Bathroom
	/// </summary>
	public BaseInputControl ProprQtd_wc => new BaseInputControl(driver, formLocator, "#PROPRALLPROPRQTD_WC__");
	/// <summary>
	/// Rooms
	/// </summary>
	public BaseInputControl ProprQtdquart => new BaseInputControl(driver, formLocator, "#PROPRALLPROPRQTDQUART");
	/// <summary>
	/// Square meters
	/// </summary>
	public BaseInputControl ProprM2 => new BaseInputControl(driver, formLocator, "#PROPRALLPROPRM2______");
	/// <summary>
	/// Available from
	/// </summary>
	public DateInputControl ProprDtdispon => new DateInputControl(driver, formLocator, "#PROPRALLPROPRDTDISPON");
	/// <summary>
	/// Description
	/// </summary>
	public IWebElement ProprDescript => throw new NotImplementedException();
	/// <summary>
	/// Geographic Coordinates
	/// </summary>
	public BaseInputControl ProprCoordgeo => new BaseInputControl(driver, formLocator, "#PROPRALLPROPRCOORDGEO");
	/// <summary>
	/// Seller
	/// </summary>
	public LookupControl PessoName => new LookupControl(driver, formLocator, "container-PROPRALLPESSONAME____");
	public SeeMorePage PessoNameSeeMorePage => new SeeMorePage(driver, "PROPRALL", "PESSO.NAME");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public ProprallForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("PROPRALL")).GetAttribute("data-loading") != "true");
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
