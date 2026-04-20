using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class City03Form : Form
{
	/// <summary>
	/// Cidade
	/// </summary>
	public BaseInputControl CityCity => new BaseInputControl(driver, ContainerLocator, "container-CITY03__CITY_CITY____" + IdSuffix, "#CITY03__CITY_CITY____" + IdSuffix);

	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CtryCountry => new LookupControl(driver, ContainerLocator, "container-CITY03__CTRY_COUNTRY_" + IdSuffix);
	public SeeMorePage CtryCountrySeeMorePage => new SeeMorePage(driver, "CITY03", "CITY03__CTRY_COUNTRY_" + IdSuffix);

	public City03Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "CITY03", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
