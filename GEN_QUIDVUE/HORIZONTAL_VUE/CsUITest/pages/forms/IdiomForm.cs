using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class IdiomForm : Form
{
	/// <summary>
	/// Language
	/// </summary>
	public BaseInputControl LanguLangua => new BaseInputControl(driver, ContainerLocator, "container-IDIOM___LANGULANGUA__" + IdSuffix, "#IDIOM___LANGULANGUA__" + IdSuffix);

	/// <summary>
	/// Acronym
	/// </summary>
	public BaseInputControl LanguAcron => new BaseInputControl(driver, ContainerLocator, "container-IDIOM___LANGUACRON___" + IdSuffix, "#IDIOM___LANGUACRON___" + IdSuffix);

	public IdiomForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "IDIOM", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
