using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Equip04Form : Subform
{
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP04_PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Parameters load
	/// </summary>
	public ButtonControl PseudParamloa => new ButtonControl(driver, ContainerLocator, "#EQUIP04_PSEUDPARAMLOA" + IdSuffix);

	/// <summary>
	/// Manuals load
	/// </summary>
	public ButtonControl PseudManuals => new ButtonControl(driver, ContainerLocator, "#EQUIP04_PSEUDMANUALS_" + IdSuffix);

	/// <summary>
	/// Parameters
	/// </summary>
	public ListControl PseudParamete => new ListControl(driver, ContainerLocator, "#EQUIP04_PSEUDPARAMETE" + IdSuffix);

	public Equip04Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "EQUIP04", "EQUIPM", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
