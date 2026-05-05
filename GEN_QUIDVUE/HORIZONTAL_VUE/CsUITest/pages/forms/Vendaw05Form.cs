using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Vendaw05Form : Form
{
	/// <summary>
	/// Presentation
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, ContainerLocator, "#VENDAW05PSEUDNOVOGR05-container");

	/// <summary>
	/// Presentation made
	/// </summary>
	public DateInputControl SaleDtaprese => new DateInputControl(driver, ContainerLocator, "#VENDAW05SALE_DTAPRESE", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Presentation
	/// </summary>
	public CheckboxInputControl SaleApresent => new CheckboxInputControl(driver, ContainerLocator, "#container-VENDAW05SALE_APRESENT");

	public Vendaw05Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "VENDAW05", containerLocator: containerLocator) { }
}
