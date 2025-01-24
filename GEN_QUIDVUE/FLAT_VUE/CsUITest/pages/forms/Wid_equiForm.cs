using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Wid_equiForm : Form
{
	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudWidequi => new ListControl(driver, ContainerLocator, "#WID_EQUIPSEUDWIDEQUI_");

	public Wid_equiForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "WID_EQUI", containerLocator: containerLocator) { }
}
