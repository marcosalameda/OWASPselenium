using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Rogl1Form : Form
{
	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl Rogl1Title => new BaseInputControl(driver, ContainerLocator, "container-ROGL1___ROGL1TITLE___", "#ROGL1___ROGL1TITLE___");

	public Rogl1Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ROGL1", containerLocator: containerLocator) { }
}
