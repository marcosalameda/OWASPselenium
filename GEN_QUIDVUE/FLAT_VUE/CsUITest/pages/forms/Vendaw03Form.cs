using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Vendaw03Form : Form
{
	/// <summary>
	/// Pre-approach
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#VENDAW03PSEUDNOVOGR03" + IdSuffix + "-container");

	/// <summary>
	/// Pre-approach
	/// </summary>
	public DateInputControl SalePreabord => new DateInputControl(driver, ContainerLocator, "#VENDAW03SALE_PREABORD" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Homework done
	/// </summary>
	public CheckboxInputControl SaleHomework => new CheckboxInputControl(driver, ContainerLocator, "#container-VENDAW03SALE_HOMEWORK" + IdSuffix);

	public Vendaw03Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "VENDAW03", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
