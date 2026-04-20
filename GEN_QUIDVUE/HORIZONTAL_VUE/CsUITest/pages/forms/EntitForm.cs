using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EntitForm : Form
{
	/// <summary>
	/// Legal name
	/// </summary>
	public BaseInputControl EntitName => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITNAME____" + IdSuffix, "#ENTIT___ENTITNAME____" + IdSuffix);

	/// <summary>
	/// Company initials
	/// </summary>
	public BaseInputControl EntitInitials => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITINITIALS" + IdSuffix, "#ENTIT___ENTITINITIALS" + IdSuffix);

	/// <summary>
	/// Legal registration
	/// </summary>
	public BaseInputControl EntitRegistra => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITREGISTRA" + IdSuffix, "#ENTIT___ENTITREGISTRA" + IdSuffix);

	/// <summary>
	/// VAT Number
	/// </summary>
	public BaseInputControl EntitTaxnumbe => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITTAXNUMBE" + IdSuffix, "#ENTIT___ENTITTAXNUMBE" + IdSuffix);

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl EntitEmail => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITEMAIL___" + IdSuffix, "#ENTIT___ENTITEMAIL___" + IdSuffix);

	/// <summary>
	/// Phone number
	/// </summary>
	public BaseInputControl EntitPhonenum => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITPHONENUM" + IdSuffix, "#ENTIT___ENTITPHONENUM" + IdSuffix);

	/// <summary>
	/// IBAN (International Bank Account Number)
	/// </summary>
	public BaseInputControl EntitIban => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITIBAN____" + IdSuffix, "#ENTIT___ENTITIBAN____" + IdSuffix);

	/// <summary>
	/// Building/house number
	/// </summary>
	public BaseInputControl EntitBuilding => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITBUILDING" + IdSuffix, "#ENTIT___ENTITBUILDING" + IdSuffix);

	/// <summary>
	/// Street
	/// </summary>
	public BaseInputControl EntitStreet => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITSTREET__" + IdSuffix, "#ENTIT___ENTITSTREET__" + IdSuffix);

	/// <summary>
	/// Town/City
	/// </summary>
	public BaseInputControl EntitTown => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITTOWN____" + IdSuffix, "#ENTIT___ENTITTOWN____" + IdSuffix);

	/// <summary>
	/// County/Province
	/// </summary>
	public BaseInputControl EntitCounty => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITCOUNTY__" + IdSuffix, "#ENTIT___ENTITCOUNTY__" + IdSuffix);

	/// <summary>
	/// State/Province
	/// </summary>
	public BaseInputControl EntitState => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITSTATE___" + IdSuffix, "#ENTIT___ENTITSTATE___" + IdSuffix);

	/// <summary>
	/// Post office box
	/// </summary>
	public BaseInputControl EntitPobox => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITPOBOX___" + IdSuffix, "#ENTIT___ENTITPOBOX___" + IdSuffix);

	/// <summary>
	/// ZIP/Postal code
	/// </summary>
	public BaseInputControl EntitPostalco => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITPOSTALCO" + IdSuffix, "#ENTIT___ENTITPOSTALCO" + IdSuffix);

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl EntitTelephon => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITTELEPHON" + IdSuffix, "#ENTIT___ENTITTELEPHON" + IdSuffix);

	/// <summary>
	/// Fax
	/// </summary>
	public BaseInputControl EntitFax => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITFAX_____" + IdSuffix, "#ENTIT___ENTITFAX_____" + IdSuffix);

	/// <summary>
	/// Web site
	/// </summary>
	public BaseInputControl EntitWebsite => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITWEBSITE_" + IdSuffix, "#ENTIT___ENTITWEBSITE_" + IdSuffix);

	/// <summary>
	/// Person/Department to contact
	/// </summary>
	public BaseInputControl EntitPerson => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITPERSON__" + IdSuffix, "#ENTIT___ENTITPERSON__" + IdSuffix);

	/// <summary>
	/// Contact telephone number
	/// </summary>
	public BaseInputControl EntitContact => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITCONTACT_" + IdSuffix, "#ENTIT___ENTITCONTACT_" + IdSuffix);

	/// <summary>
	/// Owner
	/// </summary>
	public CheckboxInputControl EntitOwner => new CheckboxInputControl(driver, ContainerLocator, "#container-ENTIT___ENTITOWNER___" + IdSuffix);

	/// <summary>
	/// Carrier
	/// </summary>
	public CheckboxInputControl EntitCarrier => new CheckboxInputControl(driver, ContainerLocator, "#container-ENTIT___ENTITCARRIER_" + IdSuffix);

	/// <summary>
	/// Supplier
	/// </summary>
	public CheckboxInputControl EntitSupplier => new CheckboxInputControl(driver, ContainerLocator, "#container-ENTIT___ENTITSUPPLIER" + IdSuffix);

	/// <summary>
	/// Manufacturer
	/// </summary>
	public CheckboxInputControl EntitManufact => new CheckboxInputControl(driver, ContainerLocator, "#container-ENTIT___ENTITMANUFACT" + IdSuffix);

	/// <summary>
	/// Founded in
	/// </summary>
	public DateInputControl EntitFounded => new DateInputControl(driver, ContainerLocator, "#ENTIT___ENTITFOUNDED_" + IdSuffix);

	/// <summary>
	/// Facility name
	/// </summary>
	public LookupControl Faci1Name => new LookupControl(driver, ContainerLocator, "container-ENTIT___FACI1NAME____" + IdSuffix);
	public SeeMorePage Faci1NameSeeMorePage => new SeeMorePage(driver, "ENTIT", "ENTIT___FACI1NAME____" + IdSuffix);

	/// <summary>
	/// Facility name
	/// </summary>
	public LookupControl Faci2Name => new LookupControl(driver, ContainerLocator, "container-ENTIT___FACI2NAME____" + IdSuffix);
	public SeeMorePage Faci2NameSeeMorePage => new SeeMorePage(driver, "ENTIT", "ENTIT___FACI2NAME____" + IdSuffix);

	/// <summary>
	/// Language
	/// </summary>
	public BaseInputControl EntitLanguage => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITLANGUAGE" + IdSuffix, "#ENTIT___ENTITLANGUAGE" + IdSuffix);

	/// <summary>
	/// Currency
	/// </summary>
	public BaseInputControl EntitCurrency => new BaseInputControl(driver, ContainerLocator, "container-ENTIT___ENTITCURRENCY" + IdSuffix, "#ENTIT___ENTITCURRENCY" + IdSuffix);

	public EntitForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ENTIT", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
