using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RordiForm : Form
{
	/// <summary>
	/// Order
	/// </summary>
	public BaseInputControl RordiOrder => new BaseInputControl(driver, ContainerLocator, "container-RORDI___RORDIORDER___", "#RORDI___RORDIORDER___");

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl RordiTitle => new BaseInputControl(driver, ContainerLocator, "container-RORDI___RORDITITLE___", "#RORDI___RORDITITLE___");

	public RordiForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "RORDI", containerLocator: containerLocator) { }
}
