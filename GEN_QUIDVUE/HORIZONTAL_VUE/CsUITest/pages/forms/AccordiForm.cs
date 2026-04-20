using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AccordiForm : Form
{
	/// <summary>
	/// COMPANY
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#ACCORDI_PSEUDNOVOGR02" + IdSuffix + "-container");

	/// <summary>
	/// Company:
	/// </summary>
	public LookupControl CmpnyDesignat => new LookupControl(driver, ContainerLocator, "container-ACCORDI_CMPNYDESIGNAT" + IdSuffix);
	public SeeMorePage CmpnyDesignatSeeMorePage => new SeeMorePage(driver, "ACCORDI", "ACCORDI_CMPNYDESIGNAT" + IdSuffix);

	/// <summary>
	/// Person
	/// </summary>
	public LookupControl Pess1Name => new LookupControl(driver, ContainerLocator, "container-ACCORDI_PESS1NAME____" + IdSuffix);
	public SeeMorePage Pess1NameSeeMorePage => new SeeMorePage(driver, "ACCORDI", "ACCORDI_PESS1NAME____" + IdSuffix);

	/// <summary>
	/// Sequential no.
	/// </summary>
	public BaseInputControl EquipSequennr => new BaseInputControl(driver, ContainerLocator, "container-ACCORDI_EQUIPSEQUENNR" + IdSuffix, "#ACCORDI_EQUIPSEQUENNR" + IdSuffix);

	/// <summary>
	/// PHOTO
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, ContainerLocator, "#ACCORDI_PSEUDNOVOGR06" + IdSuffix + "-container");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl EquipPhotogra => new BaseInputControl(driver, ContainerLocator, "container-ACCORDI_EQUIPPHOTOGRA" + IdSuffix, "#ACCORDI_EQUIPPHOTOGRA" + IdSuffix);

	/// <summary>
	/// Accordion
	/// </summary>
	public IWebElement PseudNovogr05 => throw new NotImplementedException();

	/// <summary>
	/// Facilities
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#ACCORDI_PSEUDNOVOGR03" + IdSuffix + "-container");

	/// <summary>
	/// Facilities:
	/// </summary>
	public ListControl PseudInstalag => new ListControl(driver, ContainerLocator, "#ACCORDI_PSEUDINSTALAG" + IdSuffix);

	/// <summary>
	/// PLACES
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#ACCORDI_PSEUDNOVOGR04" + IdSuffix + "-container");

	/// <summary>
	/// Facilities
	/// </summary>
	public ListControl PseudInstalac => new ListControl(driver, ContainerLocator, "#ACCORDI_PSEUDINSTALAC" + IdSuffix);

	/// <summary>
	/// Repairs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr11 => new CollapsibleZoneControl(driver, ContainerLocator, "#ACCORDI_PSEUDNOVOGR11" + IdSuffix + "-container");

	/// <summary>
	/// Equipment repairs:
	/// </summary>
	public ListControl PseudReparaco => new ListControl(driver, ContainerLocator, "#ACCORDI_PSEUDREPARACO" + IdSuffix);

	public AccordiForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ACCORDI", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
