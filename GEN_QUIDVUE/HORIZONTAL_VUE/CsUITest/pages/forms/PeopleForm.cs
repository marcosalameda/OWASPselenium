using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PeopleForm : Form
{
	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudPeoplels => new ListControl(driver, ContainerLocator, "#PEOPLE__PSEUDPEOPLELS");

	public PeopleForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PEOPLE", containerLocator: containerLocator) { }
}
