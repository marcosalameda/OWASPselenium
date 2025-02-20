using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArmazpopForm : PopupForm
{
	/// <summary>
	/// Identification
	/// </summary>
	public TabControl PseudArmaz01 => new TabControl(driver, ContainerLocator, "#tab-container-ARMAZPOPPSEUDARMAZ01_");

	/// <summary>
	/// Item
	/// </summary>
	public TabControl PseudArmaz02 => new TabControl(driver, ContainerLocator, "#tab-container-ARMAZPOPPSEUDARMAZ02_");

	/// <summary>
	/// Code:
	/// </summary>
	public BaseInputControl Armaz01WarehWarehcod => new BaseInputControl(driver, ContainerLocator, "container-ARMAZ01_WAREHWAREHCOD", "#ARMAZ01_WAREHWAREHCOD");

	/// <summary>
	/// Activity:
	/// </summary>
	public BaseInputControl Armaz01WarehActivity => new BaseInputControl(driver, ContainerLocator, "container-ARMAZ01_WAREHACTIVITY", "#ARMAZ01_WAREHACTIVITY");

	/// <summary>
	/// Warehouse:
	/// </summary>
	public BaseInputControl Armaz01WarehWarehdes => new BaseInputControl(driver, ContainerLocator, "container-ARMAZ01_WAREHWAREHDES", "#ARMAZ01_WAREHWAREHDES");

	/// <summary>
	/// Support
	/// </summary>
	public ArtigextForm  Armaz02PseudArtigapo => new ArtigextForm(driver, FORM_MODE.EDIT, By.Id("ARMAZ02_PSEUDARTIGAPO"));

	/// <summary>
	/// Catalog articles
	/// </summary>
	public ListControl Armaz02PseudArtigos => new ListControl(driver, ContainerLocator, "#ARMAZ02_PSEUDARTIGOS_");

	public ArmazpopForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ARMAZPOP") { }
}
