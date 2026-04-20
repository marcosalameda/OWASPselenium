using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class InstaForm : Form
{
	/// <summary>
	/// Equipment
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#INSTA___PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl TpequTipoequi => new LookupControl(driver, ContainerLocator, "container-INSTA___TPEQUTIPOEQUI" + IdSuffix);
	public SeeMorePage TpequTipoequiSeeMorePage => new SeeMorePage(driver, "INSTA", "INSTA___TPEQUTIPOEQUI" + IdSuffix);

	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, ContainerLocator, "container-INSTA___EQUIPREGISTNR" + IdSuffix);
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "INSTA", "INSTA___EQUIPREGISTNR" + IdSuffix);

	/// <summary>
	/// Designation:
	/// </summary>
	public IWebElement EquipDesignat => throw new NotImplementedException();

	/// <summary>
	/// Photo
	/// </summary>
	public IWebElement EquipPhotogra => throw new NotImplementedException();

	/// <summary>
	/// Cost
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#INSTA___PSEUDNOVOGR02" + IdSuffix + "-container");

	/// <summary>
	/// Since:
	/// </summary>
	public DateInputControl InstaSince => new DateInputControl(driver, ContainerLocator, "#INSTA___INSTASINCE___" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Until
	/// </summary>
	public DateInputControl InstaUntil => new DateInputControl(driver, ContainerLocator, "#INSTA___INSTAUNTIL___" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Quantity of hours:
	/// </summary>
	public BaseInputControl InstaHours => new BaseInputControl(driver, ContainerLocator, "container-INSTA___INSTAHOURS___" + IdSuffix, "#INSTA___INSTAHOURS___" + IdSuffix);

	/// <summary>
	/// Price per hour:
	/// </summary>
	public BaseInputControl InstaPrecohor => new BaseInputControl(driver, ContainerLocator, "container-INSTA___INSTAPRECOHOR" + IdSuffix, "#INSTA___INSTAPRECOHOR" + IdSuffix);

	/// <summary>
	/// Value:
	/// </summary>
	public BaseInputControl InstaValue => new BaseInputControl(driver, ContainerLocator, "container-INSTA___INSTAVALUE___" + IdSuffix, "#INSTA___INSTAVALUE___" + IdSuffix);

	/// <summary>
	/// LOCAL
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#INSTA___PSEUDNOVOGR03" + IdSuffix + "-container");

	/// <summary>
	/// Geographic Coordinates
	/// </summary>
	public BaseInputControl InstaCoordgeo => new BaseInputControl(driver, ContainerLocator, "container-INSTA___INSTACOORDGEO" + IdSuffix, "#INSTA___INSTACOORDGEO" + IdSuffix);

	public InstaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "INSTA", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
