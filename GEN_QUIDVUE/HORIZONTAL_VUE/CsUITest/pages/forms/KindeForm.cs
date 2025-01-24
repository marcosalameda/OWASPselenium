using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class KindeForm : Form
{
	/// <summary>
	/// Kind of equipment
	/// </summary>
	public BaseInputControl KindeDesignat => new BaseInputControl(driver, ContainerLocator, "#KINDE___KINDEDESIGNAT");

	/// <summary>
	/// Parameters
	/// </summary>
	public ListControl PseudParamete => new ListControl(driver, ContainerLocator, "#KINDE___PSEUDPARAMETE");

	/// <summary>
	/// Manuals
	/// </summary>
	public ListControl PseudManuals => new ListControl(driver, ContainerLocator, "#KINDE___PSEUDMANUALS_");

	public KindeForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "KINDE", containerLocator: containerLocator) { }
}
