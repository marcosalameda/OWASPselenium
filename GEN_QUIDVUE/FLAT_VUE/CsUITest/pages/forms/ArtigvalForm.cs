using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArtigvalForm : PopupForm
{
	/// <summary>
	/// Image
	/// </summary>
	public BaseInputControl ItemImage => new BaseInputControl(driver, ContainerLocator, "#ARTIGVALITEM_IMAGE___");

	/// <summary>
	/// Global Item
	/// </summary>
	public LookupControl GitemItemdes => new LookupControl(driver, ContainerLocator, "container-ARTIGVALGITEMITEMDES_");
	public SeeMorePage GitemItemdesSeeMorePage => new SeeMorePage(driver, "ARTIGVAL", "ARTIGVALGITEMITEMDES_");

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-ARTIGVALWAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "ARTIGVAL", "ARTIGVALWAREHWAREHDES");

	/// <summary>
	/// Tipo
	/// </summary>
	public EnumControl ItemItemtype => new EnumControl(driver, ContainerLocator, "container-ARTIGVALITEM_ITEMTYPE");

	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl ItemItemcod => new BaseInputControl(driver, ContainerLocator, "#ARTIGVALITEM_ITEMCOD_");

	/// <summary>
	/// Item
	/// </summary>
	public BaseInputControl ItemItemdes => new BaseInputControl(driver, ContainerLocator, "#ARTIGVALITEM_ITEMDES_");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl ItemDate => new DateInputControl(driver, ContainerLocator, "#ARTIGVALITEM_DATE____");

	/// <summary>
	/// Entries
	/// </summary>
	public BaseInputControl ItemEntries => new BaseInputControl(driver, ContainerLocator, "#ARTIGVALITEM_ENTRIES_");

	/// <summary>
	/// Output:
	/// </summary>
	public BaseInputControl ItemExits => new BaseInputControl(driver, ContainerLocator, "#ARTIGVALITEM_EXITS___");

	/// <summary>
	/// Existence
	/// </summary>
	public BaseInputControl ItemExistenc => new BaseInputControl(driver, ContainerLocator, "#ARTIGVALITEM_EXISTENC");

	/// <summary>
	/// Categorization
	/// </summary>
	public BaseInputControl ItemCategory => new BaseInputControl(driver, ContainerLocator, "#ARTIGVALITEM_CATEGORY");

	/// <summary>
	/// Availability
	/// </summary>
	public BaseInputControl ItemDisponib => new BaseInputControl(driver, ContainerLocator, "#ARTIGVALITEM_DISPONIB");

	public ArtigvalForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ARTIGVAL") { }
}
