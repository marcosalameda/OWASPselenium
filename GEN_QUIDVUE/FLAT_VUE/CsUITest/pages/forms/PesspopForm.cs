namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PesspopForm: PageObject {

	private By formLocator = By.CssSelector("#q-modal-form-PESSPOP");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Employee Number
	/// </summary>
	public BaseInputControl WpessNfunc => new BaseInputControl(driver, formLocator, "#PESSPOP_WPESSNFUNC___");
	/// <summary>
	/// Profille picture
	/// </summary>
	public BaseInputControl WpessPfoto => new BaseInputControl(driver, formLocator, "#PESSPOP_WPESSPFOTO___");
	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl WpessName => new BaseInputControl(driver, formLocator, "#PESSPOP_WPESSNAME____");
	/// <summary>
	/// Birth date
	/// </summary>
	public DateInputControl WpessDate => new DateInputControl(driver, formLocator, "#PESSPOP_WPESSDATE____");
	/// <summary>
	/// Sex
	/// </summary>
	public EnumControl WpessSex => new EnumControl(driver, formLocator, "container-PESSPOP_WPESSSEX_____");
	/// <summary>
	/// Country of Birth
	/// </summary>
	public BaseInputControl WpessNaturali => new BaseInputControl(driver, formLocator, "#PESSPOP_WPESSNATURALI");
	/// <summary>
	/// Nationality
	/// </summary>
	public BaseInputControl WpessNacional => new BaseInputControl(driver, formLocator, "#PESSPOP_WPESSNACIONAL");
	/// <summary>
	/// Adress
	/// </summary>
	public BaseInputControl WpessAdress => new BaseInputControl(driver, formLocator, "#PESSPOP_WPESSADRESS__");
	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl WpessZipcode => new BaseInputControl(driver, formLocator, "#PESSPOP_WPESSZIPCODE_");
	/// <summary>
	/// Country
	/// </summary>
	public BaseInputControl WpessCountry => new BaseInputControl(driver, formLocator, "#PESSPOP_WPESSCOUNTRY_");
	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl WpessEmail => new BaseInputControl(driver, formLocator, "#PESSPOP_WPESSEMAIL___");
	/// <summary>
	/// Cellphone
	/// </summary>
	public BaseInputControl WpessCellphon => new BaseInputControl(driver, formLocator, "#PESSPOP_WPESSCELLPHON");
	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, formLocator, "container-PESSPOP_WAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "PESSPOP", "WAREH.WAREHDES");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public PesspopForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("PESSPOP")).GetAttribute("data-loading") != "true");
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
