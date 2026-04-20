using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class C_brnForm : Form
{
	/// <summary>
	/// Country
	/// </summary>
	public BaseInputControl C_brnCountry => new BaseInputControl(driver, ContainerLocator, "container-C_BRN___C_BRNCOUNTRY_" + IdSuffix, "#C_BRN___C_BRNCOUNTRY_" + IdSuffix);

	public C_brnForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "C_BRN", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
