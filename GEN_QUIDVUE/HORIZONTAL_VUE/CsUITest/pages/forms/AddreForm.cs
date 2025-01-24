using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AddreForm : Form
{
	/// <summary>
	/// Address Use
	/// </summary>
	public EnumControl AddreAddruse => new EnumControl(driver, ContainerLocator, "container-ADDRE___ADDREADDRUSE_");

	/// <summary>
	/// Address Type
	/// </summary>
	public EnumControl AddreAddrtype => new EnumControl(driver, ContainerLocator, "container-ADDRE___ADDREADDRTYPE");

	/// <summary>
	/// Entire address
	/// </summary>
	public BaseInputControl AddreAddrtext => new BaseInputControl(driver, ContainerLocator, "#ADDRE___ADDREADDRTEXT");

	/// <summary>
	/// Address City
	/// </summary>
	public BaseInputControl AddreAddrcity => new BaseInputControl(driver, ContainerLocator, "#ADDRE___ADDREADDRCITY");

	public AddreForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ADDRE", containerLocator: containerLocator) { }
}
