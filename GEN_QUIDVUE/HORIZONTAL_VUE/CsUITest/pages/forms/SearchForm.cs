using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class SearchForm : Form
{
	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, ContainerLocator, "container-SEARCH__CNTRYCOUNTRY_");
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "SEARCH", "SEARCH__CNTRYCOUNTRY_");

	/// <summary>
	/// Region
	/// </summary>
	public LookupControl RegioRegiao => new LookupControl(driver, ContainerLocator, "container-SEARCH__REGIOREGIAO__");
	public SeeMorePage RegioRegiaoSeeMorePage => new SeeMorePage(driver, "SEARCH", "SEARCH__REGIOREGIAO__");

	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudRegioes => new ListControl(driver, ContainerLocator, "#SEARCH__PSEUDREGIOES_");

	public SearchForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "SEARCH", containerLocator: containerLocator) { }
}
