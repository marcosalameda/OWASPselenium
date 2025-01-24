using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PessohisForm : Form
{
	/// <summary>
	/// HIST_PATTERN_DESCRIPTION
	/// </summary>
	public IWebElement PseudField002 => throw new NotImplementedException();

	/// <summary>
	/// Official No.
	/// </summary>
	public BaseInputControl PessoIdfuncio => new BaseInputControl(driver, ContainerLocator, "#PESSOHISPESSOIDFUNCIO");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl PessoName => new BaseInputControl(driver, ContainerLocator, "#PESSOHISPESSONAME____");

	/// <summary>
	/// history
	/// </summary>
	public ListControl PseudField001 => new ListControl(driver, ContainerLocator, "#PESSOHISPSEUDFIELD001");

	public PessohisForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PESSOHIS", containerLocator: containerLocator) { }
}
