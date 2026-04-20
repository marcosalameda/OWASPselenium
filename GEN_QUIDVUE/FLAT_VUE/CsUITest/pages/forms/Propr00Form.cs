using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Propr00Form : Form
{
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPR00_PSEUDNOVOGR04" + IdSuffix + "-container");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPR00_PSEUDNOVOGR02" + IdSuffix + "-container");

	/// <summary>
	/// Real estate
	/// </summary>
	public BaseInputControl ProprName => new BaseInputControl(driver, ContainerLocator, "container-PROPR00_PROPRNAME____" + IdSuffix, "#PROPR00_PROPRNAME____" + IdSuffix);

	/// <summary>
	/// Estimated price
	/// </summary>
	public BaseInputControl ProprPrecoest => new BaseInputControl(driver, ContainerLocator, "container-PROPR00_PROPRPRECOEST" + IdSuffix, "#PROPR00_PROPRPRECOEST" + IdSuffix);

	/// <summary>
	/// Property Type
	/// </summary>
	public LookupControl TpproTppropri => new LookupControl(driver, ContainerLocator, "container-PROPR00_TPPROTPPROPRI" + IdSuffix);
	public SeeMorePage TpproTppropriSeeMorePage => new SeeMorePage(driver, "PROPR00", "PROPR00_TPPROTPPROPRI" + IdSuffix);

	/// <summary>
	/// Furnished
	/// </summary>
	public CheckboxInputControl ProprMobilada => new CheckboxInputControl(driver, ContainerLocator, "#container-PROPR00_PROPRMOBILADA" + IdSuffix);

	/// <summary>
	/// Seller
	/// </summary>
	public LookupControl PessoName => new LookupControl(driver, ContainerLocator, "container-PROPR00_PESSONAME____" + IdSuffix);
	public SeeMorePage PessoNameSeeMorePage => new SeeMorePage(driver, "PROPR00", "PROPR00_PESSONAME____" + IdSuffix);

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl ProprPhotogra => new BaseInputControl(driver, ContainerLocator, "container-PROPR00_PROPRPHOTOGRA" + IdSuffix, "#PROPR00_PROPRPHOTOGRA" + IdSuffix);

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPR00_PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Details
	/// </summary>
	public TabControl PseudPropr02 => new TabControl(driver, ContainerLocator, "[data-testid='tab-container-PROPR00_PSEUDPROPR02_']");

	/// <summary>
	/// Localization
	/// </summary>
	public TabControl PseudPropr01 => new TabControl(driver, ContainerLocator, "[data-testid='tab-container-PROPR00_PSEUDPROPR01_']");

	/// <summary>
	/// Description
	/// </summary>
	public TabControl PseudPropr03 => new TabControl(driver, ContainerLocator, "[data-testid='tab-container-PROPR00_PSEUDPROPR03_']");

	/// <summary>
	/// Bathroom
	/// </summary>
	public BaseInputControl Propr02ProprQtd_wc => new BaseInputControl(driver, ContainerLocator, "container-PROPR02_PROPRQTD_WC__" + IdSuffix, "#PROPR02_PROPRQTD_WC__" + IdSuffix);

	/// <summary>
	/// Quartos
	/// </summary>
	public BaseInputControl Propr02ProprQtdquart => new BaseInputControl(driver, ContainerLocator, "container-PROPR02_PROPRQTDQUART" + IdSuffix, "#PROPR02_PROPRQTDQUART" + IdSuffix);

	/// <summary>
	/// Square meters
	/// </summary>
	public BaseInputControl Propr02ProprM2 => new BaseInputControl(driver, ContainerLocator, "container-PROPR02_PROPRM2______" + IdSuffix, "#PROPR02_PROPRM2______" + IdSuffix);

	/// <summary>
	/// Available from
	/// </summary>
	public DateInputControl Propr02ProprDtdispon => new DateInputControl(driver, ContainerLocator, "#PROPR02_PROPRDTDISPON" + IdSuffix);

	/// <summary>
	/// Address
	/// </summary>
	public CollapsibleZoneControl Propr01PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPR01_PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Address
	/// </summary>
	public BaseInputControl Propr01ProprEndereco => new BaseInputControl(driver, ContainerLocator, "container-PROPR01_PROPRENDERECO" + IdSuffix, "#PROPR01_PROPRENDERECO" + IdSuffix);

	/// <summary>
	/// Localization
	/// </summary>
	public BaseInputControl Propr01ProprLocalida => new BaseInputControl(driver, ContainerLocator, "container-PROPR01_PROPRLOCALIDA" + IdSuffix, "#PROPR01_PROPRLOCALIDA" + IdSuffix);

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl Propr01ProprPostalco => new BaseInputControl(driver, ContainerLocator, "container-PROPR01_PROPRPOSTALCO" + IdSuffix, "#PROPR01_PROPRPOSTALCO" + IdSuffix);

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl Propr01ProprPostallo => new BaseInputControl(driver, ContainerLocator, "container-PROPR01_PROPRPOSTALLO" + IdSuffix, "#PROPR01_PROPRPOSTALLO" + IdSuffix);

	/// <summary>
	/// Country
	/// </summary>
	public LookupControl Propr01CntryCountry => new LookupControl(driver, ContainerLocator, "container-PROPR01_CNTRYCOUNTRY_" + IdSuffix);
	public SeeMorePage Propr01CntryCountrySeeMorePage => new SeeMorePage(driver, "PROPR01", "PROPR01_CNTRYCOUNTRY_" + IdSuffix);

	/// <summary>
	/// Region
	/// </summary>
	public LookupControl Propr01RegioRegiao => new LookupControl(driver, ContainerLocator, "container-PROPR01_REGIOREGIAO__" + IdSuffix);
	public SeeMorePage Propr01RegioRegiaoSeeMorePage => new SeeMorePage(driver, "PROPR01", "PROPR01_REGIOREGIAO__" + IdSuffix);

	/// <summary>
	/// Geographic Coordinates
	/// </summary>
	public BaseInputControl Propr01ProprCoordgeo => new BaseInputControl(driver, ContainerLocator, "container-PROPR01_PROPRCOORDGEO" + IdSuffix, "#PROPR01_PROPRCOORDGEO" + IdSuffix);

	/// <summary>
	/// Description
	/// </summary>
	public IWebElement Propr03ProprDescript => throw new NotImplementedException();

	public Propr00Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PROPR00", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
