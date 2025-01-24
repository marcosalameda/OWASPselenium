using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Vendaw02Form : Form
{
	/// <summary>
	/// Qualification
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#VENDAW02PSEUDNOVOGR02-container");

	/// <summary>
	/// Interested
	/// </summary>
	public CheckboxInputControl SaleInteress => new CheckboxInputControl(driver, ContainerLocator, "#container-VENDAW02SALE_INTERESS");

	/// <summary>
	/// No financial resources
	/// </summary>
	public CheckboxInputControl SaleSemrfina => new CheckboxInputControl(driver, ContainerLocator, "#container-VENDAW02SALE_SEMRFINA");

	/// <summary>
	/// No decision-making capacity
	/// </summary>
	public CheckboxInputControl SaleSemcapac => new CheckboxInputControl(driver, ContainerLocator, "#container-VENDAW02SALE_SEMCAPAC");

	/// <summary>
	/// Qualification
	/// </summary>
	public DateInputControl SaleDtqualif => new DateInputControl(driver, ContainerLocator, "#VENDAW02SALE_DTQUALIF", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Qualification carried out
	/// </summary>
	public CheckboxInputControl SaleQualific => new CheckboxInputControl(driver, ContainerLocator, "#container-VENDAW02SALE_QUALIFIC");

	public Vendaw02Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "VENDAW02", containerLocator: containerLocator) { }
}
