using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Equip_itemForm : Form
{
	/// <summary>
	/// Global article
	/// </summary>
	public LookupControl GitemItemdes => new LookupControl(driver, ContainerLocator, "container-EQUIP_ITEM__GITEM__ITEMDES");
	public SeeMorePage GitemItemdesSeeMorePage => new SeeMorePage(driver, "EQUIP_ITEM", "EQUIP_ITEM__GITEM__ITEMDES");

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-EQUIP_ITEM__WAREH__WAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "EQUIP_ITEM", "EQUIP_ITEM__WAREH__WAREHDES");

	/// <summary>
	/// Type
	/// </summary>
	public EnumControl ItemItemtype => new EnumControl(driver, ContainerLocator, "container-EQUIP_ITEM__ITEM__ITEMTYPE");

	/// <summary>
	/// Article
	/// </summary>
	public BaseInputControl ItemItemdes => new BaseInputControl(driver, ContainerLocator, "container-EQUIP_ITEM__ITEM__ITEMDES", "#EQUIP_ITEM__ITEM__ITEMDES");

	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl ItemItemcod => new BaseInputControl(driver, ContainerLocator, "container-EQUIP_ITEM__ITEM__ITEMCOD", "#EQUIP_ITEM__ITEM__ITEMCOD");

	/// <summary>
	/// Entries
	/// </summary>
	public BaseInputControl ItemEntries => new BaseInputControl(driver, ContainerLocator, "container-EQUIP_ITEM__ITEM__ENTRIES", "#EQUIP_ITEM__ITEM__ENTRIES");

	/// <summary>
	/// Outputs
	/// </summary>
	public BaseInputControl ItemExits => new BaseInputControl(driver, ContainerLocator, "container-EQUIP_ITEM__ITEM__EXITS", "#EQUIP_ITEM__ITEM__EXITS");

	/// <summary>
	/// Stocks
	/// </summary>
	public BaseInputControl ItemExistenc => new BaseInputControl(driver, ContainerLocator, "container-EQUIP_ITEM__ITEM__EXISTENC", "#EQUIP_ITEM__ITEM__EXISTENC");

	/// <summary>
	/// Image
	/// </summary>
	public BaseInputControl ItemImage => new BaseInputControl(driver, ContainerLocator, "container-EQUIP_ITEM__ITEM__IMAGE", "#EQUIP_ITEM__ITEM__IMAGE");

	/// <summary>
	/// Categorization
	/// </summary>
	public BaseInputControl ItemCategory => new BaseInputControl(driver, ContainerLocator, "container-EQUIP_ITEM__ITEM__CATEGORY", "#EQUIP_ITEM__ITEM__CATEGORY");

	/// <summary>
	/// In use
	/// </summary>
	public CheckboxInputControl ItemValid => new CheckboxInputControl(driver, ContainerLocator, "#container-EQUIP_ITEM__ITEM__VALID");

	/// <summary>
	/// Availability
	/// </summary>
	public BaseInputControl ItemDisponib => new BaseInputControl(driver, ContainerLocator, "container-EQUIP_ITEM__ITEM__DISPONIB", "#EQUIP_ITEM__ITEM__DISPONIB");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl ItemDate => new DateInputControl(driver, ContainerLocator, "#EQUIP_ITEM__ITEM__DATE");

	/// <summary>
	/// Specifications
	/// </summary>
	public DocumentControl ItemTechspec => new DocumentControl(driver, ContainerLocator, "EQUIP_ITEM__ITEM__TECHSPEC-container");

	/// <summary>
	/// Country
	/// </summary>
    public LookupControl CntryCountry_FG => new LookupControl(driver, ContainerLocator, "container-EQUIP_ITEM__CNTRY__COUNTRY_FG");

	/// <summary>
	/// Designation
	/// </summary>
    public LookupControl CmpnyDesignat_FG => new LookupControl(driver, ContainerLocator, "container-EQUIP_ITEM__CMPNY__DESIGNAT_FG");

	/// <summary>
	/// Name
	/// </summary>
    public LookupControl Pess1Name_FG => new LookupControl(driver, ContainerLocator, "container-EQUIP_ITEM__PESS1__NAME_FG");

	/// <summary>
	/// Equipment
	/// </summary>
	public ListControl PseudEquip_filtrado => new ListControl(driver, ContainerLocator, "#EQUIP_ITEM__PSEUD__EQUIP_FILTRADO");

	public Equip_itemForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "EQUIP_ITEM", containerLocator: containerLocator) { }
}
