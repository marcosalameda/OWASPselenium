using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class UicomForm : Form
{
	/// <summary>
	/// Miniature
	/// </summary>
	public BaseInputControl UicomThumbnai => new BaseInputControl(driver, ContainerLocator, "container-UICOM___UICOMTHUMBNAI", "#UICOM___UICOMTHUMBNAI");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl UicomName => new BaseInputControl(driver, ContainerLocator, "container-UICOM___UICOMNAME____", "#UICOM___UICOMNAME____");

	/// <summary>
	/// Category
	/// </summary>
	public BaseInputControl UicomCategory => new BaseInputControl(driver, ContainerLocator, "container-UICOM___UICOMCATEGORY", "#UICOM___UICOMCATEGORY");

	/// <summary>
	/// Fixed menu name
	/// </summary>
	public BaseInputControl UicomMenuid => new BaseInputControl(driver, ContainerLocator, "container-UICOM___UICOMMENUID__", "#UICOM___UICOMMENUID__");

	public UicomForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "UICOM", containerLocator: containerLocator) { }
}
