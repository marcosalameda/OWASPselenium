using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Asset02Form : Subform
{
	/// <summary>
	/// Attachments
	/// </summary>
	public ListControl PseudAttachme => new ListControl(driver, ContainerLocator, "#ASSET02_PSEUDATTACHME");

	public Asset02Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ASSET02", "ASSET", containerLocator: containerLocator) { }
}
