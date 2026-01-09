using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TabForm : Subform
{
	/// <summary>
	/// VARIANTS/OPTIONS
	/// </summary>
	public ListControl PseudVariants => new ListControl(driver, ContainerLocator, "#TAB_____PSEUDVARIANTS");

	public TabForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "TAB", "COMPTYPE", containerLocator: containerLocator) { }
}
