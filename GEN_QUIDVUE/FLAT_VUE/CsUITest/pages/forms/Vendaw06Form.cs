using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Vendaw06Form : Form
{
	/// <summary>
	/// Overcoming objections
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, ContainerLocator, "#VENDAW06PSEUDNOVOGR06-container");

	/// <summary>
	/// Overcoming objections
	/// </summary>
	public DateInputControl SaleDtsupera => new DateInputControl(driver, ContainerLocator, "#VENDAW06SALE_DTSUPERA", "dd/MM/yyyy HH:mm");

	public Vendaw06Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "VENDAW06", containerLocator: containerLocator) { }
}
