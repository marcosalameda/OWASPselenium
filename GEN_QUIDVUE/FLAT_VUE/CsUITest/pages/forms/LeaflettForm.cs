using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LeaflettForm : Form
{
	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, ContainerLocator, "container-LEAFLETTEQUIPREGISTNR");
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "LEAFLETT", "LEAFLETTEQUIPREGISTNR");

	/// <summary>
	/// 
	/// </summary>
	public IWebElement TpequTipoequi => throw new NotImplementedException();

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl InstaDescript => new BaseInputControl(driver, ContainerLocator, "#LEAFLETTINSTADESCRIPT");

	/// <summary>
	/// Scheduling
	/// </summary>
	public BaseInputControl InstaDesignat => new BaseInputControl(driver, ContainerLocator, "#LEAFLETTINSTADESIGNAT");

	/// <summary>
	/// Start
	/// </summary>
	public DateInputControl InstaDtiniage => new DateInputControl(driver, ContainerLocator, "#LEAFLETTINSTADTINIAGE", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// End
	/// </summary>
	public DateInputControl InstaDtfimage => new DateInputControl(driver, ContainerLocator, "#LEAFLETTINSTADTFIMAGE", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// All day
	/// </summary>
	public CheckboxInputControl InstaAllday => new CheckboxInputControl(driver, ContainerLocator, "#container-LEAFLETTINSTAALLDAY__");

	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl InstaSince => new DateInputControl(driver, ContainerLocator, "#LEAFLETTINSTASINCE___", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Until
	/// </summary>
	public DateInputControl InstaUntil => new DateInputControl(driver, ContainerLocator, "#LEAFLETTINSTAUNTIL___", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Quantity of hours:
	/// </summary>
	public BaseInputControl InstaHours => new BaseInputControl(driver, ContainerLocator, "#LEAFLETTINSTAHOURS___");

	/// <summary>
	/// Price per hour:
	/// </summary>
	public BaseInputControl InstaPrecohor => new BaseInputControl(driver, ContainerLocator, "#LEAFLETTINSTAPRECOHOR");

	/// <summary>
	/// Value
	/// </summary>
	public BaseInputControl InstaValue => new BaseInputControl(driver, ContainerLocator, "#LEAFLETTINSTAVALUE___");

	/// <summary>
	/// Geographic Coordinates
	/// </summary>
	public BaseInputControl InstaCoordgeo => new BaseInputControl(driver, ContainerLocator, "#LEAFLETTINSTACOORDGEO");

	public LeaflettForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "LEAFLETT", containerLocator: containerLocator) { }
}
