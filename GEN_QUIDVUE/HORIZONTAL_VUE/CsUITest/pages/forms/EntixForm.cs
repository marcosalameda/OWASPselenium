using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EntixForm : Form
{
	/// <summary>
	/// Company identification
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#ENTIX___PSEUDNOVOGR01-container");

	/// <summary>
	/// Legal name
	/// </summary>
	public BaseInputControl EntitName => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITNAME____", "#ENTIX___ENTITNAME____");

	/// <summary>
	/// Founded in
	/// </summary>
	public DateInputControl EntitFounded => new DateInputControl(driver, ContainerLocator, "#ENTIX___ENTITFOUNDED_");

	/// <summary>
	/// Company initials
	/// </summary>
	public BaseInputControl EntitInitials => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITINITIALS", "#ENTIX___ENTITINITIALS");

	/// <summary>
	/// Legal registration
	/// </summary>
	public BaseInputControl EntitRegistra => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITREGISTRA", "#ENTIX___ENTITREGISTRA");

	/// <summary>
	/// VAT Number
	/// </summary>
	public BaseInputControl EntitTaxnumbe => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITTAXNUMBE", "#ENTIX___ENTITTAXNUMBE");

	/// <summary>
	/// IBAN (International Bank Account Number)
	/// </summary>
	public BaseInputControl EntitIban => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITIBAN____", "#ENTIX___ENTITIBAN____");

	/// <summary>
	/// Phone number
	/// </summary>
	public BaseInputControl EntitPhonenum => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITPHONENUM", "#ENTIX___ENTITPHONENUM");

	/// <summary>
	/// Owner
	/// </summary>
	public BaseInputControl EntitOwner => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITOWNER___", "#ENTIX___ENTITOWNER___");

	/// <summary>
	/// Carrier
	/// </summary>
	public CheckboxInputControl EntitCarrier => new CheckboxInputControl(driver, ContainerLocator, "#container-ENTIX___ENTITCARRIER_");

	/// <summary>
	/// Supplier
	/// </summary>
	public CheckboxInputControl EntitSupplier => new CheckboxInputControl(driver, ContainerLocator, "#container-ENTIX___ENTITSUPPLIER");

	/// <summary>
	/// Manufacturer
	/// </summary>
	public CheckboxInputControl EntitManufact => new CheckboxInputControl(driver, ContainerLocator, "#container-ENTIX___ENTITMANUFACT");

	/// <summary>
	/// ACCORDION
	/// </summary>
	public IWebElement PseudNovogr05 => throw new NotImplementedException();

	/// <summary>
	/// Contact
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#ENTIX___PSEUDNOVOGR02-container");

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl EntitTelephon => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITTELEPHON", "#ENTIX___ENTITTELEPHON");

	/// <summary>
	/// Fax
	/// </summary>
	public BaseInputControl EntitFax => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITFAX_____", "#ENTIX___ENTITFAX_____");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl EntitEmail => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITEMAIL___", "#ENTIX___ENTITEMAIL___");

	/// <summary>
	/// Web site
	/// </summary>
	public BaseInputControl EntitWebsite => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITWEBSITE_", "#ENTIX___ENTITWEBSITE_");

	/// <summary>
	/// Person/Department to contact
	/// </summary>
	public BaseInputControl EntitPerson => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITPERSON__", "#ENTIX___ENTITPERSON__");

	/// <summary>
	/// Contact telephone number
	/// </summary>
	public BaseInputControl EntitContact => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITCONTACT_", "#ENTIX___ENTITCONTACT_");

	/// <summary>
	/// Language
	/// </summary>
	public BaseInputControl EntitLanguage => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITLANGUAGE", "#ENTIX___ENTITLANGUAGE");

	/// <summary>
	/// Currency
	/// </summary>
	public BaseInputControl EntitCurrency => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITCURRENCY", "#ENTIX___ENTITCURRENCY");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#ENTIX___PSEUDNOVOGR03-container");

	/// <summary>
	/// Building/house number
	/// </summary>
	public BaseInputControl EntitBuilding => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITBUILDING", "#ENTIX___ENTITBUILDING");

	/// <summary>
	/// Street
	/// </summary>
	public BaseInputControl EntitStreet => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITSTREET__", "#ENTIX___ENTITSTREET__");

	/// <summary>
	/// Town/City
	/// </summary>
	public BaseInputControl EntitTown => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITTOWN____", "#ENTIX___ENTITTOWN____");

	/// <summary>
	/// County/Province
	/// </summary>
	public BaseInputControl EntitCounty => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITCOUNTY__", "#ENTIX___ENTITCOUNTY__");

	/// <summary>
	/// State/Province
	/// </summary>
	public BaseInputControl EntitState => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITSTATE___", "#ENTIX___ENTITSTATE___");

	/// <summary>
	/// ZIP/Postal code
	/// </summary>
	public BaseInputControl EntitPostalco => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITPOSTALCO", "#ENTIX___ENTITPOSTALCO");

	/// <summary>
	/// Post office box
	/// </summary>
	public BaseInputControl EntitPobox => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITPOBOX___", "#ENTIX___ENTITPOBOX___");

	/// <summary>
	/// Facilities
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#ENTIX___PSEUDNOVOGR04-container");

	/// <summary>
	/// Facility name
	/// </summary>
	public BaseInputControl Faci1Name => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___FACI1NAME____", "#ENTIX___FACI1NAME____");

	/// <summary>
	/// Facility name
	/// </summary>
	public BaseInputControl Faci2Name => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___FACI2NAME____", "#ENTIX___FACI2NAME____");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, ContainerLocator, "#ENTIX___PSEUDNOVOGR06-container");

	/// <summary>
	/// Facilities
	/// </summary>
	public ListControl PseudFacilite => new ListControl(driver, ContainerLocator, "#ENTIX___PSEUDFACILITE");

	public EntixForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ENTIX", containerLocator: containerLocator) { }
}
