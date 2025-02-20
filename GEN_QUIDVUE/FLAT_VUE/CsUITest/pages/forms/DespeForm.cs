using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DespeForm : Form
{
	/// <summary>
	/// Project
	/// </summary>
	public LookupControl ProjeProjecto => new LookupControl(driver, ContainerLocator, "container-DESPE___PROJEPROJECTO");
	public SeeMorePage ProjeProjectoSeeMorePage => new SeeMorePage(driver, "DESPE", "DESPE___PROJEPROJECTO");

	/// <summary>
	/// Year
	/// </summary>
	public LookupControl YearYear => new LookupControl(driver, ContainerLocator, "container-DESPE___YEAR_YEAR____");
	public SeeMorePage YearYearSeeMorePage => new SeeMorePage(driver, "DESPE", "DESPE___YEAR_YEAR____");

	/// <summary>
	/// Value
	/// </summary>
	public LookupControl AgregValue => new LookupControl(driver, ContainerLocator, "container-DESPE___AGREGVALUE___");
	public SeeMorePage AgregValueSeeMorePage => new SeeMorePage(driver, "DESPE", "DESPE___AGREGVALUE___");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl ExpenDescript => new BaseInputControl(driver, ContainerLocator, "container-DESPE___EXPENDESCRIPT", "#DESPE___EXPENDESCRIPT");

	/// <summary>
	/// Value
	/// </summary>
	public BaseInputControl ExpenValue => new BaseInputControl(driver, ContainerLocator, "container-DESPE___EXPENVALUE___", "#DESPE___EXPENVALUE___");

	/// <summary>
	/// Previous Value
	/// </summary>
	public BaseInputControl ExpenPrevval => new BaseInputControl(driver, ContainerLocator, "container-DESPE___EXPENPREVVAL_", "#DESPE___EXPENPREVVAL_");

	/// <summary>
	/// Previous Year
	/// </summary>
	public BaseInputControl ExpenYearprev => new BaseInputControl(driver, ContainerLocator, "container-DESPE___EXPENYEARPREV", "#DESPE___EXPENYEARPREV");

	public DespeForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "DESPE", containerLocator: containerLocator) { }
}
