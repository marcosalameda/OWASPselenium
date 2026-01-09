using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CacessiForm : Subform
{
	/// <summary>
	/// Accessibilty Compliance & Best Practices
	/// </summary>
	public BaseInputControl CompoAccessib => new BaseInputControl(driver, ContainerLocator, "container-CACESSI_COMPOACCESSIB", "#CACESSI_COMPOACCESSIB");

	public CacessiForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CACESSI", "COMPTYPE", containerLocator: containerLocator) { }
}
