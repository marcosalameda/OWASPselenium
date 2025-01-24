using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Cate1Form : Form
{
	/// <summary>
	/// Abbreviation
	/// </summary>
	public BaseInputControl Cate1Abbrevia => new BaseInputControl(driver, ContainerLocator, "#CATE1___CATE1ABBREVIA");

	/// <summary>
	/// Category
	/// </summary>
	public BaseInputControl Cate1Category => new BaseInputControl(driver, ContainerLocator, "#CATE1___CATE1CATEGORY");

	public Cate1Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CATE1", containerLocator: containerLocator) { }
}
