using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RegiaproForm : Form
{
	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, ContainerLocator, "container-REGIAPROCNTRYCOUNTRY_");
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "REGIAPRO", "REGIAPROCNTRYCOUNTRY_");

	/// <summary>
	/// Region
	/// </summary>
	public BaseInputControl RegioRegiao => new BaseInputControl(driver, ContainerLocator, "#REGIAPROREGIOREGIAO__");

	/// <summary>
	/// Country
	/// </summary>
	public LookupControl Pais1Country => new LookupControl(driver, ContainerLocator, "container-REGIAPROPAIS1COUNTRY_");
	public SeeMorePage Pais1CountrySeeMorePage => new SeeMorePage(driver, "REGIAPRO", "REGIAPROPAIS1COUNTRY_");

	/// <summary>
	/// Non Limited Properties
	/// </summary>
	public ListControl PseudImoveiss => new ListControl(driver, ContainerLocator, "#REGIAPROPSEUDIMOVEISS");

	/// <summary>
	/// Properties
	/// </summary>
	public ListControl PseudImoveisl => new ListControl(driver, ContainerLocator, "#REGIAPROPSEUDIMOVEISL");

	/// <summary>
	/// Properties
	/// </summary>
	public ListControl PseudImoveisg => new ListControl(driver, ContainerLocator, "#REGIAPROPSEUDIMOVEISG");

	public RegiaproForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "REGIAPRO", containerLocator: containerLocator) { }
}
