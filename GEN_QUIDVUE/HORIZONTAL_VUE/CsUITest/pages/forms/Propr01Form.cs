using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Propr01Form : Subform
{
	/// <summary>
	/// Address
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPR01_PSEUDNOVOGR01-container");

	/// <summary>
	/// Address
	/// </summary>
	public BaseInputControl ProprEndereco => new BaseInputControl(driver, ContainerLocator, "container-PROPR01_PROPRENDERECO", "#PROPR01_PROPRENDERECO");

	/// <summary>
	/// Localization
	/// </summary>
	public BaseInputControl ProprLocalida => new BaseInputControl(driver, ContainerLocator, "container-PROPR01_PROPRLOCALIDA", "#PROPR01_PROPRLOCALIDA");

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl ProprPostalco => new BaseInputControl(driver, ContainerLocator, "container-PROPR01_PROPRPOSTALCO", "#PROPR01_PROPRPOSTALCO");

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl ProprPostallo => new BaseInputControl(driver, ContainerLocator, "container-PROPR01_PROPRPOSTALLO", "#PROPR01_PROPRPOSTALLO");

	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, ContainerLocator, "container-PROPR01_CNTRYCOUNTRY_");
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "PROPR01", "PROPR01_CNTRYCOUNTRY_");

	/// <summary>
	/// Region
	/// </summary>
	public LookupControl RegioRegiao => new LookupControl(driver, ContainerLocator, "container-PROPR01_REGIOREGIAO__");
	public SeeMorePage RegioRegiaoSeeMorePage => new SeeMorePage(driver, "PROPR01", "PROPR01_REGIOREGIAO__");

	/// <summary>
	/// Geographic Coordinates
	/// </summary>
	public BaseInputControl ProprCoordgeo => new BaseInputControl(driver, ContainerLocator, "container-PROPR01_PROPRCOORDGEO", "#PROPR01_PROPRCOORDGEO");

	public Propr01Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PROPR01", "PROPR00", containerLocator: containerLocator) { }
}
