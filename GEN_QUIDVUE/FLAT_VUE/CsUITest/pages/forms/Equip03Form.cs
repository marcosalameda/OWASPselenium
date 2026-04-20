using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Equip03Form : Subform
{
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP03_PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Documents
	/// </summary>
	public ListControl PseudDocument => new ListControl(driver, ContainerLocator, "#EQUIP03_PSEUDDOCUMENT" + IdSuffix);

	public Equip03Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "EQUIP03", "EQUIPM", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
