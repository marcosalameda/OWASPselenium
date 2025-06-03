using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PlistForm : Form
{
	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-PLIST___WAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "PLIST", "PLIST___WAREHWAREHDES");

	/// <summary>
	/// Article
	/// </summary>
	public BaseInputControl ItemItemdes => new BaseInputControl(driver, ContainerLocator, "container-PLIST___ITEM_ITEMDES_", "#PLIST___ITEM_ITEMDES_");

	/// <summary>
	/// Property List
	/// </summary>
	public PlistPseudPlistPropertyList PseudPlist => new PlistPseudPlistPropertyList(driver, ContainerLocator, "container-PLIST___PSEUDPLIST___");

	public PlistForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PLIST", containerLocator: containerLocator) { }
}
