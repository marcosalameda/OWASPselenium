using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Wid_pessForm : Form
{
	/// <summary>
	/// All people
	/// </summary>
	public ListControl PseudPesslist => new ListControl(driver, ContainerLocator, "#WID_PESSPSEUDPESSLIST");

	public Wid_pessForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "WID_PESS", containerLocator: containerLocator) { }
}
