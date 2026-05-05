using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Vendaw08Form : Form
{
	/// <summary>
	/// Assistance
	/// </summary>
	public CollapsibleZoneControl PseudNovogr08 => new CollapsibleZoneControl(driver, ContainerLocator, "#VENDAW08PSEUDNOVOGR08-container");

	/// <summary>
	/// Assistance
	/// </summary>
	public DateInputControl SaleDtacompa => new DateInputControl(driver, ContainerLocator, "#VENDAW08SALE_DTACOMPA", "dd/MM/yyyy HH:mm");

	public Vendaw08Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "VENDAW08", containerLocator: containerLocator) { }
}
