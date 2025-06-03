using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ItemForm : Form
{
	/// <summary>
	/// Global article
	/// </summary>
	public LookupControl GitemItemdes => new LookupControl(driver, ContainerLocator, "container-ITEM____GITEMITEMDES_");
	public SeeMorePage GitemItemdesSeeMorePage => new SeeMorePage(driver, "ITEM", "ITEM____GITEMITEMDES_");

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-ITEM____WAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "ITEM", "ITEM____WAREHWAREHDES");

	/// <summary>
	/// Type
	/// </summary>
	public EnumControl ItemItemtype => new EnumControl(driver, ContainerLocator, "container-ITEM____ITEM_ITEMTYPE");

	/// <summary>
	/// Article
	/// </summary>
	public BaseInputControl ItemItemdes => new BaseInputControl(driver, ContainerLocator, "container-ITEM____ITEM_ITEMDES_", "#ITEM____ITEM_ITEMDES_");

	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl ItemItemcod => new BaseInputControl(driver, ContainerLocator, "container-ITEM____ITEM_ITEMCOD_", "#ITEM____ITEM_ITEMCOD_");

	/// <summary>
	/// Entries
	/// </summary>
	public BaseInputControl ItemEntries => new BaseInputControl(driver, ContainerLocator, "container-ITEM____ITEM_ENTRIES_", "#ITEM____ITEM_ENTRIES_");

	/// <summary>
	/// Outputs
	/// </summary>
	public BaseInputControl ItemExits => new BaseInputControl(driver, ContainerLocator, "container-ITEM____ITEM_EXITS___", "#ITEM____ITEM_EXITS___");

	/// <summary>
	/// Stocks
	/// </summary>
	public BaseInputControl ItemExistenc => new BaseInputControl(driver, ContainerLocator, "container-ITEM____ITEM_EXISTENC", "#ITEM____ITEM_EXISTENC");

	/// <summary>
	/// Image
	/// </summary>
	public BaseInputControl ItemImage => new BaseInputControl(driver, ContainerLocator, "container-ITEM____ITEM_IMAGE___", "#ITEM____ITEM_IMAGE___");

	/// <summary>
	/// Categorization
	/// </summary>
	public BaseInputControl ItemCategory => new BaseInputControl(driver, ContainerLocator, "container-ITEM____ITEM_CATEGORY", "#ITEM____ITEM_CATEGORY");

	/// <summary>
	/// In use
	/// </summary>
	public CheckboxInputControl ItemValid => new CheckboxInputControl(driver, ContainerLocator, "#container-ITEM____ITEM_VALID___");

	/// <summary>
	/// Availability
	/// </summary>
	public BaseInputControl ItemDisponib => new BaseInputControl(driver, ContainerLocator, "container-ITEM____ITEM_DISPONIB", "#ITEM____ITEM_DISPONIB");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl ItemDate => new DateInputControl(driver, ContainerLocator, "#ITEM____ITEM_DATE____");

	/// <summary>
	/// Specifications
	/// </summary>
	public DocumentControl ItemTechspec => new DocumentControl(driver, ContainerLocator, "ITEM____ITEM_TECHSPEC");

	public ItemForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ITEM", containerLocator: containerLocator) { }
}
