using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FullcaleForm : Form
{
	/// <summary>
	/// Visits
	/// </summary>
	public ListControl PseudFullcale => new ListControl(driver, ContainerLocator, "#FULLCALEPSEUDFULLCALE");

	public FullcaleForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FULLCALE", containerLocator: containerLocator) { }
}
