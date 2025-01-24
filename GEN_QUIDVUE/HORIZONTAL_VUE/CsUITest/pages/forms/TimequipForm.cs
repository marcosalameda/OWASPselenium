using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TimequipForm : Form
{
	/// <summary>
	/// Equipment Repairs
	/// </summary>
	public ListControl PseudReparaco => new ListControl(driver, ContainerLocator, "#TIMEQUIPPSEUDREPARACO");

	/// <summary>
	/// Timeline Primary
	/// </summary>
	public IWebElement PseudPrimary => throw new NotImplementedException();

	/// <summary>
	/// Timeline Secundary
	/// </summary>
	public IWebElement PseudSecundar => throw new NotImplementedException();

	public TimequipForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "TIMEQUIP", containerLocator: containerLocator) { }
}
