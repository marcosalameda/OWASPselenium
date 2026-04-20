using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DespeForm : Form
{
	/// <summary>
	/// Project
	/// </summary>
	public LookupControl ProjeProjecto => new LookupControl(driver, ContainerLocator, "container-DESPE___PROJEPROJECTO" + IdSuffix);
	public SeeMorePage ProjeProjectoSeeMorePage => new SeeMorePage(driver, "DESPE", "DESPE___PROJEPROJECTO" + IdSuffix);

	/// <summary>
	/// Year
	/// </summary>
	public LookupControl YearYear => new LookupControl(driver, ContainerLocator, "container-DESPE___YEAR_YEAR____" + IdSuffix);
	public SeeMorePage YearYearSeeMorePage => new SeeMorePage(driver, "DESPE", "DESPE___YEAR_YEAR____" + IdSuffix);

	/// <summary>
	/// Value
	/// </summary>
	public LookupControl AgregValue => new LookupControl(driver, ContainerLocator, "container-DESPE___AGREGVALUE___" + IdSuffix);
	public SeeMorePage AgregValueSeeMorePage => new SeeMorePage(driver, "DESPE", "DESPE___AGREGVALUE___" + IdSuffix);

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl ExpenDescript => new BaseInputControl(driver, ContainerLocator, "container-DESPE___EXPENDESCRIPT" + IdSuffix, "#DESPE___EXPENDESCRIPT" + IdSuffix);

	/// <summary>
	/// Value
	/// </summary>
	public BaseInputControl ExpenValue => new BaseInputControl(driver, ContainerLocator, "container-DESPE___EXPENVALUE___" + IdSuffix, "#DESPE___EXPENVALUE___" + IdSuffix);

	/// <summary>
	/// Previous Value
	/// </summary>
	public BaseInputControl ExpenPrevval => new BaseInputControl(driver, ContainerLocator, "container-DESPE___EXPENPREVVAL_" + IdSuffix, "#DESPE___EXPENPREVVAL_" + IdSuffix);

	/// <summary>
	/// Previous Year
	/// </summary>
	public BaseInputControl ExpenYearprev => new BaseInputControl(driver, ContainerLocator, "container-DESPE___EXPENYEARPREV" + IdSuffix, "#DESPE___EXPENYEARPREV" + IdSuffix);

	public DespeForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "DESPE", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
