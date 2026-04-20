using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AgregForm : Form
{
	/// <summary>
	/// Project
	/// </summary>
	public LookupControl ProjeProjecto => new LookupControl(driver, ContainerLocator, "container-AGREG___PROJEPROJECTO" + IdSuffix);
	public SeeMorePage ProjeProjectoSeeMorePage => new SeeMorePage(driver, "AGREG", "AGREG___PROJEPROJECTO" + IdSuffix);

	/// <summary>
	/// Year
	/// </summary>
	public LookupControl YearYear => new LookupControl(driver, ContainerLocator, "container-AGREG___YEAR_YEAR____" + IdSuffix);
	public SeeMorePage YearYearSeeMorePage => new SeeMorePage(driver, "AGREG", "AGREG___YEAR_YEAR____" + IdSuffix);

	/// <summary>
	/// Value
	/// </summary>
	public BaseInputControl AgregValue => new BaseInputControl(driver, ContainerLocator, "container-AGREG___AGREGVALUE___" + IdSuffix, "#AGREG___AGREGVALUE___" + IdSuffix);

	public AgregForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "AGREG", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
