using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EntixForm : Form
{
	/// <summary>
	/// Company identification
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#ENTIX___PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Legal name
	/// </summary>
	public BaseInputControl EntitName => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITNAME____" + IdSuffix, "#ENTIX___ENTITNAME____" + IdSuffix);

	/// <summary>
	/// Founded in
	/// </summary>
	public DateInputControl EntitFounded => new DateInputControl(driver, ContainerLocator, "#ENTIX___ENTITFOUNDED_" + IdSuffix);

	/// <summary>
	/// Company initials
	/// </summary>
	public BaseInputControl EntitInitials => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITINITIALS" + IdSuffix, "#ENTIX___ENTITINITIALS" + IdSuffix);

	/// <summary>
	/// Legal registration
	/// </summary>
	public BaseInputControl EntitRegistra => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITREGISTRA" + IdSuffix, "#ENTIX___ENTITREGISTRA" + IdSuffix);

	/// <summary>
	/// VAT Number
	/// </summary>
	public BaseInputControl EntitTaxnumbe => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITTAXNUMBE" + IdSuffix, "#ENTIX___ENTITTAXNUMBE" + IdSuffix);

	/// <summary>
	/// IBAN (International Bank Account Number)
	/// </summary>
	public BaseInputControl EntitIban => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITIBAN____" + IdSuffix, "#ENTIX___ENTITIBAN____" + IdSuffix);

	/// <summary>
	/// Phone number
	/// </summary>
	public BaseInputControl EntitPhonenum => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITPHONENUM" + IdSuffix, "#ENTIX___ENTITPHONENUM" + IdSuffix);

	/// <summary>
	/// Owner
	/// </summary>
	public CheckboxInputControl EntitOwner => new CheckboxInputControl(driver, ContainerLocator, "#container-ENTIX___ENTITOWNER___" + IdSuffix);

	/// <summary>
	/// Carrier
	/// </summary>
	public CheckboxInputControl EntitCarrier => new CheckboxInputControl(driver, ContainerLocator, "#container-ENTIX___ENTITCARRIER_" + IdSuffix);

	/// <summary>
	/// Supplier
	/// </summary>
	public CheckboxInputControl EntitSupplier => new CheckboxInputControl(driver, ContainerLocator, "#container-ENTIX___ENTITSUPPLIER" + IdSuffix);

	/// <summary>
	/// Manufacturer
	/// </summary>
	public CheckboxInputControl EntitManufact => new CheckboxInputControl(driver, ContainerLocator, "#container-ENTIX___ENTITMANUFACT" + IdSuffix);

	/// <summary>
	/// ACCORDION
	/// </summary>
	public IWebElement PseudNovogr05 => throw new NotImplementedException();

	/// <summary>
	/// Contact
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#ENTIX___PSEUDNOVOGR02" + IdSuffix + "-container");

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl EntitTelephon => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITTELEPHON" + IdSuffix, "#ENTIX___ENTITTELEPHON" + IdSuffix);

	/// <summary>
	/// Fax
	/// </summary>
	public BaseInputControl EntitFax => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITFAX_____" + IdSuffix, "#ENTIX___ENTITFAX_____" + IdSuffix);

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl EntitEmail => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITEMAIL___" + IdSuffix, "#ENTIX___ENTITEMAIL___" + IdSuffix);

	/// <summary>
	/// Web site
	/// </summary>
	public BaseInputControl EntitWebsite => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITWEBSITE_" + IdSuffix, "#ENTIX___ENTITWEBSITE_" + IdSuffix);

	/// <summary>
	/// Person/Department to contact
	/// </summary>
	public BaseInputControl EntitPerson => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITPERSON__" + IdSuffix, "#ENTIX___ENTITPERSON__" + IdSuffix);

	/// <summary>
	/// Contact telephone number
	/// </summary>
	public BaseInputControl EntitContact => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITCONTACT_" + IdSuffix, "#ENTIX___ENTITCONTACT_" + IdSuffix);

	/// <summary>
	/// Language
	/// </summary>
	public BaseInputControl EntitLanguage => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITLANGUAGE" + IdSuffix, "#ENTIX___ENTITLANGUAGE" + IdSuffix);

	/// <summary>
	/// Currency
	/// </summary>
	public BaseInputControl EntitCurrency => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITCURRENCY" + IdSuffix, "#ENTIX___ENTITCURRENCY" + IdSuffix);

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#ENTIX___PSEUDNOVOGR03" + IdSuffix + "-container");

	/// <summary>
	/// Building/house number
	/// </summary>
	public BaseInputControl EntitBuilding => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITBUILDING" + IdSuffix, "#ENTIX___ENTITBUILDING" + IdSuffix);

	/// <summary>
	/// Street
	/// </summary>
	public BaseInputControl EntitStreet => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITSTREET__" + IdSuffix, "#ENTIX___ENTITSTREET__" + IdSuffix);

	/// <summary>
	/// Town/City
	/// </summary>
	public BaseInputControl EntitTown => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITTOWN____" + IdSuffix, "#ENTIX___ENTITTOWN____" + IdSuffix);

	/// <summary>
	/// County/Province
	/// </summary>
	public BaseInputControl EntitCounty => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITCOUNTY__" + IdSuffix, "#ENTIX___ENTITCOUNTY__" + IdSuffix);

	/// <summary>
	/// State/Province
	/// </summary>
	public BaseInputControl EntitState => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITSTATE___" + IdSuffix, "#ENTIX___ENTITSTATE___" + IdSuffix);

	/// <summary>
	/// ZIP/Postal code
	/// </summary>
	public BaseInputControl EntitPostalco => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITPOSTALCO" + IdSuffix, "#ENTIX___ENTITPOSTALCO" + IdSuffix);

	/// <summary>
	/// Post office box
	/// </summary>
	public BaseInputControl EntitPobox => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___ENTITPOBOX___" + IdSuffix, "#ENTIX___ENTITPOBOX___" + IdSuffix);

	/// <summary>
	/// Facilities
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#ENTIX___PSEUDNOVOGR04" + IdSuffix + "-container");

	/// <summary>
	/// Facility name
	/// </summary>
	public BaseInputControl Faci1Name => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___FACI1NAME____" + IdSuffix, "#ENTIX___FACI1NAME____" + IdSuffix);

	/// <summary>
	/// Facility name
	/// </summary>
	public BaseInputControl Faci2Name => new BaseInputControl(driver, ContainerLocator, "container-ENTIX___FACI2NAME____" + IdSuffix, "#ENTIX___FACI2NAME____" + IdSuffix);

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, ContainerLocator, "#ENTIX___PSEUDNOVOGR06" + IdSuffix + "-container");

	/// <summary>
	/// Facilities
	/// </summary>
	public ListControl PseudFacilite => new ListControl(driver, ContainerLocator, "#ENTIX___PSEUDFACILITE" + IdSuffix);

	public EntixForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ENTIX", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
