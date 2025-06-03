using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EntitForm : Form
{
	/// <summary>
	/// Legal name
	/// </summary>
	public BaseInputControl EntitName => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITNAME____", "#ENTIT___ENTITNAME____");

	/// <summary>
	/// Company initials
	/// </summary>
	public BaseInputControl EntitInitials => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITINITIALS", "#ENTIT___ENTITINITIALS");

	/// <summary>
	/// Legal registration
	/// </summary>
	public BaseInputControl EntitRegistra => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITREGISTRA", "#ENTIT___ENTITREGISTRA");

	/// <summary>
	/// VAT Number
	/// </summary>
	public BaseInputControl EntitTaxnumbe => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITTAXNUMBE", "#ENTIT___ENTITTAXNUMBE");

	/// <summary>
	/// Founded in
	/// </summary>
	public DateInputControl EntitFounded => new DateInputControl(driver, ContainerLocator, "#ENTIT___ENTITFOUNDED_");

	/// <summary>
	/// Owner
	/// </summary>
	public BaseInputControl EntitOwner => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITOWNER___", "#ENTIT___ENTITOWNER___");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl EntitEmail => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITEMAIL___", "#ENTIT___ENTITEMAIL___");

	/// <summary>
	/// Phone number
	/// </summary>
	public BaseInputControl EntitPhonenum => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITPHONENUM", "#ENTIT___ENTITPHONENUM");

	/// <summary>
	/// IBAN (International Bank Account Number)
	/// </summary>
	public BaseInputControl EntitIban => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITIBAN____", "#ENTIT___ENTITIBAN____");

	/// <summary>
	/// Building/house number
	/// </summary>
	public BaseInputControl EntitBuilding => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITBUILDING", "#ENTIT___ENTITBUILDING");

	/// <summary>
	/// Street
	/// </summary>
	public BaseInputControl EntitStreet => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITSTREET__", "#ENTIT___ENTITSTREET__");

	/// <summary>
	/// Town/City
	/// </summary>
	public BaseInputControl EntitTown => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITTOWN____", "#ENTIT___ENTITTOWN____");

	/// <summary>
	/// County/Province
	/// </summary>
	public BaseInputControl EntitCounty => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITCOUNTY__", "#ENTIT___ENTITCOUNTY__");

	/// <summary>
	/// State/Province
	/// </summary>
	public BaseInputControl EntitState => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITSTATE___", "#ENTIT___ENTITSTATE___");

	/// <summary>
	/// Post office box
	/// </summary>
	public BaseInputControl EntitPobox => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITPOBOX___", "#ENTIT___ENTITPOBOX___");

	/// <summary>
	/// ZIP/Postal code
	/// </summary>
	public BaseInputControl EntitPostalco => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITPOSTALCO", "#ENTIT___ENTITPOSTALCO");

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl EntitTelephon => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITTELEPHON", "#ENTIT___ENTITTELEPHON");

	/// <summary>
	/// Fax
	/// </summary>
	public BaseInputControl EntitFax => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITFAX_____", "#ENTIT___ENTITFAX_____");

	/// <summary>
	/// Web site
	/// </summary>
	public BaseInputControl EntitWebsite => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITWEBSITE_", "#ENTIT___ENTITWEBSITE_");

	/// <summary>
	/// Person/Department to contact
	/// </summary>
	public BaseInputControl EntitPerson => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITPERSON__", "#ENTIT___ENTITPERSON__");

	/// <summary>
	/// Contact telephone number
	/// </summary>
	public BaseInputControl EntitContact => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITCONTACT_", "#ENTIT___ENTITCONTACT_");

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
	public BaseInputControl EntitLanguage => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITLANGUAGE", "#ENTIT___ENTITLANGUAGE");

	/// <summary>
	/// Currency
	/// </summary>
	public BaseInputControl EntitCurrency => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITCURRENCY", "#ENTIT___ENTITCURRENCY");

	public EntitForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ENTIT", containerLocator: containerLocator) { }
}
