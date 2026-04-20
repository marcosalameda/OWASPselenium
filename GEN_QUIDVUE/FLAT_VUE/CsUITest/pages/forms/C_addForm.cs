using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class C_addForm : Form
{
	/// <summary>
	/// Country
	/// </summary>
	public BaseInputControl C_addCountry => new BaseInputControl(driver, ContainerLocator, "container-C_ADD___C_ADDCOUNTRY_" + IdSuffix, "#C_ADD___C_ADDCOUNTRY_" + IdSuffix);

	public C_addForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "C_ADD", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
