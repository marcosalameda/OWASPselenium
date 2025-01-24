using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LnhdfForm : PopupForm
{
	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl LnhdfName => new BaseInputControl(driver, ContainerLocator, "#LNHDF___LNHDFNAME____");

	public LnhdfForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "LNHDF") { }
}
