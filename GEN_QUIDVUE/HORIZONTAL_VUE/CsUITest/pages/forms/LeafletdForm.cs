using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LeafletdForm : Form
{
	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, ContainerLocator, "container-LEAFLETDEQUIPREGISTNR");
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "LEAFLETD", "LEAFLETDEQUIPREGISTNR");

	/// <summary>
	/// Type of equipment
	/// </summary>
	public IWebElement TpequTipoequi => throw new NotImplementedException();

	/// <summary>
	/// Scheduling
	/// </summary>
	public BaseInputControl InstaDesignat => new BaseInputControl(driver, ContainerLocator, "container-LEAFLETDINSTADESIGNAT", "#LEAFLETDINSTADESIGNAT");

	/// <summary>
	/// Start
	/// </summary>
	public DateInputControl InstaDtiniage => new DateInputControl(driver, ContainerLocator, "#LEAFLETDINSTADTINIAGE", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// End
	/// </summary>
	public DateInputControl InstaDtfimage => new DateInputControl(driver, ContainerLocator, "#LEAFLETDINSTADTFIMAGE", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl InstaDescript => new BaseInputControl(driver, ContainerLocator, "container-LEAFLETDINSTADESCRIPT", "#LEAFLETDINSTADESCRIPT");

	/// <summary>
	/// All day
	/// </summary>
	public CheckboxInputControl InstaAllday => new CheckboxInputControl(driver, ContainerLocator, "#container-LEAFLETDINSTAALLDAY__");

	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl InstaSince => new DateInputControl(driver, ContainerLocator, "#LEAFLETDINSTASINCE___", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Until
	/// </summary>
	public DateInputControl InstaUntil => new DateInputControl(driver, ContainerLocator, "#LEAFLETDINSTAUNTIL___", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Quantity of hours:
	/// </summary>
	public BaseInputControl InstaHours => new BaseInputControl(driver, ContainerLocator, "container-LEAFLETDINSTAHOURS___", "#LEAFLETDINSTAHOURS___");

	/// <summary>
	/// Price per hour:
	/// </summary>
	public BaseInputControl InstaPrecohor => new BaseInputControl(driver, ContainerLocator, "container-LEAFLETDINSTAPRECOHOR", "#LEAFLETDINSTAPRECOHOR");

	/// <summary>
	/// Value
	/// </summary>
	public BaseInputControl InstaValue => new BaseInputControl(driver, ContainerLocator, "container-LEAFLETDINSTAVALUE___", "#LEAFLETDINSTAVALUE___");

	/// <summary>
	/// Geographic Coordinates
	/// </summary>
	public BaseInputControl InstaCoordgeo => new BaseInputControl(driver, ContainerLocator, "container-LEAFLETDINSTACOORDGEO", "#LEAFLETDINSTACOORDGEO");

	public LeafletdForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "LEAFLETD", containerLocator: containerLocator) { }
}
