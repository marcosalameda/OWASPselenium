using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AnoForm : Form
{
	/// <summary>
	/// Year
	/// </summary>
	public BaseInputControl YearYear => new BaseInputControl(driver, ContainerLocator, "container-ANO_____YEAR_YEAR____", "#ANO_____YEAR_YEAR____");

	/// <summary>
	/// Year (numbers)
	/// </summary>
	public BaseInputControl YearYearnum => new BaseInputControl(driver, ContainerLocator, "container-ANO_____YEAR_YEARNUM_", "#ANO_____YEAR_YEARNUM_");

	/// <summary>
	/// All the expenses
	/// </summary>
	public ListControl PseudTodasdes => new ListControl(driver, ContainerLocator, "#ANO_____PSEUDTODASDES");

	/// <summary>
	/// Aggregated per year
	/// </summary>
	public ListControl PseudAgregado => new ListControl(driver, ContainerLocator, "#ANO_____PSEUDAGREGADO");

	/// <summary>
	/// Value
	/// </summary>
	public BaseInputControl YearValue => new BaseInputControl(driver, ContainerLocator, "container-ANO_____YEAR_VALUE___", "#ANO_____YEAR_VALUE___");

	public AnoForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ANO", containerLocator: containerLocator) { }
}
