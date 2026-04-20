using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class UicomForm : Form
{
	/// <summary>
	/// Miniature
	/// </summary>
	public BaseInputControl UicomThumbnai => new BaseInputControl(driver, ContainerLocator, "container-UICOM___UICOMTHUMBNAI" + IdSuffix, "#UICOM___UICOMTHUMBNAI" + IdSuffix);

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl UicomName => new BaseInputControl(driver, ContainerLocator, "container-UICOM___UICOMNAME____" + IdSuffix, "#UICOM___UICOMNAME____" + IdSuffix);

	/// <summary>
	/// Category
	/// </summary>
	public BaseInputControl UicomCategory => new BaseInputControl(driver, ContainerLocator, "container-UICOM___UICOMCATEGORY" + IdSuffix, "#UICOM___UICOMCATEGORY" + IdSuffix);

	/// <summary>
	/// Fixed menu name
	/// </summary>
	public BaseInputControl UicomMenuid => new BaseInputControl(driver, ContainerLocator, "container-UICOM___UICOMMENUID__" + IdSuffix, "#UICOM___UICOMMENUID__" + IdSuffix);

	public UicomForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "UICOM", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
