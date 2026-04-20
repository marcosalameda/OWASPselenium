using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class VendawpForm : Form
{
	/// <summary>
	/// Phase Area
	/// </summary>
	public IWebElement PseudFases => throw new NotImplementedException();

	public VendawpForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "VENDAWP", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
