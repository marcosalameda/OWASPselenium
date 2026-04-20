using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LeafletdForm : Form
{
	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, ContainerLocator, "container-LEAFLETDEQUIPREGISTNR" + IdSuffix);
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "LEAFLETD", "LEAFLETDEQUIPREGISTNR" + IdSuffix);

	/// <summary>
	/// Type of equipment
	/// </summary>
	public IWebElement TpequTipoequi => throw new NotImplementedException();

	/// <summary>
	/// Scheduling
	/// </summary>
	public BaseInputControl InstaDesignat => new BaseInputControl(driver, ContainerLocator, "container-LEAFLETDINSTADESIGNAT" + IdSuffix, "#LEAFLETDINSTADESIGNAT" + IdSuffix);

	/// <summary>
	/// Start
	/// </summary>
	public DateInputControl InstaDtiniage => new DateInputControl(driver, ContainerLocator, "#LEAFLETDINSTADTINIAGE" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// End
	/// </summary>
	public DateInputControl InstaDtfimage => new DateInputControl(driver, ContainerLocator, "#LEAFLETDINSTADTFIMAGE" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl InstaDescript => new BaseInputControl(driver, ContainerLocator, "container-LEAFLETDINSTADESCRIPT" + IdSuffix, "#LEAFLETDINSTADESCRIPT" + IdSuffix);

	/// <summary>
	/// All day
	/// </summary>
	public CheckboxInputControl InstaAllday => new CheckboxInputControl(driver, ContainerLocator, "#container-LEAFLETDINSTAALLDAY__" + IdSuffix);

	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl InstaSince => new DateInputControl(driver, ContainerLocator, "#LEAFLETDINSTASINCE___" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Until
	/// </summary>
	public DateInputControl InstaUntil => new DateInputControl(driver, ContainerLocator, "#LEAFLETDINSTAUNTIL___" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Quantity of hours:
	/// </summary>
	public BaseInputControl InstaHours => new BaseInputControl(driver, ContainerLocator, "container-LEAFLETDINSTAHOURS___" + IdSuffix, "#LEAFLETDINSTAHOURS___" + IdSuffix);

	/// <summary>
	/// Price per hour:
	/// </summary>
	public BaseInputControl InstaPrecohor => new BaseInputControl(driver, ContainerLocator, "container-LEAFLETDINSTAPRECOHOR" + IdSuffix, "#LEAFLETDINSTAPRECOHOR" + IdSuffix);

	/// <summary>
	/// Value
	/// </summary>
	public BaseInputControl InstaValue => new BaseInputControl(driver, ContainerLocator, "container-LEAFLETDINSTAVALUE___" + IdSuffix, "#LEAFLETDINSTAVALUE___" + IdSuffix);

	/// <summary>
	/// Geographic Coordinates
	/// </summary>
	public BaseInputControl InstaCoordgeo => new BaseInputControl(driver, ContainerLocator, "container-LEAFLETDINSTACOORDGEO" + IdSuffix, "#LEAFLETDINSTACOORDGEO" + IdSuffix);

	public LeafletdForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "LEAFLETD", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
