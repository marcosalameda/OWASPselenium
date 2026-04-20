using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LeaflettForm : Form
{
	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, ContainerLocator, "container-LEAFLETTEQUIPREGISTNR" + IdSuffix);
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "LEAFLETT", "LEAFLETTEQUIPREGISTNR" + IdSuffix);

	/// <summary>
	/// 
	/// </summary>
	public IWebElement TpequTipoequi => throw new NotImplementedException();

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl InstaDescript => new BaseInputControl(driver, ContainerLocator, "container-LEAFLETTINSTADESCRIPT" + IdSuffix, "#LEAFLETTINSTADESCRIPT" + IdSuffix);

	/// <summary>
	/// Scheduling
	/// </summary>
	public BaseInputControl InstaDesignat => new BaseInputControl(driver, ContainerLocator, "container-LEAFLETTINSTADESIGNAT" + IdSuffix, "#LEAFLETTINSTADESIGNAT" + IdSuffix);

	/// <summary>
	/// Start
	/// </summary>
	public DateInputControl InstaDtiniage => new DateInputControl(driver, ContainerLocator, "#LEAFLETTINSTADTINIAGE" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// End
	/// </summary>
	public DateInputControl InstaDtfimage => new DateInputControl(driver, ContainerLocator, "#LEAFLETTINSTADTFIMAGE" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// All day
	/// </summary>
	public CheckboxInputControl InstaAllday => new CheckboxInputControl(driver, ContainerLocator, "#container-LEAFLETTINSTAALLDAY__" + IdSuffix);

	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl InstaSince => new DateInputControl(driver, ContainerLocator, "#LEAFLETTINSTASINCE___" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Until
	/// </summary>
	public DateInputControl InstaUntil => new DateInputControl(driver, ContainerLocator, "#LEAFLETTINSTAUNTIL___" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Quantity of hours:
	/// </summary>
	public BaseInputControl InstaHours => new BaseInputControl(driver, ContainerLocator, "container-LEAFLETTINSTAHOURS___" + IdSuffix, "#LEAFLETTINSTAHOURS___" + IdSuffix);

	/// <summary>
	/// Price per hour:
	/// </summary>
	public BaseInputControl InstaPrecohor => new BaseInputControl(driver, ContainerLocator, "container-LEAFLETTINSTAPRECOHOR" + IdSuffix, "#LEAFLETTINSTAPRECOHOR" + IdSuffix);

	/// <summary>
	/// Value
	/// </summary>
	public BaseInputControl InstaValue => new BaseInputControl(driver, ContainerLocator, "container-LEAFLETTINSTAVALUE___" + IdSuffix, "#LEAFLETTINSTAVALUE___" + IdSuffix);

	/// <summary>
	/// Geographic Coordinates
	/// </summary>
	public BaseInputControl InstaCoordgeo => new BaseInputControl(driver, ContainerLocator, "container-LEAFLETTINSTACOORDGEO" + IdSuffix, "#LEAFLETTINSTACOORDGEO" + IdSuffix);

	public LeaflettForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "LEAFLETT", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
