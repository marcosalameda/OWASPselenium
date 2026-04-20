using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArmazForm : Form
{
	/// <summary>
	/// Acronym
	/// </summary>
	public BaseInputControl WarehWarehcod => new BaseInputControl(driver, ContainerLocator, "container-ARMAZ___WAREHWAREHCOD" + IdSuffix, "#ARMAZ___WAREHWAREHCOD" + IdSuffix);

	/// <summary>
	/// Warehouse
	/// </summary>
	public BaseInputControl WarehWarehdes => new BaseInputControl(driver, ContainerLocator, "container-ARMAZ___WAREHWAREHDES" + IdSuffix, "#ARMAZ___WAREHWAREHDES" + IdSuffix);

	/// <summary>
	/// Activity
	/// </summary>
	public EnumControl WarehActivity => new EnumControl(driver, ContainerLocator, "container-ARMAZ___WAREHACTIVITY" + IdSuffix);

	/// <summary>
	/// Show Record
	/// </summary>
	public CheckboxInputControl WarehShowreco => new CheckboxInputControl(driver, ContainerLocator, "#container-ARMAZ___WAREHSHOWRECO" + IdSuffix);

	/// <summary>
	/// Employee
	/// </summary>
	public ListControl PseudPessarma => new ListControl(driver, ContainerLocator, "#ARMAZ___PSEUDPESSARMA" + IdSuffix);

	/// <summary>
	/// Open form
	/// </summary>
	public ButtonControl PseudExposetb => new ButtonControl(driver, ContainerLocator, "#ARMAZ___PSEUDEXPOSETB" + IdSuffix);

	public ArmazForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ARMAZ", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
