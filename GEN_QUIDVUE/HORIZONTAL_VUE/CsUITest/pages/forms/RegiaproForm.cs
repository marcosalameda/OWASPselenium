using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RegiaproForm : Form
{
	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, ContainerLocator, "container-REGIAPROCNTRYCOUNTRY_" + IdSuffix);
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "REGIAPRO", "REGIAPROCNTRYCOUNTRY_" + IdSuffix);

	/// <summary>
	/// Region
	/// </summary>
	public BaseInputControl RegioRegiao => new BaseInputControl(driver, ContainerLocator, "container-REGIAPROREGIOREGIAO__" + IdSuffix, "#REGIAPROREGIOREGIAO__" + IdSuffix);

	/// <summary>
	/// Country
	/// </summary>
	public LookupControl Pais1Country => new LookupControl(driver, ContainerLocator, "container-REGIAPROPAIS1COUNTRY_" + IdSuffix);
	public SeeMorePage Pais1CountrySeeMorePage => new SeeMorePage(driver, "REGIAPRO", "REGIAPROPAIS1COUNTRY_" + IdSuffix);

	/// <summary>
	/// Non Limited Properties
	/// </summary>
	public ListControl PseudImoveiss => new ListControl(driver, ContainerLocator, "#REGIAPROPSEUDIMOVEISS" + IdSuffix);

	/// <summary>
	/// Properties
	/// </summary>
	public ListControl PseudImoveisl => new ListControl(driver, ContainerLocator, "#REGIAPROPSEUDIMOVEISL" + IdSuffix);

	/// <summary>
	/// Properties
	/// </summary>
	public ListControl PseudImoveisg => new ListControl(driver, ContainerLocator, "#REGIAPROPSEUDIMOVEISG" + IdSuffix);

	public RegiaproForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "REGIAPRO", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
