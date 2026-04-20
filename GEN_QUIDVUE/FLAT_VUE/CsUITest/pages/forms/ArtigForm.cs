using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArtigForm : Form
{
	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl ItemItemcod => new BaseInputControl(driver, ContainerLocator, "container-ARTIG___ITEM_ITEMCOD_" + IdSuffix, "#ARTIG___ITEM_ITEMCOD_" + IdSuffix);

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-ARTIG___WAREHWAREHDES" + IdSuffix);
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "ARTIG", "ARTIG___WAREHWAREHDES" + IdSuffix);

	/// <summary>
	/// Code
	/// </summary>
	public IWebElement GitemItemgcod => throw new NotImplementedException();

	/// <summary>
	/// Designation:
	/// </summary>
	public LookupControl GitemItemdes => new LookupControl(driver, ContainerLocator, "container-ARTIG___GITEMITEMDES_" + IdSuffix);
	public SeeMorePage GitemItemdesSeeMorePage => new SeeMorePage(driver, "ARTIG", "ARTIG___GITEMITEMDES_" + IdSuffix);

	/// <summary>
	/// Warehouse
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#ARTIG___PSEUDNOVOGR02" + IdSuffix + "-container");

	/// <summary>
	/// Global Item
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#ARTIG___PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Item
	/// </summary>
	public BaseInputControl ItemItemdes => new BaseInputControl(driver, ContainerLocator, "container-ARTIG___ITEM_ITEMDES_" + IdSuffix, "#ARTIG___ITEM_ITEMDES_" + IdSuffix);

	/// <summary>
	/// In use
	/// </summary>
	public CheckboxInputControl ItemValid => new CheckboxInputControl(driver, ContainerLocator, "#container-ARTIG___ITEM_VALID___" + IdSuffix);

	/// <summary>
	/// Tipo
	/// </summary>
	public EnumControl ItemItemtype => new EnumControl(driver, ContainerLocator, "container-ARTIG___ITEM_ITEMTYPE" + IdSuffix);

	/// <summary>
	/// Entries:
	/// </summary>
	public BaseInputControl ItemEntries => new BaseInputControl(driver, ContainerLocator, "container-ARTIG___ITEM_ENTRIES_" + IdSuffix, "#ARTIG___ITEM_ENTRIES_" + IdSuffix);

	/// <summary>
	/// Output:
	/// </summary>
	public BaseInputControl ItemExits => new BaseInputControl(driver, ContainerLocator, "container-ARTIG___ITEM_EXITS___" + IdSuffix, "#ARTIG___ITEM_EXITS___" + IdSuffix);

	/// <summary>
	/// Image
	/// </summary>
	public BaseInputControl ItemImage => new BaseInputControl(driver, ContainerLocator, "container-ARTIG___ITEM_IMAGE___" + IdSuffix, "#ARTIG___ITEM_IMAGE___" + IdSuffix);

	/// <summary>
	/// Item
	/// </summary>
	public CollapsibleZoneControl PseudNovogr07 => new CollapsibleZoneControl(driver, ContainerLocator, "#ARTIG___PSEUDNOVOGR07" + IdSuffix + "-container");

	/// <summary>
	/// Sequential Movements
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#ARTIG___PSEUDNOVOGR03" + IdSuffix + "-container");

	/// <summary>
	/// Movements
	/// </summary>
	public ListControl PseudContacor => new ListControl(driver, ContainerLocator, "#ARTIG___PSEUDCONTACOR" + IdSuffix);

	/// <summary>
	/// Movements by type
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#ARTIG___PSEUDNOVOGR04" + IdSuffix + "-container");

	/// <summary>
	/// Entries
	/// </summary>
	public ListControl PseudLentrada => new ListControl(driver, ContainerLocator, "#ARTIG___PSEUDLENTRADA" + IdSuffix);

	/// <summary>
	/// Output:
	/// </summary>
	public ListControl PseudLsaidas => new ListControl(driver, ContainerLocator, "#ARTIG___PSEUDLSAIDAS_" + IdSuffix);

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
	public BaseInputControl ItemCategory => new BaseInputControl(driver, ContainerLocator, "container-ARTIG___ITEM_CATEGORY" + IdSuffix, "#ARTIG___ITEM_CATEGORY" + IdSuffix);

	/// <summary>
	/// Categorization
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, ContainerLocator, "#ARTIG___PSEUDNOVOGR06" + IdSuffix + "-container");

	/// <summary>
	/// Existence
	/// </summary>
	public BaseInputControl ItemExistenc => new BaseInputControl(driver, ContainerLocator, "container-ARTIG___ITEM_EXISTENC" + IdSuffix, "#ARTIG___ITEM_EXISTENC" + IdSuffix);

	/// <summary>
	/// Availability
	/// </summary>
	public BaseInputControl ItemDisponib => new BaseInputControl(driver, ContainerLocator, "container-ARTIG___ITEM_DISPONIB" + IdSuffix, "#ARTIG___ITEM_DISPONIB" + IdSuffix);

	/// <summary>
	/// Image
	/// </summary>
	public CollapsibleZoneControl PseudNovogr08 => new CollapsibleZoneControl(driver, ContainerLocator, "#ARTIG___PSEUDNOVOGR08" + IdSuffix + "-container");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl ItemDate => new DateInputControl(driver, ContainerLocator, "#ARTIG___ITEM_DATE____" + IdSuffix);

	public ArtigForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ARTIG", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
