using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class InstaForm : Form
{
	/// <summary>
	/// Equipment
	/// </summary>
	public IWebElement PseudNovogr01 => throw new NotImplementedException();

	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl TpequTipoequi => new LookupControl(driver, ContainerLocator, "container-INSTA___TPEQUTIPOEQUI");
	public SeeMorePage TpequTipoequiSeeMorePage => new SeeMorePage(driver, "INSTA", "INSTA___TPEQUTIPOEQUI");

	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, ContainerLocator, "container-INSTA___EQUIPREGISTNR");
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "INSTA", "INSTA___EQUIPREGISTNR");

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
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#INSTA___PSEUDNOVOGR02-container");

	/// <summary>
	/// Since:
	/// </summary>
	public DateInputControl InstaSince => new DateInputControl(driver, ContainerLocator, "#INSTA___INSTASINCE___", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Until
	/// </summary>
	public DateInputControl InstaUntil => new DateInputControl(driver, ContainerLocator, "#INSTA___INSTAUNTIL___", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Quantity of hours:
	/// </summary>
	public BaseInputControl InstaHours => new BaseInputControl(driver, ContainerLocator, "#INSTA___INSTAHOURS___");

	/// <summary>
	/// Price per hour:
	/// </summary>
	public BaseInputControl InstaPrecohor => new BaseInputControl(driver, ContainerLocator, "#INSTA___INSTAPRECOHOR");

	/// <summary>
	/// Value:
	/// </summary>
	public BaseInputControl InstaValue => new BaseInputControl(driver, ContainerLocator, "#INSTA___INSTAVALUE___");

	/// <summary>
	/// LOCAL
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#INSTA___PSEUDNOVOGR03-container");

	/// <summary>
	/// Geographic Coordinates
	/// </summary>
	public BaseInputControl InstaCoordgeo => new BaseInputControl(driver, ContainerLocator, "#INSTA___INSTACOORDGEO");

	public InstaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "INSTA", containerLocator: containerLocator) { }
}
