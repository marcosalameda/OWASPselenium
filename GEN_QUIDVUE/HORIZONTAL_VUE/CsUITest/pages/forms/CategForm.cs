using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CategForm : Form
{
	/// <summary>
	/// Category
	/// </summary>
	public BaseInputControl CategCategory => new BaseInputControl(driver, ContainerLocator, "#CATEG___CATEGCATEGORY");

	/// <summary>
	/// Professional abbreviation
	/// </summary>
	public BaseInputControl CategAbbrevia => new BaseInputControl(driver, ContainerLocator, "#CATEG___CATEGABBREVIA");

	public CategForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CATEG", containerLocator: containerLocator) { }
}
