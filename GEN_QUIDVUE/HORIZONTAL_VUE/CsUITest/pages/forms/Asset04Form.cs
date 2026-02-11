using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Asset04Form : Subform
{
	/// <summary>
	/// Parameters
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#ASSET04_PSEUDNOVOGR01-container");

	/// <summary>
	/// Parameters load
	/// </summary>
	public ButtonControl PseudParamloa => new ButtonControl(driver, ContainerLocator, "#ASSET04_PSEUDPARAMLOA");

	/// <summary>
	/// Manuals load
	/// </summary>
	public ButtonControl PseudManuals => new ButtonControl(driver, ContainerLocator, "#ASSET04_PSEUDMANUALS_");

	/// <summary>
	/// Parameters
	/// </summary>
	public ListControl PseudParamete => new ListControl(driver, ContainerLocator, "#ASSET04_PSEUDPARAMETE");

	public Asset04Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ASSET04", "ASSET", containerLocator: containerLocator) { }
}
