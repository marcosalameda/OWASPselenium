using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class C_brnForm : Form
{
	/// <summary>
	/// Country
	/// </summary>
	public BaseInputControl C_brnCountry => new BaseInputControl(driver, ContainerLocator, "container-C_BRN___C_BRNCOUNTRY_", "#C_BRN___C_BRNCOUNTRY_");

	public C_brnForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "C_BRN", containerLocator: containerLocator) { }
}
