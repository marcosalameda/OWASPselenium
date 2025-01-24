using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AeroForm : Form
{
	/// <summary>
	/// Airline
	/// </summary>
	public BaseInputControl AeroName => new BaseInputControl(driver, ContainerLocator, "#AERO____AERO_NAME____");

	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl AeroCodcmaer => new BaseInputControl(driver, ContainerLocator, "#AERO____AERO_CODCMAER");

	public AeroForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "AERO", containerLocator: containerLocator) { }
}
