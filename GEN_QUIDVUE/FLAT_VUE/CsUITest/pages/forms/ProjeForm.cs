using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ProjeForm : Form
{
	/// <summary>
	/// Project
	/// </summary>
	public BaseInputControl ProjeProjecto => new BaseInputControl(driver, ContainerLocator, "container-PROJE___PROJEPROJECTO" + IdSuffix, "#PROJE___PROJEPROJECTO" + IdSuffix);

	/// <summary>
	/// Year
	/// </summary>
	public LookupControl Year1Year => new LookupControl(driver, ContainerLocator, "container-PROJE___YEAR1YEAR____" + IdSuffix);
	public SeeMorePage Year1YearSeeMorePage => new SeeMorePage(driver, "PROJE", "PROJE___YEAR1YEAR____" + IdSuffix);

	/// <summary>
	/// First
	/// </summary>
	public BaseInputControl ProjePrimeiro => new BaseInputControl(driver, ContainerLocator, "container-PROJE___PROJEPRIMEIRO" + IdSuffix, "#PROJE___PROJEPRIMEIRO" + IdSuffix);

	/// <summary>
	/// Before
	/// </summary>
	public BaseInputControl ProjeBefore => new BaseInputControl(driver, ContainerLocator, "container-PROJE___PROJEBEFORE__" + IdSuffix, "#PROJE___PROJEBEFORE__" + IdSuffix);

	/// <summary>
	/// Following
	/// </summary>
	public BaseInputControl ProjeFollowin => new BaseInputControl(driver, ContainerLocator, "container-PROJE___PROJEFOLLOWIN" + IdSuffix, "#PROJE___PROJEFOLLOWIN" + IdSuffix);

	/// <summary>
	/// Last
	/// </summary>
	public BaseInputControl ProjeUltimo => new BaseInputControl(driver, ContainerLocator, "container-PROJE___PROJEULTIMO__" + IdSuffix, "#PROJE___PROJEULTIMO__" + IdSuffix);

	/// <summary>
	/// Next - previous =
	/// </summary>
	public BaseInputControl ProjeSaldo1 => new BaseInputControl(driver, ContainerLocator, "container-PROJE___PROJESALDO1__" + IdSuffix, "#PROJE___PROJESALDO1__" + IdSuffix);

	/// <summary>
	/// Last - First =
	/// </summary>
	public BaseInputControl ProjeSaldo2 => new BaseInputControl(driver, ContainerLocator, "container-PROJE___PROJESALDO2__" + IdSuffix, "#PROJE___PROJESALDO2__" + IdSuffix);

	/// <summary>
	/// Expenses
	/// </summary>
	public ListControl PseudDespesas => new ListControl(driver, ContainerLocator, "#PROJE___PSEUDDESPESAS" + IdSuffix);

	/// <summary>
	/// Decomission by year
	/// </summary>
	public ListControl PseudAgregado => new ListControl(driver, ContainerLocator, "#PROJE___PSEUDAGREGADO" + IdSuffix);

	public ProjeForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PROJE", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
