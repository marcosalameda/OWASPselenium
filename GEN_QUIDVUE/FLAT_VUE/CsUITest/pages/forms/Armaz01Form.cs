using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Armaz01Form : Subform
{
	/// <summary>
	/// Code:
	/// </summary>
	public BaseInputControl WarehWarehcod => new BaseInputControl(driver, ContainerLocator, "container-ARMAZ01_WAREHWAREHCOD" + IdSuffix, "#ARMAZ01_WAREHWAREHCOD" + IdSuffix);

	/// <summary>
	/// Activity:
	/// </summary>
	public BaseInputControl WarehActivity => new BaseInputControl(driver, ContainerLocator, "container-ARMAZ01_WAREHACTIVITY" + IdSuffix, "#ARMAZ01_WAREHACTIVITY" + IdSuffix);

	/// <summary>
	/// Warehouse:
	/// </summary>
	public BaseInputControl WarehWarehdes => new BaseInputControl(driver, ContainerLocator, "container-ARMAZ01_WAREHWAREHDES" + IdSuffix, "#ARMAZ01_WAREHWAREHDES" + IdSuffix);

	public Armaz01Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ARMAZ01", "ARMAZPOP", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
