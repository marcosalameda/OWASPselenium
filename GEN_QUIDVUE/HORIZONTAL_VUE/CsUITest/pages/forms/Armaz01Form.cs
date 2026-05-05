using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Armaz01Form : Subform
{
	/// <summary>
	/// Code:
	/// </summary>
	public BaseInputControl WarehWarehcod => new BaseInputControl(driver, ContainerLocator, "container-ARMAZ01_WAREHWAREHCOD", "#ARMAZ01_WAREHWAREHCOD");

	/// <summary>
	/// Activity:
	/// </summary>
	public BaseInputControl WarehActivity => new BaseInputControl(driver, ContainerLocator, "container-ARMAZ01_WAREHACTIVITY", "#ARMAZ01_WAREHACTIVITY");

	/// <summary>
	/// Warehouse:
	/// </summary>
	public BaseInputControl WarehWarehdes => new BaseInputControl(driver, ContainerLocator, "container-ARMAZ01_WAREHWAREHDES", "#ARMAZ01_WAREHWAREHDES");

	public Armaz01Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ARMAZ01", "ARMAZPOP", containerLocator: containerLocator) { }
}
