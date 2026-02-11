using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArtigForm : Form
{
	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl ItemItemcod => new BaseInputControl(driver, ContainerLocator, "container-ARTIG___ITEM_ITEMCOD_", "#ARTIG___ITEM_ITEMCOD_");

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-ARTIG___WAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "ARTIG", "ARTIG___WAREHWAREHDES");

	/// <summary>
	/// Code
	/// </summary>
	public IWebElement GitemItemgcod => throw new NotImplementedException();

	/// <summary>
	/// Designation:
	/// </summary>
	public LookupControl GitemItemdes => new LookupControl(driver, ContainerLocator, "container-ARTIG___GITEMITEMDES_");
	public SeeMorePage GitemItemdesSeeMorePage => new SeeMorePage(driver, "ARTIG", "ARTIG___GITEMITEMDES_");

	/// <summary>
	/// Warehouse
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#ARTIG___PSEUDNOVOGR02-container");

	/// <summary>
	/// Global Item
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#ARTIG___PSEUDNOVOGR01-container");

	/// <summary>
	/// Item
	/// </summary>
	public BaseInputControl ItemItemdes => new BaseInputControl(driver, ContainerLocator, "container-ARTIG___ITEM_ITEMDES_", "#ARTIG___ITEM_ITEMDES_");

	/// <summary>
	/// In use
	/// </summary>
	public CheckboxInputControl ItemValid => new CheckboxInputControl(driver, ContainerLocator, "#container-ARTIG___ITEM_VALID___");

	/// <summary>
	/// Tipo
	/// </summary>
	public EnumControl ItemItemtype => new EnumControl(driver, ContainerLocator, "container-ARTIG___ITEM_ITEMTYPE");

	/// <summary>
	/// Entries:
	/// </summary>
	public BaseInputControl ItemEntries => new BaseInputControl(driver, ContainerLocator, "container-ARTIG___ITEM_ENTRIES_", "#ARTIG___ITEM_ENTRIES_");

	/// <summary>
	/// Output:
	/// </summary>
	public BaseInputControl ItemExits => new BaseInputControl(driver, ContainerLocator, "container-ARTIG___ITEM_EXITS___", "#ARTIG___ITEM_EXITS___");

	/// <summary>
	/// Image
	/// </summary>
	public BaseInputControl ItemImage => new BaseInputControl(driver, ContainerLocator, "container-ARTIG___ITEM_IMAGE___", "#ARTIG___ITEM_IMAGE___");

	/// <summary>
	/// Item
	/// </summary>
	public CollapsibleZoneControl PseudNovogr07 => new CollapsibleZoneControl(driver, ContainerLocator, "#ARTIG___PSEUDNOVOGR07-container");

	/// <summary>
	/// Sequential Movements
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#ARTIG___PSEUDNOVOGR03-container");

	/// <summary>
	/// Movements
	/// </summary>
	public ListControl PseudContacor => new ListControl(driver, ContainerLocator, "#ARTIG___PSEUDCONTACOR");

	/// <summary>
	/// Movements by type
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#ARTIG___PSEUDNOVOGR04-container");

	/// <summary>
	/// Entries
	/// </summary>
	public ListControl PseudLentrada => new ListControl(driver, ContainerLocator, "#ARTIG___PSEUDLENTRADA");

	/// <summary>
	/// Output:
	/// </summary>
	public ListControl PseudLsaidas => new ListControl(driver, ContainerLocator, "#ARTIG___PSEUDLSAIDAS_");

	/// <summary>
	/// ACCORDION
	/// </summary>
	public IWebElement PseudNovogr05 => throw new NotImplementedException();

	/// <summary>
	/// Categorization
	/// </summary>
	public IWebElement PseudCategori => throw new NotImplementedException();

	/// <summary>
	/// Chosen Categories
	/// </summary>
	public IWebElement PseudEsccateg => throw new NotImplementedException();

	/// <summary>
	/// Filtered Checklist
	/// </summary>
	public IWebElement PseudCategor => throw new NotImplementedException();

	/// <summary>
	/// Categorization
	/// </summary>
	public BaseInputControl ItemCategory => new BaseInputControl(driver, ContainerLocator, "container-ARTIG___ITEM_CATEGORY", "#ARTIG___ITEM_CATEGORY");

	/// <summary>
	/// Categorization
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, ContainerLocator, "#ARTIG___PSEUDNOVOGR06-container");

	/// <summary>
	/// Existence
	/// </summary>
	public BaseInputControl ItemExistenc => new BaseInputControl(driver, ContainerLocator, "container-ARTIG___ITEM_EXISTENC", "#ARTIG___ITEM_EXISTENC");

	/// <summary>
	/// Availability
	/// </summary>
	public BaseInputControl ItemDisponib => new BaseInputControl(driver, ContainerLocator, "container-ARTIG___ITEM_DISPONIB", "#ARTIG___ITEM_DISPONIB");

	/// <summary>
	/// Image
	/// </summary>
	public CollapsibleZoneControl PseudNovogr08 => new CollapsibleZoneControl(driver, ContainerLocator, "#ARTIG___PSEUDNOVOGR08-container");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl ItemDate => new DateInputControl(driver, ContainerLocator, "#ARTIG___ITEM_DATE____");

	public ArtigForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ARTIG", containerLocator: containerLocator) { }
}
