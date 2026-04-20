using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class HomegForm : Form
{
	/// <summary>
	/// 
	/// </summary>
	public IWebElement GlobHome => throw new NotImplementedException();

	public HomegForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "HOMEG", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
