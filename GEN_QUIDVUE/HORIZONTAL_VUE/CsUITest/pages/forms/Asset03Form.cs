using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Asset03Form : Subform
{
	/// <summary>
	/// Documents
	/// </summary>
	public ListControl PseudDocument => new ListControl(driver, ContainerLocator, "#ASSET03_PSEUDDOCUMENT");

	public Asset03Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ASSET03", "ASSET", containerLocator: containerLocator) { }
}
