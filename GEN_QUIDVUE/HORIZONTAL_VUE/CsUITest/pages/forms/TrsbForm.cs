using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TrsbForm : Form
{
	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl TrsbName => new BaseInputControl(driver, ContainerLocator, "#TRSB____TRSB_NAME____");

	public TrsbForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "TRSB", containerLocator: containerLocator) { }
}
