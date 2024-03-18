namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EntixForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Company identification
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#ENTIX___PSEUDNOVOGR01-container");
	/// <summary>
	/// Legal name
	/// </summary>
	public BaseInputControl EntitName => new BaseInputControl(driver, formLocator, "#ENTIX___ENTITNAME____");
	/// <summary>
	/// Founded in
	/// </summary>
	public DateInputControl EntitFounded => new DateInputControl(driver, formLocator, "#ENTIX___ENTITFOUNDED_");
	/// <summary>
	/// Company initials
	/// </summary>
	public BaseInputControl EntitInitials => new BaseInputControl(driver, formLocator, "#ENTIX___ENTITINITIALS");
	/// <summary>
	/// Legal registration
	/// </summary>
	public BaseInputControl EntitRegistra => new BaseInputControl(driver, formLocator, "#ENTIX___ENTITREGISTRA");
	/// <summary>
	/// VAT Number
	/// </summary>
	public BaseInputControl EntitTaxnumbe => new BaseInputControl(driver, formLocator, "#ENTIX___ENTITTAXNUMBE");
	/// <summary>
	/// IBAN (International Bank Account Number)
	/// </summary>
	public BaseInputControl EntitIban => new BaseInputControl(driver, formLocator, "#ENTIX___ENTITIBAN____");
	/// <summary>
	/// Phone number
	/// </summary>
	public BaseInputControl EntitPhonenum => new BaseInputControl(driver, formLocator, "#ENTIX___ENTITPHONENUM");
	/// <summary>
	/// Owner
	/// </summary>
	public CheckboxInputControl EntitOwner => new CheckboxInputControl(driver, formLocator, "#container-ENTIX___ENTITOWNER___");
	/// <summary>
	/// Carrier
	/// </summary>
	public CheckboxInputControl EntitCarrier => new CheckboxInputControl(driver, formLocator, "#container-ENTIX___ENTITCARRIER_");
	/// <summary>
	/// Supplier
	/// </summary>
	public CheckboxInputControl EntitSupplier => new CheckboxInputControl(driver, formLocator, "#container-ENTIX___ENTITSUPPLIER");
	/// <summary>
	/// Manufacturer
	/// </summary>
	public CheckboxInputControl EntitManufact => new CheckboxInputControl(driver, formLocator, "#container-ENTIX___ENTITMANUFACT");
	/// <summary>
	/// ACCORDION
	/// </summary>
	public IWebElement PseudNovogr05 => throw new NotImplementedException();
	/// <summary>
	/// Contact
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, formLocator, "#ENTIX___PSEUDNOVOGR02-container");
	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl EntitTelephon => new BaseInputControl(driver, formLocator, "#ENTIX___ENTITTELEPHON");
	/// <summary>
	/// Fax
	/// </summary>
	public BaseInputControl EntitFax => new BaseInputControl(driver, formLocator, "#ENTIX___ENTITFAX_____");
	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl EntitEmail => new BaseInputControl(driver, formLocator, "#ENTIX___ENTITEMAIL___");
	/// <summary>
	/// Web site
	/// </summary>
	public BaseInputControl EntitWebsite => new BaseInputControl(driver, formLocator, "#ENTIX___ENTITWEBSITE_");
	/// <summary>
	/// Person/Department to contact
	/// </summary>
	public BaseInputControl EntitPerson => new BaseInputControl(driver, formLocator, "#ENTIX___ENTITPERSON__");
	/// <summary>
	/// Contact telephone number
	/// </summary>
	public BaseInputControl EntitContact => new BaseInputControl(driver, formLocator, "#ENTIX___ENTITCONTACT_");
	/// <summary>
	/// Language
	/// </summary>
	public BaseInputControl EntitLanguage => new BaseInputControl(driver, formLocator, "#ENTIX___ENTITLANGUAGE");
	/// <summary>
	/// Currency
	/// </summary>
	public BaseInputControl EntitCurrency => new BaseInputControl(driver, formLocator, "#ENTIX___ENTITCURRENCY");
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, formLocator, "#ENTIX___PSEUDNOVOGR03-container");
	/// <summary>
	/// Building/house number
	/// </summary>
	public BaseInputControl EntitBuilding => new BaseInputControl(driver, formLocator, "#ENTIX___ENTITBUILDING");
	/// <summary>
	/// Street
	/// </summary>
	public BaseInputControl EntitStreet => new BaseInputControl(driver, formLocator, "#ENTIX___ENTITSTREET__");
	/// <summary>
	/// Town/City
	/// </summary>
	public BaseInputControl EntitTown => new BaseInputControl(driver, formLocator, "#ENTIX___ENTITTOWN____");
	/// <summary>
	/// County/Province
	/// </summary>
	public BaseInputControl EntitCounty => new BaseInputControl(driver, formLocator, "#ENTIX___ENTITCOUNTY__");
	/// <summary>
	/// State/Province
	/// </summary>
	public BaseInputControl EntitState => new BaseInputControl(driver, formLocator, "#ENTIX___ENTITSTATE___");
	/// <summary>
	/// ZIP/Postal code
	/// </summary>
	public BaseInputControl EntitPostalco => new BaseInputControl(driver, formLocator, "#ENTIX___ENTITPOSTALCO");
	/// <summary>
	/// Post office box
	/// </summary>
	public BaseInputControl EntitPobox => new BaseInputControl(driver, formLocator, "#ENTIX___ENTITPOBOX___");
	/// <summary>
	/// Facilities
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, formLocator, "#ENTIX___PSEUDNOVOGR04-container");
	/// <summary>
	/// Facility name
	/// </summary>
	public BaseInputControl Faci1Name => new BaseInputControl(driver, formLocator, "#ENTIX___FACI1NAME____");
	/// <summary>
	/// Facility name
	/// </summary>
	public BaseInputControl Faci2Name => new BaseInputControl(driver, formLocator, "#ENTIX___FACI2NAME____");
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, formLocator, "#ENTIX___PSEUDNOVOGR06-container");
	/// <summary>
	/// Facilities
	/// </summary>
	public ListControl PseudFacilite => new ListControl(driver, formLocator, "#ENTIX___PSEUDFACILITE");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public EntixForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ENTIX")).GetAttribute("data-loading") != "true");
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
