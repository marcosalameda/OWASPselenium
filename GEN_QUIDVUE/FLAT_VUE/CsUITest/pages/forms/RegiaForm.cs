using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RegiaForm : Form
{
	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, ContainerLocator, "container-REGIA___CNTRYCOUNTRY_" + IdSuffix);
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "REGIA", "REGIA___CNTRYCOUNTRY_" + IdSuffix);

	/// <summary>
	/// Region
	/// </summary>
	public BaseInputControl RegioRegiao => new BaseInputControl(driver, ContainerLocator, "container-REGIA___REGIOREGIAO__" + IdSuffix, "#REGIA___REGIOREGIAO__" + IdSuffix);

	public RegiaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "REGIA", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
