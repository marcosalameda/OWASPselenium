using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Equip02Form : Subform
{
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP02_PSEUDNOVOGR01-container");

	/// <summary>
	/// Attachments
	/// </summary>
	public ListControl PseudAttachme => new ListControl(driver, ContainerLocator, "#EQUIP02_PSEUDATTACHME");

	public Equip02Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "EQUIP02", "EQUIPM", containerLocator: containerLocator) { }
}
