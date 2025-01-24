using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class IdiomForm : Form
{
	/// <summary>
	/// Language
	/// </summary>
	public BaseInputControl LanguLangua => new BaseInputControl(driver, ContainerLocator, "#IDIOM___LANGULANGUA__");

	/// <summary>
	/// Acronym
	/// </summary>
	public BaseInputControl LanguAcron => new BaseInputControl(driver, ContainerLocator, "#IDIOM___LANGUACRON___");

	public IdiomForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "IDIOM", containerLocator: containerLocator) { }
}
