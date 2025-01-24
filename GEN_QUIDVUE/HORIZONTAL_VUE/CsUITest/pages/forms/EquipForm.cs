using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EquipForm : Form
{
	/// <summary>
	/// Company
	/// </summary>
	public IWebElement PseudNovogr02 => throw new NotImplementedException();

	/// <summary>
	/// Company:
	/// </summary>
	public LookupControl CmpnyDesignat => new LookupControl(driver, ContainerLocator, "container-EQUIP___CMPNYDESIGNAT");
	public SeeMorePage CmpnyDesignatSeeMorePage => new SeeMorePage(driver, "EQUIP", "EQUIP___CMPNYDESIGNAT");

	/// <summary>
	/// Person
	/// </summary>
	public LookupControl Pess1Name => new LookupControl(driver, ContainerLocator, "container-EQUIP___PESS1NAME____");
	public SeeMorePage Pess1NameSeeMorePage => new SeeMorePage(driver, "EQUIP", "EQUIP___PESS1NAME____");

	/// <summary>
	/// EQUIPMENT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP___PSEUDNOVOGR01-container");

	/// <summary>
	/// Sequential No.
	/// </summary>
	public BaseInputControl EquipSequennr => new BaseInputControl(driver, ContainerLocator, "#EQUIP___EQUIPSEQUENNR");

	/// <summary>
	/// Registration No.
	/// </summary>
	public BaseInputControl EquipRegistnr => new BaseInputControl(driver, ContainerLocator, "#EQUIP___EQUIPREGISTNR");

	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl TpequTipoequi => new LookupControl(driver, ContainerLocator, "container-EQUIP___TPEQUTIPOEQUI");
	public SeeMorePage TpequTipoequiSeeMorePage => new SeeMorePage(driver, "EQUIP", "EQUIP___TPEQUTIPOEQUI");

	/// <summary>
	/// Manufacturer's website:
	/// </summary>
	public BaseInputControl EquipSitefabr => new BaseInputControl(driver, ContainerLocator, "#EQUIP___EQUIPSITEFABR");

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-EQUIP___WAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "EQUIP", "EQUIP___WAREHWAREHDES");

	/// <summary>
	/// Item:
	/// </summary>
	public LookupControl ItemItemdes => new LookupControl(driver, ContainerLocator, "container-EQUIP___ITEM_ITEMDES_");
	public SeeMorePage ItemItemdesSeeMorePage => new SeeMorePage(driver, "EQUIP", "EQUIP___ITEM_ITEMDES_");

	/// <summary>
	/// Designation:
	/// </summary>
	public BaseInputControl EquipDesignat => new BaseInputControl(driver, ContainerLocator, "#EQUIP___EQUIPDESIGNAT");

	/// <summary>
	/// Loan Frequency
	/// </summary>
	public IWebElement EquipFrequenc => throw new NotImplementedException();

	/// <summary>
	/// Total Value:
	/// </summary>
	public BaseInputControl EquipValortot => new BaseInputControl(driver, ContainerLocator, "#EQUIP___EQUIPVALORTOT");

	/// <summary>
	/// Acquisition:
	/// </summary>
	public DateInputControl EquipDtaquisi => new DateInputControl(driver, ContainerLocator, "#EQUIP___EQUIPDTAQUISI");

	/// <summary>
	/// Decomission:
	/// </summary>
	public DateInputControl EquipDtdeco => new DateInputControl(driver, ContainerLocator, "#EQUIP___EQUIPDTDECO__");

	/// <summary>
	/// bought
	/// </summary>
	public CheckboxInputControl EquipBought => new CheckboxInputControl(driver, ContainerLocator, "#container-EQUIP___EQUIPBOUGHT__");

	/// <summary>
	/// Asset location
	/// </summary>
	public CollapsibleZoneControl PseudNovogr09 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP___PSEUDNOVOGR09-container");

	/// <summary>
	/// Room No:
	/// </summary>
	public BaseInputControl Room1Roomnr => new BaseInputControl(driver, ContainerLocator, "#EQUIP___ROOM1ROOMNR__");

	/// <summary>
	/// Room Designation:
	/// </summary>
	public IWebElement Room1Designat => throw new NotImplementedException();

	/// <summary>
	/// Reference
	/// </summary>
	public DateInputControl EquipDtrefere => new DateInputControl(driver, ContainerLocator, "#EQUIP___EQUIPDTREFERE", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// First
	/// </summary>
	public BaseInputControl EquipFirst => new BaseInputControl(driver, ContainerLocator, "#EQUIP___EQUIPFIRST___");

	/// <summary>
	/// Before
	/// </summary>
	public BaseInputControl EquipBefore => new BaseInputControl(driver, ContainerLocator, "#EQUIP___EQUIPBEFORE__");

	/// <summary>
	/// Following
	/// </summary>
	public BaseInputControl EquipFollowin => new BaseInputControl(driver, ContainerLocator, "#EQUIP___EQUIPFOLLOWIN");

	/// <summary>
	/// last
	/// </summary>
	public BaseInputControl EquipLast => new BaseInputControl(driver, ContainerLocator, "#EQUIP___EQUIPLAST____");

	/// <summary>
	/// Quantity of transactions
	/// </summary>
	public BaseInputControl EquipQtdmovim => new BaseInputControl(driver, ContainerLocator, "#EQUIP___EQUIPQTDMOVIM");

	/// <summary>
	/// Movements
	/// </summary>
	public BaseInputControl EquipMoviment => new BaseInputControl(driver, ContainerLocator, "#EQUIP___EQUIPMOVIMENT");

	/// <summary>
	/// Where did the equipment go
	/// </summary>
	public IWebElement PseudNovogr10 => throw new NotImplementedException();

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
	public ListControl PseudMovimels => new ListControl(driver, ContainerLocator, "#EQUIP___PSEUDMOVIMELS");

	/// <summary>
	/// PHOTO
	/// </summary>
	public IWebElement PseudNovogr06 => throw new NotImplementedException();

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl EquipPhotogra => new BaseInputControl(driver, ContainerLocator, "#EQUIP___EQUIPPHOTOGRA");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl EquipLastpho => new BaseInputControl(driver, ContainerLocator, "#EQUIP___EQUIPLASTPHO_");

	/// <summary>
	/// ACCORDION
	/// </summary>
	public IWebElement PseudNovogr05 => throw new NotImplementedException();

	/// <summary>
	/// INSTALAÇÕES
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP___PSEUDNOVOGR03-container");

	/// <summary>
	/// Facilities:
	/// </summary>
	public ListControl PseudInstalag => new ListControl(driver, ContainerLocator, "#EQUIP___PSEUDINSTALAG");

	/// <summary>
	/// LOCALS
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP___PSEUDNOVOGR04-container");

	/// <summary>
	/// Facilities:
	/// </summary>
	public ListControl PseudInstalac => new ListControl(driver, ContainerLocator, "#EQUIP___PSEUDINSTALAC");

	/// <summary>
	/// REPAIRS
	/// </summary>
	public CollapsibleZoneControl PseudNovogr11 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP___PSEUDNOVOGR11-container");

	/// <summary>
	/// Equipment Repairs
	/// </summary>
	public ListControl PseudReparaco => new ListControl(driver, ContainerLocator, "#EQUIP___PSEUDREPARACO");

	/// <summary>
	/// Decomission No.
	/// </summary>
	public LookupControl DecomDecomnr => new LookupControl(driver, ContainerLocator, "container-EQUIP___DECOMDECOMNR_");
	public SeeMorePage DecomDecomnrSeeMorePage => new SeeMorePage(driver, "EQUIP", "EQUIP___DECOMDECOMNR_");

	/// <summary>
	/// Downed equipment
	/// </summary>
	public CheckboxInputControl EquipIfabatif => new CheckboxInputControl(driver, ContainerLocator, "#container-EQUIP___EQUIPIFABATIF");

	/// <summary>
	/// Photos:
	/// </summary>
	public CollapsibleZoneControl PseudNovogr08 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP___PSEUDNOVOGR08-container");

	/// <summary>
	/// Photos
	/// </summary>
	public ListControl PseudFotoequi => new ListControl(driver, ContainerLocator, "#EQUIP___PSEUDFOTOEQUI");

	/// <summary>
	/// Inspection visits
	/// </summary>
	public CollapsibleZoneControl PseudNovogr07 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP___PSEUDNOVOGR07-container");

	/// <summary>
	/// Visits:
	/// </summary>
	public ListControl PseudVisequip => new ListControl(driver, ContainerLocator, "#EQUIP___PSEUDVISEQUIP");

	/// <summary>
	/// Digital Attachments
	/// </summary>
	public CollapsibleZoneControl PseudNovogr12 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP___PSEUDNOVOGR12-container");

	/// <summary>
	/// Digital Attachments
	/// </summary>
	public ListControl PseudAnexos => new ListControl(driver, ContainerLocator, "#EQUIP___PSEUDANEXOS__");

	/// <summary>
	/// Timeline
	/// </summary>
	public IWebElement PseudTlequipa => throw new NotImplementedException();

	public EquipForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "EQUIP", containerLocator: containerLocator) { }
}
