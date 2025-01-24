using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RegiaForm : Form
{
	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, ContainerLocator, "container-REGIA___CNTRYCOUNTRY_");
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "REGIA", "REGIA___CNTRYCOUNTRY_");

	/// <summary>
	/// Region
	/// </summary>
	public BaseInputControl RegioRegiao => new BaseInputControl(driver, ContainerLocator, "#REGIA___REGIOREGIAO__");

	public RegiaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "REGIA", containerLocator: containerLocator) { }
}
