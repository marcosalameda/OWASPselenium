using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArmazpopForm : PopupForm
{
	/// <summary>
	/// Identification
	/// </summary>
	public TabControl PseudArmaz01 => new TabControl(driver, ContainerLocator, "[data-testid='tab-container-ARMAZPOPPSEUDARMAZ01_']");

	/// <summary>
	/// Item
	/// </summary>
	public TabControl PseudArmaz02 => new TabControl(driver, ContainerLocator, "[data-testid='tab-container-ARMAZPOPPSEUDARMAZ02_']");

	/// <summary>
	/// Code:
	/// </summary>
	public BaseInputControl Armaz01WarehWarehcod => new BaseInputControl(driver, ContainerLocator, "container-ARMAZ01_WAREHWAREHCOD" + IdSuffix, "#ARMAZ01_WAREHWAREHCOD" + IdSuffix);

	/// <summary>
	/// Activity:
	/// </summary>
	public BaseInputControl Armaz01WarehActivity => new BaseInputControl(driver, ContainerLocator, "container-ARMAZ01_WAREHACTIVITY" + IdSuffix, "#ARMAZ01_WAREHACTIVITY" + IdSuffix);

	/// <summary>
	/// Warehouse:
	/// </summary>
	public BaseInputControl Armaz01WarehWarehdes => new BaseInputControl(driver, ContainerLocator, "container-ARMAZ01_WAREHWAREHDES" + IdSuffix, "#ARMAZ01_WAREHWAREHDES" + IdSuffix);

	/// <summary>
	/// Support
	/// </summary>
	public ArtigextForm  Armaz02PseudArtigapo => new ArtigextForm(driver, FORM_MODE.EDIT, By.Id("ARMAZ02_PSEUDARTIGAPO"), usePkInId: true);

	/// <summary>
	/// Catalog articles
	/// </summary>
	public ListControl Armaz02PseudArtigos => new ListControl(driver, ContainerLocator, "#ARMAZ02_PSEUDARTIGOS_" + IdSuffix);

	public ArmazpopForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ARMAZPOP", usePkInId: usePkInId) { }
}
