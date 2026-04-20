using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Propr01Form : Subform
{
	/// <summary>
	/// Address
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPR01_PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Address
	/// </summary>
	public BaseInputControl ProprEndereco => new BaseInputControl(driver, ContainerLocator, "container-PROPR01_PROPRENDERECO" + IdSuffix, "#PROPR01_PROPRENDERECO" + IdSuffix);

	/// <summary>
	/// Localization
	/// </summary>
	public BaseInputControl ProprLocalida => new BaseInputControl(driver, ContainerLocator, "container-PROPR01_PROPRLOCALIDA" + IdSuffix, "#PROPR01_PROPRLOCALIDA" + IdSuffix);

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl ProprPostalco => new BaseInputControl(driver, ContainerLocator, "container-PROPR01_PROPRPOSTALCO" + IdSuffix, "#PROPR01_PROPRPOSTALCO" + IdSuffix);

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl ProprPostallo => new BaseInputControl(driver, ContainerLocator, "container-PROPR01_PROPRPOSTALLO" + IdSuffix, "#PROPR01_PROPRPOSTALLO" + IdSuffix);

	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, ContainerLocator, "container-PROPR01_CNTRYCOUNTRY_" + IdSuffix);
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "PROPR01", "PROPR01_CNTRYCOUNTRY_" + IdSuffix);

	/// <summary>
	/// Region
	/// </summary>
	public LookupControl RegioRegiao => new LookupControl(driver, ContainerLocator, "container-PROPR01_REGIOREGIAO__" + IdSuffix);
	public SeeMorePage RegioRegiaoSeeMorePage => new SeeMorePage(driver, "PROPR01", "PROPR01_REGIOREGIAO__" + IdSuffix);

	/// <summary>
	/// Geographic Coordinates
	/// </summary>
	public BaseInputControl ProprCoordgeo => new BaseInputControl(driver, ContainerLocator, "container-PROPR01_PROPRCOORDGEO" + IdSuffix, "#PROPR01_PROPRCOORDGEO" + IdSuffix);

	public Propr01Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PROPR01", "PROPR00", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
