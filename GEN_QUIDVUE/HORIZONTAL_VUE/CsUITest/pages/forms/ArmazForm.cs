using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArmazForm : Form
{
	/// <summary>
	/// Acronym
	/// </summary>
	public BaseInputControl WarehWarehcod => new BaseInputControl(driver, ContainerLocator, "#ARMAZ___WAREHWAREHCOD");

	/// <summary>
	/// Warehouse
	/// </summary>
	public BaseInputControl WarehWarehdes => new BaseInputControl(driver, ContainerLocator, "#ARMAZ___WAREHWAREHDES");

	/// <summary>
	/// Activity
	/// </summary>
	public EnumControl WarehActivity => new EnumControl(driver, ContainerLocator, "container-ARMAZ___WAREHACTIVITY");

	/// <summary>
	/// Show Record
	/// </summary>
	public CheckboxInputControl WarehShowreco => new CheckboxInputControl(driver, ContainerLocator, "#container-ARMAZ___WAREHSHOWRECO");

	/// <summary>
	/// Employee
	/// </summary>
	public ListControl PseudPessarma => new ListControl(driver, ContainerLocator, "#ARMAZ___PSEUDPESSARMA");

	/// <summary>
	/// Open form
	/// </summary>
	public ButtonControl PseudExposetb => new ButtonControl(driver, ContainerLocator, "#ARMAZ___PSEUDEXPOSETB");

	public ArmazForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ARMAZ", containerLocator: containerLocator) { }
}
