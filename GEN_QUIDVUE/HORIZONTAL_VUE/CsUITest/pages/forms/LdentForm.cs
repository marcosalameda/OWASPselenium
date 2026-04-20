using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LdentForm : PopupForm
{
	/// <summary>
	/// 
	/// </summary>
	public LookupControl IndocDocumenr => new LookupControl(driver, ContainerLocator, "container-LDENT___INDOCDOCUMENR" + IdSuffix);
	public SeeMorePage IndocDocumenrSeeMorePage => new SeeMorePage(driver, "LDENT", "LDENT___INDOCDOCUMENR" + IdSuffix);

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-LDENT___WAREHWAREHDES" + IdSuffix);
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "LDENT", "LDENT___WAREHWAREHDES" + IdSuffix);

	/// <summary>
	/// Line
	/// </summary>
	public BaseInputControl LdentLine => new BaseInputControl(driver, ContainerLocator, "container-LDENT___LDENTLINE____" + IdSuffix, "#LDENT___LDENTLINE____" + IdSuffix);

	/// <summary>
	/// Items in use
	/// </summary>
	public CheckboxInputControl LdentEmuso => new CheckboxInputControl(driver, ContainerLocator, "#container-LDENT___LDENTEMUSO___" + IdSuffix);

	/// <summary>
	/// Item
	/// </summary>
	public LookupControl ItemItemdes => new LookupControl(driver, ContainerLocator, "container-LDENT___ITEM_ITEMDES_" + IdSuffix);
	public SeeMorePage ItemItemdesSeeMorePage => new SeeMorePage(driver, "LDENT", "LDENT___ITEM_ITEMDES_" + IdSuffix);

	/// <summary>
	/// Input Quantity
	/// </summary>
	public BaseInputControl LdentQtdentra => new BaseInputControl(driver, ContainerLocator, "container-LDENT___LDENTQTDENTRA" + IdSuffix, "#LDENT___LDENTQTDENTRA" + IdSuffix);

	/// <summary>
	/// 
	/// </summary>
	public IWebElement IndocCodwareh => throw new NotImplementedException();

	public LdentForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "LDENT", usePkInId: usePkInId) { }
}
