using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArtigvalForm : PopupForm
{
	/// <summary>
	/// Image
	/// </summary>
	public BaseInputControl ItemImage => new BaseInputControl(driver, ContainerLocator, "container-ARTIGVALITEM_IMAGE___" + IdSuffix, "#ARTIGVALITEM_IMAGE___" + IdSuffix);

	/// <summary>
	/// Global Item
	/// </summary>
	public LookupControl GitemItemdes => new LookupControl(driver, ContainerLocator, "container-ARTIGVALGITEMITEMDES_" + IdSuffix);
	public SeeMorePage GitemItemdesSeeMorePage => new SeeMorePage(driver, "ARTIGVAL", "ARTIGVALGITEMITEMDES_" + IdSuffix);

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-ARTIGVALWAREHWAREHDES" + IdSuffix);
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "ARTIGVAL", "ARTIGVALWAREHWAREHDES" + IdSuffix);

	/// <summary>
	/// Tipo
	/// </summary>
	public EnumControl ItemItemtype => new EnumControl(driver, ContainerLocator, "container-ARTIGVALITEM_ITEMTYPE" + IdSuffix);

	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl ItemItemcod => new BaseInputControl(driver, ContainerLocator, "container-ARTIGVALITEM_ITEMCOD_" + IdSuffix, "#ARTIGVALITEM_ITEMCOD_" + IdSuffix);

	/// <summary>
	/// Item
	/// </summary>
	public BaseInputControl ItemItemdes => new BaseInputControl(driver, ContainerLocator, "container-ARTIGVALITEM_ITEMDES_" + IdSuffix, "#ARTIGVALITEM_ITEMDES_" + IdSuffix);

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl ItemDate => new DateInputControl(driver, ContainerLocator, "#ARTIGVALITEM_DATE____" + IdSuffix);

	/// <summary>
	/// Entries
	/// </summary>
	public BaseInputControl ItemEntries => new BaseInputControl(driver, ContainerLocator, "container-ARTIGVALITEM_ENTRIES_" + IdSuffix, "#ARTIGVALITEM_ENTRIES_" + IdSuffix);

	/// <summary>
	/// Output:
	/// </summary>
	public BaseInputControl ItemExits => new BaseInputControl(driver, ContainerLocator, "container-ARTIGVALITEM_EXITS___" + IdSuffix, "#ARTIGVALITEM_EXITS___" + IdSuffix);

	/// <summary>
	/// Existence
	/// </summary>
	public BaseInputControl ItemExistenc => new BaseInputControl(driver, ContainerLocator, "container-ARTIGVALITEM_EXISTENC" + IdSuffix, "#ARTIGVALITEM_EXISTENC" + IdSuffix);

	/// <summary>
	/// Categorization
	/// </summary>
	public BaseInputControl ItemCategory => new BaseInputControl(driver, ContainerLocator, "container-ARTIGVALITEM_CATEGORY" + IdSuffix, "#ARTIGVALITEM_CATEGORY" + IdSuffix);

	/// <summary>
	/// Availability
	/// </summary>
	public BaseInputControl ItemDisponib => new BaseInputControl(driver, ContainerLocator, "container-ARTIGVALITEM_DISPONIB" + IdSuffix, "#ARTIGVALITEM_DISPONIB" + IdSuffix);

	public ArtigvalForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ARTIGVAL", usePkInId: usePkInId) { }
}
