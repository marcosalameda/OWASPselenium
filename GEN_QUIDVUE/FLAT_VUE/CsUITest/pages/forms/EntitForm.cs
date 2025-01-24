using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EntitForm : Form
{
	/// <summary>
	/// Legal name
	/// </summary>
	public BaseInputControl EntitName => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITNAME____");

	/// <summary>
	/// Company initials
	/// </summary>
	public BaseInputControl EntitInitials => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITINITIALS");

	/// <summary>
	/// Legal registration
	/// </summary>
	public BaseInputControl EntitRegistra => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITREGISTRA");

	/// <summary>
	/// VAT Number
	/// </summary>
	public BaseInputControl EntitTaxnumbe => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITTAXNUMBE");

	/// <summary>
	/// Founded in
	/// </summary>
	public DateInputControl EntitFounded => new DateInputControl(driver, ContainerLocator, "#ENTIT___ENTITFOUNDED_");

	/// <summary>
	/// Owner
	/// </summary>
	public BaseInputControl EntitOwner => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITOWNER___");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl EntitEmail => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITEMAIL___");

	/// <summary>
	/// Phone number
	/// </summary>
	public BaseInputControl EntitPhonenum => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITPHONENUM");

	/// <summary>
	/// IBAN (International Bank Account Number)
	/// </summary>
	public BaseInputControl EntitIban => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITIBAN____");

	/// <summary>
	/// Building/house number
	/// </summary>
	public BaseInputControl EntitBuilding => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITBUILDING");

	/// <summary>
	/// Street
	/// </summary>
	public BaseInputControl EntitStreet => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITSTREET__");

	/// <summary>
	/// Town/City
	/// </summary>
	public BaseInputControl EntitTown => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITTOWN____");

	/// <summary>
	/// County/Province
	/// </summary>
	public BaseInputControl EntitCounty => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITCOUNTY__");

	/// <summary>
	/// State/Province
	/// </summary>
	public BaseInputControl EntitState => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITSTATE___");

	/// <summary>
	/// Post office box
	/// </summary>
	public BaseInputControl EntitPobox => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITPOBOX___");

	/// <summary>
	/// ZIP/Postal code
	/// </summary>
	public BaseInputControl EntitPostalco => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITPOSTALCO");

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl EntitTelephon => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITTELEPHON");

	/// <summary>
	/// Fax
	/// </summary>
	public BaseInputControl EntitFax => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITFAX_____");

	/// <summary>
	/// Web site
	/// </summary>
	public BaseInputControl EntitWebsite => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITWEBSITE_");

	/// <summary>
	/// Person/Department to contact
	/// </summary>
	public BaseInputControl EntitPerson => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITPERSON__");

	/// <summary>
	/// Contact telephone number
	/// </summary>
	public BaseInputControl EntitContact => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITCONTACT_");

	/// <summary>
	/// Carrier
	/// </summary>
	public CheckboxInputControl EntitCarrier => new CheckboxInputControl(driver, ContainerLocator, "#container-ENTIT___ENTITCARRIER_");

	/// <summary>
	/// Supplier
	/// </summary>
	public CheckboxInputControl EntitSupplier => new CheckboxInputControl(driver, ContainerLocator, "#container-ENTIT___ENTITSUPPLIER");

	/// <summary>
	/// Manufacturer
	/// </summary>
	public CheckboxInputControl EntitManufact => new CheckboxInputControl(driver, ContainerLocator, "#container-ENTIT___ENTITMANUFACT");

	/// <summary>
	/// Facility name
	/// </summary>
	public LookupControl Faci1Name => new LookupControl(driver, ContainerLocator, "container-ENTIT___FACI1NAME____");
	public SeeMorePage Faci1NameSeeMorePage => new SeeMorePage(driver, "ENTIT", "ENTIT___FACI1NAME____");

	/// <summary>
	/// Facility name
	/// </summary>
	public LookupControl Faci2Name => new LookupControl(driver, ContainerLocator, "container-ENTIT___FACI2NAME____");
	public SeeMorePage Faci2NameSeeMorePage => new SeeMorePage(driver, "ENTIT", "ENTIT___FACI2NAME____");

	/// <summary>
	/// Language
	/// </summary>
	public BaseInputControl EntitLanguage => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITLANGUAGE");

	/// <summary>
	/// Currency
	/// </summary>
	public BaseInputControl EntitCurrency => new BaseInputControl(driver, ContainerLocator, "#ENTIT___ENTITCURRENCY");

	public EntitForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ENTIT", containerLocator: containerLocator) { }
}
