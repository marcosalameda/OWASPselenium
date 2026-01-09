using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CompbehForm : PopupForm
{
	/// <summary>
	/// Interaction
	/// </summary>
	public BaseInputControl CompbCompint => new BaseInputControl(driver, ContainerLocator, "container-COMPBEH_COMPBCOMPINT_", "#COMPBEH_COMPBCOMPINT_");

	/// <summary>
	/// Behavior
	/// </summary>
	public BaseInputControl CompbCmpbehav => new BaseInputControl(driver, ContainerLocator, "container-COMPBEH_COMPBCMPBEHAV", "#COMPBEH_COMPBCMPBEHAV");

	public CompbehForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "COMPBEH") { }
}
