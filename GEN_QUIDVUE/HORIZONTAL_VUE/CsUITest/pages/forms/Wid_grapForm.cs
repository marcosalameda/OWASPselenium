using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Wid_grapForm : Form
{
	/// <summary>
	/// Company's people count
	/// </summary>
	public ListControl PseudField001 => new ListControl(driver, ContainerLocator, "#WID_GRAPPSEUDFIELD001");

	public Wid_grapForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "WID_GRAP", containerLocator: containerLocator) { }
}
