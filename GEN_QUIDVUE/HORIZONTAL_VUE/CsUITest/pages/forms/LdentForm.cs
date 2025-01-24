using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LdentForm : PopupForm
{
	/// <summary>
	/// 
	/// </summary>
	public LookupControl IndocDocumenr => new LookupControl(driver, ContainerLocator, "container-LDENT___INDOCDOCUMENR");
	public SeeMorePage IndocDocumenrSeeMorePage => new SeeMorePage(driver, "LDENT", "LDENT___INDOCDOCUMENR");

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-LDENT___WAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "LDENT", "LDENT___WAREHWAREHDES");

	/// <summary>
	/// Line
	/// </summary>
	public BaseInputControl LdentLine => new BaseInputControl(driver, ContainerLocator, "#LDENT___LDENTLINE____");

	/// <summary>
	/// Items in use
	/// </summary>
	public CheckboxInputControl LdentEmuso => new CheckboxInputControl(driver, ContainerLocator, "#container-LDENT___LDENTEMUSO___");

	/// <summary>
	/// Item
	/// </summary>
	public LookupControl ItemItemdes => new LookupControl(driver, ContainerLocator, "container-LDENT___ITEM_ITEMDES_");
	public SeeMorePage ItemItemdesSeeMorePage => new SeeMorePage(driver, "LDENT", "LDENT___ITEM_ITEMDES_");

	/// <summary>
	/// Input Quantity
	/// </summary>
	public BaseInputControl LdentQtdentra => new BaseInputControl(driver, ContainerLocator, "#LDENT___LDENTQTDENTRA");

	/// <summary>
	/// 
	/// </summary>
	public IWebElement IndocCodwareh => throw new NotImplementedException();

	public LdentForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "LDENT") { }
}
