using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ProjeForm : Form
{
	/// <summary>
	/// Project
	/// </summary>
	public BaseInputControl ProjeProjecto => new BaseInputControl(driver, ContainerLocator, "#PROJE___PROJEPROJECTO");

	/// <summary>
	/// Year
	/// </summary>
	public LookupControl Year1Year => new LookupControl(driver, ContainerLocator, "container-PROJE___YEAR1YEAR____");
	public SeeMorePage Year1YearSeeMorePage => new SeeMorePage(driver, "PROJE", "PROJE___YEAR1YEAR____");

	/// <summary>
	/// First
	/// </summary>
	public BaseInputControl ProjePrimeiro => new BaseInputControl(driver, ContainerLocator, "#PROJE___PROJEPRIMEIRO");

	/// <summary>
	/// Before
	/// </summary>
	public BaseInputControl ProjeBefore => new BaseInputControl(driver, ContainerLocator, "#PROJE___PROJEBEFORE__");

	/// <summary>
	/// Following
	/// </summary>
	public BaseInputControl ProjeFollowin => new BaseInputControl(driver, ContainerLocator, "#PROJE___PROJEFOLLOWIN");

	/// <summary>
	/// Last
	/// </summary>
	public BaseInputControl ProjeUltimo => new BaseInputControl(driver, ContainerLocator, "#PROJE___PROJEULTIMO__");

	/// <summary>
	/// Next - previous =
	/// </summary>
	public BaseInputControl ProjeSaldo1 => new BaseInputControl(driver, ContainerLocator, "#PROJE___PROJESALDO1__");

	/// <summary>
	/// Last - First =
	/// </summary>
	public BaseInputControl ProjeSaldo2 => new BaseInputControl(driver, ContainerLocator, "#PROJE___PROJESALDO2__");

	/// <summary>
	/// Expenses
	/// </summary>
	public ListControl PseudDespesas => new ListControl(driver, ContainerLocator, "#PROJE___PSEUDDESPESAS");

	/// <summary>
	/// Decomission by year
	/// </summary>
	public ListControl PseudAgregado => new ListControl(driver, ContainerLocator, "#PROJE___PSEUDAGREGADO");

	public ProjeForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PROJE", containerLocator: containerLocator) { }
}
