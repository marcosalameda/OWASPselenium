using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Fami1Form : Form
{
	/// <summary>
	/// Equipment family
	/// </summary>
	public BaseInputControl Fami1Family => new BaseInputControl(driver, ContainerLocator, "#FAMI1___FAMI1FAMILY__");

	/// <summary>
	/// Type of equipment
	/// </summary>
	public ListControl PseudTiposequ => new ListControl(driver, ContainerLocator, "#FAMI1___PSEUDTIPOSEQU");

	/// <summary>
	/// Type of equipment
	/// </summary>
	public IWebElement PseudTiposeq1 => throw new NotImplementedException();

	public Fami1Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FAMI1", containerLocator: containerLocator) { }
}
