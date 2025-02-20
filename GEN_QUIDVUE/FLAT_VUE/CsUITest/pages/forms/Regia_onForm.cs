using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Regia_onForm : Form
{
	/// <summary>
	/// País:
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, ContainerLocator, "container-REGIA_ONCNTRYCOUNTRY_");
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "REGIA_ON", "REGIA_ONCNTRYCOUNTRY_");

	/// <summary>
	/// Região:
	/// </summary>
	public BaseInputControl RegioRegiao => new BaseInputControl(driver, ContainerLocator, "container-REGIA_ONREGIOREGIAO__", "#REGIA_ONREGIOREGIAO__");

	/// <summary>
	/// País pessoa
	/// </summary>
	public LookupControl Pais1Country => new LookupControl(driver, ContainerLocator, "container-REGIA_ONPAIS1COUNTRY_");
	public SeeMorePage Pais1CountrySeeMorePage => new SeeMorePage(driver, "REGIA_ON", "REGIA_ONPAIS1COUNTRY_");

	/// <summary>
	/// Imóveis
	/// </summary>
	public ListControl PseudImoveisl => new ListControl(driver, ContainerLocator, "#REGIA_ONPSEUDIMOVEISL");

	public Regia_onForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "REGIA_ON", containerLocator: containerLocator) { }
}
