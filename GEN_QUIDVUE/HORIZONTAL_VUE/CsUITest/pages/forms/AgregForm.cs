using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AgregForm : Form
{
	/// <summary>
	/// Project
	/// </summary>
	public LookupControl ProjeProjecto => new LookupControl(driver, ContainerLocator, "container-AGREG___PROJEPROJECTO");
	public SeeMorePage ProjeProjectoSeeMorePage => new SeeMorePage(driver, "AGREG", "AGREG___PROJEPROJECTO");

	/// <summary>
	/// Year
	/// </summary>
	public LookupControl YearYear => new LookupControl(driver, ContainerLocator, "container-AGREG___YEAR_YEAR____");
	public SeeMorePage YearYearSeeMorePage => new SeeMorePage(driver, "AGREG", "AGREG___YEAR_YEAR____");

	/// <summary>
	/// Value
	/// </summary>
	public BaseInputControl AgregValue => new BaseInputControl(driver, ContainerLocator, "container-AGREG___AGREGVALUE___", "#AGREG___AGREGVALUE___");

	public AgregForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "AGREG", containerLocator: containerLocator) { }
}
