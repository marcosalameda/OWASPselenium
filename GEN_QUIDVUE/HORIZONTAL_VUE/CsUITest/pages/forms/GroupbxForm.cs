using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class GroupbxForm : Form
{
	/// <summary>
	/// Whole Line Off
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#GROUPBX_PSEUDNOVOGR01-container");

	/// <summary>
	/// Sequential No.:
	/// </summary>
	public BaseInputControl EquipSequennr => new BaseInputControl(driver, ContainerLocator, "#GROUPBX_EQUIPSEQUENNR");

	/// <summary>
	/// Registration No.
	/// </summary>
	public BaseInputControl EquipRegistnr => new BaseInputControl(driver, ContainerLocator, "#GROUPBX_EQUIPREGISTNR");

	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl TpequTipoequi => new LookupControl(driver, ContainerLocator, "container-GROUPBX_TPEQUTIPOEQUI");
	public SeeMorePage TpequTipoequiSeeMorePage => new SeeMorePage(driver, "GROUPBX", "GROUPBX_TPEQUTIPOEQUI");

	/// <summary>
	/// Manufacturer's website:
	/// </summary>
	public BaseInputControl EquipSitefabr => new BaseInputControl(driver, ContainerLocator, "#GROUPBX_EQUIPSITEFABR");

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-GROUPBX_WAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "GROUPBX", "GROUPBX_WAREHWAREHDES");

	/// <summary>
	/// Item:
	/// </summary>
	public LookupControl ItemItemdes => new LookupControl(driver, ContainerLocator, "container-GROUPBX_ITEM_ITEMDES_");
	public SeeMorePage ItemItemdesSeeMorePage => new SeeMorePage(driver, "GROUPBX", "GROUPBX_ITEM_ITEMDES_");

	/// <summary>
	/// Whole Line On
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#GROUPBX_PSEUDNOVOGR02-container");

	/// <summary>
	/// Decomission:
	/// </summary>
	public DateInputControl EquipDtdeco => new DateInputControl(driver, ContainerLocator, "#GROUPBX_EQUIPDTDECO__");

	/// <summary>
	/// Room No.
	/// </summary>
	public BaseInputControl Room1Roomnr => new BaseInputControl(driver, ContainerLocator, "#GROUPBX_ROOM1ROOMNR__");

	/// <summary>
	/// Room Designation
	/// </summary>
	public IWebElement Room1Designat => throw new NotImplementedException();

	/// <summary>
	/// Designation:
	/// </summary>
	public BaseInputControl EquipDesignat => new BaseInputControl(driver, ContainerLocator, "#GROUPBX_EQUIPDESIGNAT");

	/// <summary>
	/// Acquisition:
	/// </summary>
	public DateInputControl EquipDtaquisi => new DateInputControl(driver, ContainerLocator, "#GROUPBX_EQUIPDTAQUISI");

	/// <summary>
	/// Total Value:
	/// </summary>
	public BaseInputControl EquipValortot => new BaseInputControl(driver, ContainerLocator, "#GROUPBX_EQUIPVALORTOT");

	/// <summary>
	/// Loan Frequency
	/// </summary>
	public EnumControl EquipFrequenc => new EnumControl(driver, ContainerLocator, "container-GROUPBX_EQUIPFREQUENC");

	/// <summary>
	/// Reference
	/// </summary>
	public DateInputControl EquipDtrefere => new DateInputControl(driver, ContainerLocator, "#GROUPBX_EQUIPDTREFERE", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// First
	/// </summary>
	public BaseInputControl EquipFirst => new BaseInputControl(driver, ContainerLocator, "#GROUPBX_EQUIPFIRST___");

	/// <summary>
	/// Before
	/// </summary>
	public BaseInputControl EquipBefore => new BaseInputControl(driver, ContainerLocator, "#GROUPBX_EQUIPBEFORE__");

	/// <summary>
	/// Bought
	/// </summary>
	public CheckboxInputControl EquipBought => new CheckboxInputControl(driver, ContainerLocator, "#container-GROUPBX_EQUIPBOUGHT__");

	public GroupbxForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "GROUPBX", containerLocator: containerLocator) { }
}
