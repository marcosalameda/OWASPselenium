using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class GlobForm : Form
{
	/// <summary>
	/// Home text
	/// </summary>
	public IWebElement GlobHome => throw new NotImplementedException();

	/// <summary>
	/// External API address
	/// </summary>
	public BaseInputControl GlobApiurl => new BaseInputControl(driver, ContainerLocator, "#GLOB____GLOB_APIURL__");

	/// <summary>
	/// Legend
	/// </summary>
	public BaseInputControl GlobLegend => new BaseInputControl(driver, ContainerLocator, "#GLOB____GLOB_LEGEND__");

	public GlobForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "GLOB", containerLocator: containerLocator) { }
}
