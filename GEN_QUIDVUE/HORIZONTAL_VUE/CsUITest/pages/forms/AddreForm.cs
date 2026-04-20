using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AddreForm : Form
{
	/// <summary>
	/// Address Use
	/// </summary>
	public EnumControl AddreAddruse => new EnumControl(driver, ContainerLocator, "container-ADDRE___ADDREADDRUSE_" + IdSuffix);

	/// <summary>
	/// Address Type
	/// </summary>
	public EnumControl AddreAddrtype => new EnumControl(driver, ContainerLocator, "container-ADDRE___ADDREADDRTYPE" + IdSuffix);

	/// <summary>
	/// Entire address
	/// </summary>
	public BaseInputControl AddreAddrtext => new BaseInputControl(driver, ContainerLocator, "container-ADDRE___ADDREADDRTEXT" + IdSuffix, "#ADDRE___ADDREADDRTEXT" + IdSuffix);

	/// <summary>
	/// Address City
	/// </summary>
	public BaseInputControl AddreAddrcity => new BaseInputControl(driver, ContainerLocator, "container-ADDRE___ADDREADDRCITY" + IdSuffix, "#ADDRE___ADDREADDRCITY" + IdSuffix);

	public AddreForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ADDRE", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
