using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Ware_wsForm : Form
{
	/// <summary>
	/// Warehouse
	/// </summary>
	public BaseInputControl WarehWarehdes => new BaseInputControl(driver, ContainerLocator, "container-WARE_WS_WAREHWAREHDES", "#WARE_WS_WAREHWAREHDES");

	/// <summary>
	/// Acronym
	/// </summary>
	public BaseInputControl WarehWarehcod => new BaseInputControl(driver, ContainerLocator, "container-WARE_WS_WAREHWAREHCOD", "#WARE_WS_WAREHWAREHCOD");

	/// <summary>
	/// Activity
	/// </summary>
	public EnumControl WarehActivity => new EnumControl(driver, ContainerLocator, "container-WARE_WS_WAREHACTIVITY");

	/// <summary>
	/// Show Record
	/// </summary>
	public CheckboxInputControl WarehShowreco => new CheckboxInputControl(driver, ContainerLocator, "#container-WARE_WS_WAREHSHOWRECO");

	/// <summary>
	/// Number of employees
	/// </summary>
	public BaseInputControl WarehNumemplo => new BaseInputControl(driver, ContainerLocator, "container-WARE_WS_WAREHNUMEMPLO", "#WARE_WS_WAREHNUMEMPLO");

	/// <summary>
	/// Articles
	/// </summary>
	public ListControl PseudXitem => new ListControl(driver, ContainerLocator, "#WARE_WS_PSEUDXITEM___");

	public Ware_wsForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "WARE_WS", containerLocator: containerLocator) { }
}
