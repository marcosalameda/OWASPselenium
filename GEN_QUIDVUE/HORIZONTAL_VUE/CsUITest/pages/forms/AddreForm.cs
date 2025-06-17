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
	public BaseInputControl AddreAddrtext => new BaseInputControl(driver, ContainerLocator, "container-ADDRE___ADDREADDRTEXT", "#ADDRE___ADDREADDRTEXT");

	/// <summary>
	/// Address City
	/// </summary>
	public BaseInputControl AddreAddrcity => new BaseInputControl(driver, ContainerLocator, "container-ADDRE___ADDREADDRCITY", "#ADDRE___ADDREADDRCITY");

	/// <summary>
	/// Address District
	/// </summary>
	public BaseInputControl AddreAddrdist => new BaseInputControl(driver, ContainerLocator, "container-ADDRE___ADDREADDRDIST", "#ADDRE___ADDREADDRDIST");

	/// <summary>
	/// Address State
	/// </summary>
	public BaseInputControl AddreAddrstat => new BaseInputControl(driver, ContainerLocator, "container-ADDRE___ADDREADDRSTAT", "#ADDRE___ADDREADDRSTAT");

	/// <summary>
	/// Address Postal Code
	/// </summary>
	public BaseInputControl AddreAddrpcod => new BaseInputControl(driver, ContainerLocator, "container-ADDRE___ADDREADDRPCOD", "#ADDRE___ADDREADDRPCOD");

	/// <summary>
	/// Address Country
	/// </summary>
	public BaseInputControl AddreAddrcoun => new BaseInputControl(driver, ContainerLocator, "container-ADDRE___ADDREADDRCOUN", "#ADDRE___ADDREADDRCOUN");

	/// <summary>
	/// Period Start
	/// </summary>
	public DateInputControl AddrePeristar => new DateInputControl(driver, ContainerLocator, "#ADDRE___ADDREPERISTAR", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Period End
	/// </summary>
	public DateInputControl AddrePeriend => new DateInputControl(driver, ContainerLocator, "#ADDRE___ADDREPERIEND_", "dd/MM/yyyy HH:mm");

	public AddreForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ADDRE", containerLocator: containerLocator) { }
}
