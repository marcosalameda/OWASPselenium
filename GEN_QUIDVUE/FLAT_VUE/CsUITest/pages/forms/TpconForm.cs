using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TpconForm : Form
{
	/// <summary>
	/// CONTACT TYPE
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#TPCON___PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Genre
	/// </summary>
	public LookupControl GenreGender => new LookupControl(driver, ContainerLocator, "container-TPCON___GENREGENDER__" + IdSuffix);
	public SeeMorePage GenreGenderSeeMorePage => new SeeMorePage(driver, "TPCON", "TPCON___GENREGENDER__" + IdSuffix);

	/// <summary>
	/// Contact Type:
	/// </summary>
	public BaseInputControl TpconTipocont => new BaseInputControl(driver, ContainerLocator, "container-TPCON___TPCONTIPOCONT" + IdSuffix, "#TPCON___TPCONTIPOCONT" + IdSuffix);

	public TpconForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "TPCON", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
