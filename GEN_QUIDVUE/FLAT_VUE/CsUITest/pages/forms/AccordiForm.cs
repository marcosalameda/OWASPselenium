using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AccordiForm : Form
{
	/// <summary>
	/// COMPANY
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#ACCORDI_PSEUDNOVOGR02-container");

	/// <summary>
	/// Company:
	/// </summary>
	public LookupControl CmpnyDesignat => new LookupControl(driver, ContainerLocator, "container-ACCORDI_CMPNYDESIGNAT");
	public SeeMorePage CmpnyDesignatSeeMorePage => new SeeMorePage(driver, "ACCORDI", "ACCORDI_CMPNYDESIGNAT");

	/// <summary>
	/// Person
	/// </summary>
	public LookupControl Pess1Name => new LookupControl(driver, ContainerLocator, "container-ACCORDI_PESS1NAME____");
	public SeeMorePage Pess1NameSeeMorePage => new SeeMorePage(driver, "ACCORDI", "ACCORDI_PESS1NAME____");

	/// <summary>
	/// Sequential no.
	/// </summary>
	public BaseInputControl EquipSequennr => new BaseInputControl(driver, ContainerLocator, "container-ACCORDI_EQUIPSEQUENNR", "#ACCORDI_EQUIPSEQUENNR");

	/// <summary>
	/// PHOTO
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, ContainerLocator, "#ACCORDI_PSEUDNOVOGR06-container");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl EquipPhotogra => new BaseInputControl(driver, ContainerLocator, "container-ACCORDI_EQUIPPHOTOGRA", "#ACCORDI_EQUIPPHOTOGRA");

	/// <summary>
	/// Accordion
	/// </summary>
	public IWebElement PseudNovogr05 => throw new NotImplementedException();

	/// <summary>
	/// Facilities
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#ACCORDI_PSEUDNOVOGR03-container");

	/// <summary>
	/// Facilities:
	/// </summary>
	public ListControl PseudInstalag => new ListControl(driver, ContainerLocator, "#ACCORDI_PSEUDINSTALAG");

	/// <summary>
	/// PLACES
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#ACCORDI_PSEUDNOVOGR04-container");

	/// <summary>
	/// Facilities
	/// </summary>
	public ListControl PseudInstalac => new ListControl(driver, ContainerLocator, "#ACCORDI_PSEUDINSTALAC");

	/// <summary>
	/// Repairs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr11 => new CollapsibleZoneControl(driver, ContainerLocator, "#ACCORDI_PSEUDNOVOGR11-container");

	/// <summary>
	/// Equipment repairs:
	/// </summary>
	public ListControl PseudReparaco => new ListControl(driver, ContainerLocator, "#ACCORDI_PSEUDREPARACO");

	public AccordiForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ACCORDI", containerLocator: containerLocator) { }
}
