using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Regia_onForm : Form
{
	/// <summary>
	/// País:
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, ContainerLocator, "container-REGIA_ONCNTRYCOUNTRY_" + IdSuffix);
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "REGIA_ON", "REGIA_ONCNTRYCOUNTRY_" + IdSuffix);

	/// <summary>
	/// Região:
	/// </summary>
	public BaseInputControl RegioRegiao => new BaseInputControl(driver, ContainerLocator, "container-REGIA_ONREGIOREGIAO__" + IdSuffix, "#REGIA_ONREGIOREGIAO__" + IdSuffix);

	/// <summary>
	/// País pessoa
	/// </summary>
	public LookupControl Pais1Country => new LookupControl(driver, ContainerLocator, "container-REGIA_ONPAIS1COUNTRY_" + IdSuffix);
	public SeeMorePage Pais1CountrySeeMorePage => new SeeMorePage(driver, "REGIA_ON", "REGIA_ONPAIS1COUNTRY_" + IdSuffix);

	/// <summary>
	/// Imóveis
	/// </summary>
	public ListControl PseudImoveisl => new ListControl(driver, ContainerLocator, "#REGIA_ONPSEUDIMOVEISL" + IdSuffix);

	public Regia_onForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "REGIA_ON", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
