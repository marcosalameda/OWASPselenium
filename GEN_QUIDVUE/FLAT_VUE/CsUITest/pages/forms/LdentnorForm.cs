using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LdentnorForm : Form
{
	/// <summary>
	/// 
	/// </summary>
	public LookupControl IndocDocumenr => new LookupControl(driver, ContainerLocator, "container-LDENTNORINDOCDOCUMENR" + IdSuffix);
	public SeeMorePage IndocDocumenrSeeMorePage => new SeeMorePage(driver, "LDENTNOR", "LDENTNORINDOCDOCUMENR" + IdSuffix);

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-LDENTNORWAREHWAREHDES" + IdSuffix);
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "LDENTNOR", "LDENTNORWAREHWAREHDES" + IdSuffix);

	/// <summary>
	/// Line
	/// </summary>
	public BaseInputControl LdentLine => new BaseInputControl(driver, ContainerLocator, "container-LDENTNORLDENTLINE____" + IdSuffix, "#LDENTNORLDENTLINE____" + IdSuffix);

	/// <summary>
	/// Item
	/// </summary>
	public LookupControl ItemItemdes => new LookupControl(driver, ContainerLocator, "container-LDENTNORITEM_ITEMDES_" + IdSuffix);
	public SeeMorePage ItemItemdesSeeMorePage => new SeeMorePage(driver, "LDENTNOR", "LDENTNORITEM_ITEMDES_" + IdSuffix);

	/// <summary>
	/// Input Quantity
	/// </summary>
	public BaseInputControl LdentQtdentra => new BaseInputControl(driver, ContainerLocator, "container-LDENTNORLDENTQTDENTRA" + IdSuffix, "#LDENTNORLDENTQTDENTRA" + IdSuffix);

	/// <summary>
	/// 
	/// </summary>
	public IWebElement IndocCodwareh => throw new NotImplementedException();

	public LdentnorForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "LDENTNOR", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
