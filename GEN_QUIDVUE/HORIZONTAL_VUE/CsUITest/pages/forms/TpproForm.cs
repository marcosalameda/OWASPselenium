using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TpproForm : Form
{
	/// <summary>
	/// Property type
	/// </summary>
	public BaseInputControl TpproTppropri => new BaseInputControl(driver, ContainerLocator, "#TPPRO___TPPROTPPROPRI");

	public TpproForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "TPPRO", containerLocator: containerLocator) { }
}
