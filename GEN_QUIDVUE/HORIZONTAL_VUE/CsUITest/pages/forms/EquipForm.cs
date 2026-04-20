using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EquipForm : Form
{
	/// <summary>
	/// Company
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP___PSEUDNOVOGR02" + IdSuffix + "-container");

	/// <summary>
	/// Company:
	/// </summary>
	public LookupControl CmpnyDesignat => new LookupControl(driver, ContainerLocator, "container-EQUIP___CMPNYDESIGNAT" + IdSuffix);
	public SeeMorePage CmpnyDesignatSeeMorePage => new SeeMorePage(driver, "EQUIP", "EQUIP___CMPNYDESIGNAT" + IdSuffix);

	/// <summary>
	/// Person
	/// </summary>
	public LookupControl Pess1Name => new LookupControl(driver, ContainerLocator, "container-EQUIP___PESS1NAME____" + IdSuffix);
	public SeeMorePage Pess1NameSeeMorePage => new SeeMorePage(driver, "EQUIP", "EQUIP___PESS1NAME____" + IdSuffix);

	/// <summary>
	/// EQUIPMENT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP___PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Sequential No.
	/// </summary>
	public BaseInputControl EquipSequennr => new BaseInputControl(driver, ContainerLocator, "container-EQUIP___EQUIPSEQUENNR" + IdSuffix, "#EQUIP___EQUIPSEQUENNR" + IdSuffix);

	/// <summary>
	/// Registration No.
	/// </summary>
	public BaseInputControl EquipRegistnr => new BaseInputControl(driver, ContainerLocator, "container-EQUIP___EQUIPREGISTNR" + IdSuffix, "#EQUIP___EQUIPREGISTNR" + IdSuffix);

	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl TpequTipoequi => new LookupControl(driver, ContainerLocator, "container-EQUIP___TPEQUTIPOEQUI" + IdSuffix);
	public SeeMorePage TpequTipoequiSeeMorePage => new SeeMorePage(driver, "EQUIP", "EQUIP___TPEQUTIPOEQUI" + IdSuffix);

	/// <summary>
	/// Manufacturer's website:
	/// </summary>
	public BaseInputControl EquipSitefabr => new BaseInputControl(driver, ContainerLocator, "container-EQUIP___EQUIPSITEFABR" + IdSuffix, "#EQUIP___EQUIPSITEFABR" + IdSuffix);

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-EQUIP___WAREHWAREHDES" + IdSuffix);
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "EQUIP", "EQUIP___WAREHWAREHDES" + IdSuffix);

	/// <summary>
	/// Item:
	/// </summary>
	public LookupControl ItemItemdes => new LookupControl(driver, ContainerLocator, "container-EQUIP___ITEM_ITEMDES_" + IdSuffix);
	public SeeMorePage ItemItemdesSeeMorePage => new SeeMorePage(driver, "EQUIP", "EQUIP___ITEM_ITEMDES_" + IdSuffix);

	/// <summary>
	/// Designation:
	/// </summary>
	public BaseInputControl EquipDesignat => new BaseInputControl(driver, ContainerLocator, "container-EQUIP___EQUIPDESIGNAT" + IdSuffix, "#EQUIP___EQUIPDESIGNAT" + IdSuffix);

	/// <summary>
	/// Loan Frequency
	/// </summary>
	public IWebElement EquipFrequenc => throw new NotImplementedException();

	/// <summary>
	/// Total Value:
	/// </summary>
	public BaseInputControl EquipValortot => new BaseInputControl(driver, ContainerLocator, "container-EQUIP___EQUIPVALORTOT" + IdSuffix, "#EQUIP___EQUIPVALORTOT" + IdSuffix);

	/// <summary>
	/// Acquisition:
	/// </summary>
	public DateInputControl EquipDtaquisi => new DateInputControl(driver, ContainerLocator, "#EQUIP___EQUIPDTAQUISI" + IdSuffix);

	/// <summary>
	/// Decomission:
	/// </summary>
	public DateInputControl EquipDtdeco => new DateInputControl(driver, ContainerLocator, "#EQUIP___EQUIPDTDECO__" + IdSuffix);

	/// <summary>
	/// bought
	/// </summary>
	public CheckboxInputControl EquipBought => new CheckboxInputControl(driver, ContainerLocator, "#container-EQUIP___EQUIPBOUGHT__" + IdSuffix);

	/// <summary>
	/// Asset location
	/// </summary>
	public CollapsibleZoneControl PseudNovogr09 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP___PSEUDNOVOGR09" + IdSuffix + "-container");

	/// <summary>
	/// Room No:
	/// </summary>
	public BaseInputControl Room1Roomnr => new BaseInputControl(driver, ContainerLocator, "container-EQUIP___ROOM1ROOMNR__" + IdSuffix, "#EQUIP___ROOM1ROOMNR__" + IdSuffix);

	/// <summary>
	/// Room Designation:
	/// </summary>
	public IWebElement Room1Designat => throw new NotImplementedException();

	/// <summary>
	/// Reference
	/// </summary>
	public DateInputControl EquipDtrefere => new DateInputControl(driver, ContainerLocator, "#EQUIP___EQUIPDTREFERE" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// First
	/// </summary>
	public BaseInputControl EquipFirst => new BaseInputControl(driver, ContainerLocator, "container-EQUIP___EQUIPFIRST___" + IdSuffix, "#EQUIP___EQUIPFIRST___" + IdSuffix);

	/// <summary>
	/// Before
	/// </summary>
	public BaseInputControl EquipBefore => new BaseInputControl(driver, ContainerLocator, "container-EQUIP___EQUIPBEFORE__" + IdSuffix, "#EQUIP___EQUIPBEFORE__" + IdSuffix);

	/// <summary>
	/// Following
	/// </summary>
	public BaseInputControl EquipFollowin => new BaseInputControl(driver, ContainerLocator, "container-EQUIP___EQUIPFOLLOWIN" + IdSuffix, "#EQUIP___EQUIPFOLLOWIN" + IdSuffix);

	/// <summary>
	/// last
	/// </summary>
	public BaseInputControl EquipLast => new BaseInputControl(driver, ContainerLocator, "container-EQUIP___EQUIPLAST____" + IdSuffix, "#EQUIP___EQUIPLAST____" + IdSuffix);

	/// <summary>
	/// Quantity of transactions
	/// </summary>
	public BaseInputControl EquipQtdmovim => new BaseInputControl(driver, ContainerLocator, "container-EQUIP___EQUIPQTDMOVIM" + IdSuffix, "#EQUIP___EQUIPQTDMOVIM" + IdSuffix);

	/// <summary>
	/// Movements
	/// </summary>
	public BaseInputControl EquipMoviment => new BaseInputControl(driver, ContainerLocator, "container-EQUIP___EQUIPMOVIMENT" + IdSuffix, "#EQUIP___EQUIPMOVIMENT" + IdSuffix);

	/// <summary>
	/// Where did the equipment go
	/// </summary>
	public CollapsibleZoneControl PseudNovogr10 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP___PSEUDNOVOGR10" + IdSuffix + "-container");

	/// <summary>
	/// Choose room
	/// </summary>
	public IWebElement PseudMovimevv => throw new NotImplementedException();

	/// <summary>
	/// Multiple Values Extended
	/// </summary>
	public IWebElement PseudRoomsmve => throw new NotImplementedException();

	/// <summary>
	/// Equipment movement history:
	/// </summary>
	public ListControl PseudMovimels => new ListControl(driver, ContainerLocator, "#EQUIP___PSEUDMOVIMELS" + IdSuffix);

	/// <summary>
	/// PHOTO
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP___PSEUDNOVOGR06" + IdSuffix + "-container");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl EquipPhotogra => new BaseInputControl(driver, ContainerLocator, "container-EQUIP___EQUIPPHOTOGRA" + IdSuffix, "#EQUIP___EQUIPPHOTOGRA" + IdSuffix);

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl EquipLastpho => new BaseInputControl(driver, ContainerLocator, "container-EQUIP___EQUIPLASTPHO_" + IdSuffix, "#EQUIP___EQUIPLASTPHO_" + IdSuffix);

	/// <summary>
	/// ACCORDION
	/// </summary>
	public IWebElement PseudNovogr05 => throw new NotImplementedException();

	/// <summary>
	/// INSTALAÇÕES
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP___PSEUDNOVOGR03" + IdSuffix + "-container");

	/// <summary>
	/// Facilities:
	/// </summary>
	public ListControl PseudInstalag => new ListControl(driver, ContainerLocator, "#EQUIP___PSEUDINSTALAG" + IdSuffix);

	/// <summary>
	/// LOCALS
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP___PSEUDNOVOGR04" + IdSuffix + "-container");

	/// <summary>
	/// Facilities:
	/// </summary>
	public ListControl PseudInstalac => new ListControl(driver, ContainerLocator, "#EQUIP___PSEUDINSTALAC" + IdSuffix);

	/// <summary>
	/// REPAIRS
	/// </summary>
	public CollapsibleZoneControl PseudNovogr11 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP___PSEUDNOVOGR11" + IdSuffix + "-container");

	/// <summary>
	/// Equipment Repairs
	/// </summary>
	public ListControl PseudReparaco => new ListControl(driver, ContainerLocator, "#EQUIP___PSEUDREPARACO" + IdSuffix);

	/// <summary>
	/// Decomission No.
	/// </summary>
	public LookupControl DecomDecomnr => new LookupControl(driver, ContainerLocator, "container-EQUIP___DECOMDECOMNR_" + IdSuffix);
	public SeeMorePage DecomDecomnrSeeMorePage => new SeeMorePage(driver, "EQUIP", "EQUIP___DECOMDECOMNR_" + IdSuffix);

	/// <summary>
	/// Downed equipment
	/// </summary>
	public CheckboxInputControl EquipIfabatif => new CheckboxInputControl(driver, ContainerLocator, "#container-EQUIP___EQUIPIFABATIF" + IdSuffix);

	/// <summary>
	/// Photos:
	/// </summary>
	public CollapsibleZoneControl PseudNovogr08 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP___PSEUDNOVOGR08" + IdSuffix + "-container");

	/// <summary>
	/// Photos
	/// </summary>
	public ListControl PseudFotoequi => new ListControl(driver, ContainerLocator, "#EQUIP___PSEUDFOTOEQUI" + IdSuffix);

	/// <summary>
	/// Inspection visits
	/// </summary>
	public CollapsibleZoneControl PseudNovogr07 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP___PSEUDNOVOGR07" + IdSuffix + "-container");

	/// <summary>
	/// Visits:
	/// </summary>
	public ListControl PseudVisequip => new ListControl(driver, ContainerLocator, "#EQUIP___PSEUDVISEQUIP" + IdSuffix);

	/// <summary>
	/// Digital Attachments
	/// </summary>
	public CollapsibleZoneControl PseudNovogr12 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP___PSEUDNOVOGR12" + IdSuffix + "-container");

	/// <summary>
	/// Digital Attachments
	/// </summary>
	public ListControl PseudAnexos => new ListControl(driver, ContainerLocator, "#EQUIP___PSEUDANEXOS__" + IdSuffix);

	/// <summary>
	/// Timeline
	/// </summary>
	public IWebElement PseudTlequipa => throw new NotImplementedException();

	public EquipForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "EQUIP", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
