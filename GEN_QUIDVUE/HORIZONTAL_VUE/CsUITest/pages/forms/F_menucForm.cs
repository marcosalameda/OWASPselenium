using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_menucForm : Form
{
	/// <summary>
	/// Menu Item Class
	/// </summary>
	public BaseInputControl MenucMenucl => new BaseInputControl(driver, ContainerLocator, "container-F_MENUC_MENUCMENUCL__", "#F_MENUC_MENUCMENUCL__");

	/// <summary>
	/// Order
	/// </summary>
	public BaseInputControl MenucOrder => new BaseInputControl(driver, ContainerLocator, "container-F_MENUC_MENUCORDER___", "#F_MENUC_MENUCORDER___");

	/// <summary>
	/// Class Description
	/// </summary>
	public BaseInputControl MenucCldesc => new BaseInputControl(driver, ContainerLocator, "container-F_MENUC_MENUCCLDESC__", "#F_MENUC_MENUCCLDESC__");

	/// <summary>
	/// Class Icon
	/// </summary>
	public BaseInputControl MenucIcon => new BaseInputControl(driver, ContainerLocator, "container-F_MENUC_MENUCICON____", "#F_MENUC_MENUCICON____");

	public F_menucForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_MENUC", containerLocator: containerLocator) { }
}
