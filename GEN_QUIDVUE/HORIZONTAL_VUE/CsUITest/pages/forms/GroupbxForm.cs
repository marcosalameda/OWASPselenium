using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class GroupbxForm : Form
{
	/// <summary>
	/// Whole Line Off
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#GROUPBX_PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Sequential No.:
	/// </summary>
	public BaseInputControl EquipSequennr => new BaseInputControl(driver, ContainerLocator, "container-GROUPBX_EQUIPSEQUENNR" + IdSuffix, "#GROUPBX_EQUIPSEQUENNR" + IdSuffix);

	/// <summary>
	/// Registration No.
	/// </summary>
	public BaseInputControl EquipRegistnr => new BaseInputControl(driver, ContainerLocator, "container-GROUPBX_EQUIPREGISTNR" + IdSuffix, "#GROUPBX_EQUIPREGISTNR" + IdSuffix);

	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl TpequTipoequi => new LookupControl(driver, ContainerLocator, "container-GROUPBX_TPEQUTIPOEQUI" + IdSuffix);
	public SeeMorePage TpequTipoequiSeeMorePage => new SeeMorePage(driver, "GROUPBX", "GROUPBX_TPEQUTIPOEQUI" + IdSuffix);

	/// <summary>
	/// Manufacturer's website:
	/// </summary>
	public BaseInputControl EquipSitefabr => new BaseInputControl(driver, ContainerLocator, "container-GROUPBX_EQUIPSITEFABR" + IdSuffix, "#GROUPBX_EQUIPSITEFABR" + IdSuffix);

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-GROUPBX_WAREHWAREHDES" + IdSuffix);
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "GROUPBX", "GROUPBX_WAREHWAREHDES" + IdSuffix);

	/// <summary>
	/// Item:
	/// </summary>
	public LookupControl ItemItemdes => new LookupControl(driver, ContainerLocator, "container-GROUPBX_ITEM_ITEMDES_" + IdSuffix);
	public SeeMorePage ItemItemdesSeeMorePage => new SeeMorePage(driver, "GROUPBX", "GROUPBX_ITEM_ITEMDES_" + IdSuffix);

	/// <summary>
	/// Whole Line On
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#GROUPBX_PSEUDNOVOGR02" + IdSuffix + "-container");

	/// <summary>
	/// Decomission:
	/// </summary>
	public DateInputControl EquipDtdeco => new DateInputControl(driver, ContainerLocator, "#GROUPBX_EQUIPDTDECO__" + IdSuffix);

	/// <summary>
	/// Room No.
	/// </summary>
	public BaseInputControl Room1Roomnr => new BaseInputControl(driver, ContainerLocator, "container-GROUPBX_ROOM1ROOMNR__" + IdSuffix, "#GROUPBX_ROOM1ROOMNR__" + IdSuffix);

	/// <summary>
	/// Room Designation
	/// </summary>
	public IWebElement Room1Designat => throw new NotImplementedException();

	/// <summary>
	/// Designation:
	/// </summary>
	public BaseInputControl EquipDesignat => new BaseInputControl(driver, ContainerLocator, "container-GROUPBX_EQUIPDESIGNAT" + IdSuffix, "#GROUPBX_EQUIPDESIGNAT" + IdSuffix);

	/// <summary>
	/// Acquisition:
	/// </summary>
	public DateInputControl EquipDtaquisi => new DateInputControl(driver, ContainerLocator, "#GROUPBX_EQUIPDTAQUISI" + IdSuffix);

	/// <summary>
	/// Total Value:
	/// </summary>
	public BaseInputControl EquipValortot => new BaseInputControl(driver, ContainerLocator, "container-GROUPBX_EQUIPVALORTOT" + IdSuffix, "#GROUPBX_EQUIPVALORTOT" + IdSuffix);

	/// <summary>
	/// Loan Frequency
	/// </summary>
	public EnumControl EquipFrequenc => new EnumControl(driver, ContainerLocator, "container-GROUPBX_EQUIPFREQUENC" + IdSuffix);

	/// <summary>
	/// Reference
	/// </summary>
	public DateInputControl EquipDtrefere => new DateInputControl(driver, ContainerLocator, "#GROUPBX_EQUIPDTREFERE" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// First
	/// </summary>
	public BaseInputControl EquipFirst => new BaseInputControl(driver, ContainerLocator, "container-GROUPBX_EQUIPFIRST___" + IdSuffix, "#GROUPBX_EQUIPFIRST___" + IdSuffix);

	/// <summary>
	/// Before
	/// </summary>
	public BaseInputControl EquipBefore => new BaseInputControl(driver, ContainerLocator, "container-GROUPBX_EQUIPBEFORE__" + IdSuffix, "#GROUPBX_EQUIPBEFORE__" + IdSuffix);

	/// <summary>
	/// Bought
	/// </summary>
	public CheckboxInputControl EquipBought => new CheckboxInputControl(driver, ContainerLocator, "#container-GROUPBX_EQUIPBOUGHT__" + IdSuffix);

	public GroupbxForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "GROUPBX", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
