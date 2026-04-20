using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Regia_mlForm : Form
{
	/// <summary>
	/// País:
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, ContainerLocator, "container-REGIA_MLCNTRYCOUNTRY_" + IdSuffix);
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "REGIA_ML", "REGIA_MLCNTRYCOUNTRY_" + IdSuffix);

	/// <summary>
	/// Região:
	/// </summary>
	public BaseInputControl RegioRegiao => new BaseInputControl(driver, ContainerLocator, "container-REGIA_MLREGIOREGIAO__" + IdSuffix, "#REGIA_MLREGIOREGIAO__" + IdSuffix);

	/// <summary>
	/// País pessoa
	/// </summary>
	public LookupControl Pais1Country => new LookupControl(driver, ContainerLocator, "container-REGIA_MLPAIS1COUNTRY_" + IdSuffix);
	public SeeMorePage Pais1CountrySeeMorePage => new SeeMorePage(driver, "REGIA_ML", "REGIA_MLPAIS1COUNTRY_" + IdSuffix);

	/// <summary>
	/// Imóveis
	/// </summary>
	public ListControl PseudImoveisl => new ListControl(driver, ContainerLocator, "#REGIA_MLPSEUDIMOVEISL" + IdSuffix);

	public Regia_mlForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "REGIA_ML", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
