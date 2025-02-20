using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DisstForm : Form
{
	/// <summary>
	/// Status
	/// </summary>
	public BaseInputControl DisstStatus => new BaseInputControl(driver, ContainerLocator, "container-DISST___DISSTSTATUS__", "#DISST___DISSTSTATUS__");

	/// <summary>
	/// Order
	/// </summary>
	public BaseInputControl DisstOrder => new BaseInputControl(driver, ContainerLocator, "container-DISST___DISSTORDER___", "#DISST___DISSTORDER___");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl DisstDescript => new BaseInputControl(driver, ContainerLocator, "container-DISST___DISSTDESCRIPT", "#DISST___DISSTDESCRIPT");

	public DisstForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "DISST", containerLocator: containerLocator) { }
}
