using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AnoForm : Form
{
	/// <summary>
	/// Year
	/// </summary>
	public BaseInputControl YearYear => new BaseInputControl(driver, ContainerLocator, "container-ANO_____YEAR_YEAR____" + IdSuffix, "#ANO_____YEAR_YEAR____" + IdSuffix);

	/// <summary>
	/// Year (numbers)
	/// </summary>
	public BaseInputControl YearYearnum => new BaseInputControl(driver, ContainerLocator, "container-ANO_____YEAR_YEARNUM_" + IdSuffix, "#ANO_____YEAR_YEARNUM_" + IdSuffix);

	/// <summary>
	/// All the expenses
	/// </summary>
	public ListControl PseudTodasdes => new ListControl(driver, ContainerLocator, "#ANO_____PSEUDTODASDES" + IdSuffix);

	/// <summary>
	/// Aggregated per year
	/// </summary>
	public ListControl PseudAgregado => new ListControl(driver, ContainerLocator, "#ANO_____PSEUDAGREGADO" + IdSuffix);

	/// <summary>
	/// Value
	/// </summary>
	public BaseInputControl YearValue => new BaseInputControl(driver, ContainerLocator, "container-ANO_____YEAR_VALUE___" + IdSuffix, "#ANO_____YEAR_VALUE___" + IdSuffix);

	public AnoForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ANO", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
