using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Ctry03Form : Form
{
	/// <summary>
	/// Country
	/// </summary>
	public BaseInputControl CtryCountry => new BaseInputControl(driver, ContainerLocator, "#CTRY03__CTRY_COUNTRY_");

	public Ctry03Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CTRY03", containerLocator: containerLocator) { }
}
