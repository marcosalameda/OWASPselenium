using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Vendaw04Form : Form
{
	/// <summary>
	/// Approach
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#VENDAW04PSEUDNOVOGR04" + IdSuffix + "-container");

	/// <summary>
	/// Approach
	/// </summary>
	public DateInputControl SaleDtaborda => new DateInputControl(driver, ContainerLocator, "#VENDAW04SALE_DTABORDA" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Approach taken
	/// </summary>
	public CheckboxInputControl SaleApproach => new CheckboxInputControl(driver, ContainerLocator, "#container-VENDAW04SALE_APPROACH" + IdSuffix);

	public Vendaw04Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "VENDAW04", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
