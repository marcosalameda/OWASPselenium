namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArmapessForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Employee Number
	/// </summary>
	public BaseInputControl WpessNfunc => new BaseInputControl(driver, formLocator, "#ARMAPESSWPESSNFUNC___");
	/// <summary>
	/// Profille picture
	/// </summary>
	public BaseInputControl WpessPfoto => new BaseInputControl(driver, formLocator, "#ARMAPESSWPESSPFOTO___");
	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl WpessName => new BaseInputControl(driver, formLocator, "#ARMAPESSWPESSNAME____");
	/// <summary>
	/// Birth date
	/// </summary>
	public DateInputControl WpessDate => new DateInputControl(driver, formLocator, "#ARMAPESSWPESSDATE____");
	/// <summary>
	/// Sex
	/// </summary>
	public EnumControl WpessSex => new EnumControl(driver, formLocator, "container-ARMAPESSWPESSSEX_____");
	/// <summary>
	/// Country of Birth
	/// </summary>
	public BaseInputControl WpessNaturali => new BaseInputControl(driver, formLocator, "#ARMAPESSWPESSNATURALI");
	/// <summary>
	/// Nationality
	/// </summary>
	public BaseInputControl WpessNacional => new BaseInputControl(driver, formLocator, "#ARMAPESSWPESSNACIONAL");
	/// <summary>
	/// Adress
	/// </summary>
	public BaseInputControl WpessAdress => new BaseInputControl(driver, formLocator, "#ARMAPESSWPESSADRESS__");
	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl WpessZipcode => new BaseInputControl(driver, formLocator, "#ARMAPESSWPESSZIPCODE_");
	/// <summary>
	/// Country
	/// </summary>
	public BaseInputControl WpessCountry => new BaseInputControl(driver, formLocator, "#ARMAPESSWPESSCOUNTRY_");
	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl WpessEmail => new BaseInputControl(driver, formLocator, "#ARMAPESSWPESSEMAIL___");
	/// <summary>
	/// Cellphone
	/// </summary>
	public BaseInputControl WpessCellphon => new BaseInputControl(driver, formLocator, "#ARMAPESSWPESSCELLPHON");
	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, formLocator, "container-ARMAPESSWAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "ARMAPESS", "WAREH.WAREHDES");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public ArmapessForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ARMAPESS")).GetAttribute("data-loading") != "true");
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
