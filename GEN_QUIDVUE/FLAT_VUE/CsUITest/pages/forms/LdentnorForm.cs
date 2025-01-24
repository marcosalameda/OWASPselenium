using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LdentnorForm : Form
{
	/// <summary>
	/// 
	/// </summary>
	public LookupControl IndocDocumenr => new LookupControl(driver, ContainerLocator, "container-LDENTNORINDOCDOCUMENR");
	public SeeMorePage IndocDocumenrSeeMorePage => new SeeMorePage(driver, "LDENTNOR", "LDENTNORINDOCDOCUMENR");

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-LDENTNORWAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "LDENTNOR", "LDENTNORWAREHWAREHDES");

	/// <summary>
	/// Line
	/// </summary>
	public BaseInputControl LdentLine => new BaseInputControl(driver, ContainerLocator, "#LDENTNORLDENTLINE____");

	/// <summary>
	/// Item
	/// </summary>
	public LookupControl ItemItemdes => new LookupControl(driver, ContainerLocator, "container-LDENTNORITEM_ITEMDES_");
	public SeeMorePage ItemItemdesSeeMorePage => new SeeMorePage(driver, "LDENTNOR", "LDENTNORITEM_ITEMDES_");

	/// <summary>
	/// Input Quantity
	/// </summary>
	public BaseInputControl LdentQtdentra => new BaseInputControl(driver, ContainerLocator, "#LDENTNORLDENTQTDENTRA");

	/// <summary>
	/// 
	/// </summary>
	public IWebElement IndocCodwareh => throw new NotImplementedException();

	public LdentnorForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "LDENTNOR", containerLocator: containerLocator) { }
}
