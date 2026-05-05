using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Equip04Form : Subform
{
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP04_PSEUDNOVOGR01-container");

	/// <summary>
	/// Parameters load
	/// </summary>
	public ButtonControl PseudParamloa => new ButtonControl(driver, ContainerLocator, "#EQUIP04_PSEUDPARAMLOA");

	/// <summary>
	/// Manuals load
	/// </summary>
	public ButtonControl PseudManuals => new ButtonControl(driver, ContainerLocator, "#EQUIP04_PSEUDMANUALS_");

	/// <summary>
	/// Parameters
	/// </summary>
	public ListControl PseudParamete => new ListControl(driver, ContainerLocator, "#EQUIP04_PSEUDPARAMETE");

	public Equip04Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "EQUIP04", "EQUIPM", containerLocator: containerLocator) { }
}
