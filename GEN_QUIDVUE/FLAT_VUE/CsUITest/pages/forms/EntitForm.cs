namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EntitForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Legal name
	/// </summary>
	public BaseInputControl EntitName => new BaseInputControl(driver, formLocator, "#ENTIT___ENTITNAME____");
	/// <summary>
	/// Company initials
	/// </summary>
	public BaseInputControl EntitInitials => new BaseInputControl(driver, formLocator, "#ENTIT___ENTITINITIALS");
	/// <summary>
	/// Legal registration
	/// </summary>
	public BaseInputControl EntitRegistra => new BaseInputControl(driver, formLocator, "#ENTIT___ENTITREGISTRA");
	/// <summary>
	/// VAT Number
	/// </summary>
	public BaseInputControl EntitTaxnumbe => new BaseInputControl(driver, formLocator, "#ENTIT___ENTITTAXNUMBE");
	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl EntitEmail => new BaseInputControl(driver, formLocator, "#ENTIT___ENTITEMAIL___");
	/// <summary>
	/// Phone number
	/// </summary>
	public BaseInputControl EntitPhonenum => new BaseInputControl(driver, formLocator, "#ENTIT___ENTITPHONENUM");
	/// <summary>
	/// IBAN (International Bank Account Number)
	/// </summary>
	public BaseInputControl EntitIban => new BaseInputControl(driver, formLocator, "#ENTIT___ENTITIBAN____");
	/// <summary>
	/// Building/house number
	/// </summary>
	public BaseInputControl EntitBuilding => new BaseInputControl(driver, formLocator, "#ENTIT___ENTITBUILDING");
	/// <summary>
	/// Street
	/// </summary>
	public BaseInputControl EntitStreet => new BaseInputControl(driver, formLocator, "#ENTIT___ENTITSTREET__");
	/// <summary>
	/// Town/City
	/// </summary>
	public BaseInputControl EntitTown => new BaseInputControl(driver, formLocator, "#ENTIT___ENTITTOWN____");
	/// <summary>
	/// County/Province
	/// </summary>
	public BaseInputControl EntitCounty => new BaseInputControl(driver, formLocator, "#ENTIT___ENTITCOUNTY__");
	/// <summary>
	/// State/Province
	/// </summary>
	public BaseInputControl EntitState => new BaseInputControl(driver, formLocator, "#ENTIT___ENTITSTATE___");
	/// <summary>
	/// Post office box
	/// </summary>
	public BaseInputControl EntitPobox => new BaseInputControl(driver, formLocator, "#ENTIT___ENTITPOBOX___");
	/// <summary>
	/// ZIP/Postal code
	/// </summary>
	public BaseInputControl EntitPostalco => new BaseInputControl(driver, formLocator, "#ENTIT___ENTITPOSTALCO");
	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl EntitTelephon => new BaseInputControl(driver, formLocator, "#ENTIT___ENTITTELEPHON");
	/// <summary>
	/// Fax
	/// </summary>
	public BaseInputControl EntitFax => new BaseInputControl(driver, formLocator, "#ENTIT___ENTITFAX_____");
	/// <summary>
	/// Web site
	/// </summary>
	public BaseInputControl EntitWebsite => new BaseInputControl(driver, formLocator, "#ENTIT___ENTITWEBSITE_");
	/// <summary>
	/// Person/Department to contact
	/// </summary>
	public BaseInputControl EntitPerson => new BaseInputControl(driver, formLocator, "#ENTIT___ENTITPERSON__");
	/// <summary>
	/// Contact telephone number
	/// </summary>
	public BaseInputControl EntitContact => new BaseInputControl(driver, formLocator, "#ENTIT___ENTITCONTACT_");
	/// <summary>
	/// Owner
	/// </summary>
	public CheckboxInputControl EntitOwner => new CheckboxInputControl(driver, formLocator, "#container-ENTIT___ENTITOWNER___");
	/// <summary>
	/// Carrier
	/// </summary>
	public CheckboxInputControl EntitCarrier => new CheckboxInputControl(driver, formLocator, "#container-ENTIT___ENTITCARRIER_");
	/// <summary>
	/// Supplier
	/// </summary>
	public CheckboxInputControl EntitSupplier => new CheckboxInputControl(driver, formLocator, "#container-ENTIT___ENTITSUPPLIER");
	/// <summary>
	/// Manufacturer
	/// </summary>
	public CheckboxInputControl EntitManufact => new CheckboxInputControl(driver, formLocator, "#container-ENTIT___ENTITMANUFACT");
	/// <summary>
	/// Founded in
	/// </summary>
	public DateInputControl EntitFounded => new DateInputControl(driver, formLocator, "#ENTIT___ENTITFOUNDED_");
	/// <summary>
	/// Facility name
	/// </summary>
	public LookupControl Faci1Name => new LookupControl(driver, formLocator, "container-ENTIT___FACI1NAME____");
	public SeeMorePage Faci1NameSeeMorePage => new SeeMorePage(driver, "ENTIT", "FACI1.NAME");
	/// <summary>
	/// Facility name
	/// </summary>
	public LookupControl Faci2Name => new LookupControl(driver, formLocator, "container-ENTIT___FACI2NAME____");
	public SeeMorePage Faci2NameSeeMorePage => new SeeMorePage(driver, "ENTIT", "FACI2.NAME");
	/// <summary>
	/// Language
	/// </summary>
	public BaseInputControl EntitLanguage => new BaseInputControl(driver, formLocator, "#ENTIT___ENTITLANGUAGE");
	/// <summary>
	/// Currency
	/// </summary>
	public BaseInputControl EntitCurrency => new BaseInputControl(driver, formLocator, "#ENTIT___ENTITCURRENCY");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public EntitForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ENTIT")).GetAttribute("data-loading") != "true");
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
