using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Propr00Form : Form
{
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPR00_PSEUDNOVOGR04-container");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPR00_PSEUDNOVOGR02-container");

	/// <summary>
	/// Real estate
	/// </summary>
	public BaseInputControl ProprName => new BaseInputControl(driver, ContainerLocator, "container-PROPR00_PROPRNAME____", "#PROPR00_PROPRNAME____");

	/// <summary>
	/// Estimated price
	/// </summary>
	public BaseInputControl ProprPrecoest => new BaseInputControl(driver, ContainerLocator, "container-PROPR00_PROPRPRECOEST", "#PROPR00_PROPRPRECOEST");

	/// <summary>
	/// Property Type
	/// </summary>
	public LookupControl TpproTppropri => new LookupControl(driver, ContainerLocator, "container-PROPR00_TPPROTPPROPRI");
	public SeeMorePage TpproTppropriSeeMorePage => new SeeMorePage(driver, "PROPR00", "PROPR00_TPPROTPPROPRI");

	/// <summary>
	/// Furnished
	/// </summary>
	public CheckboxInputControl ProprMobilada => new CheckboxInputControl(driver, ContainerLocator, "#container-PROPR00_PROPRMOBILADA");

	/// <summary>
	/// Seller
	/// </summary>
	public LookupControl PessoName => new LookupControl(driver, ContainerLocator, "container-PROPR00_PESSONAME____");
	public SeeMorePage PessoNameSeeMorePage => new SeeMorePage(driver, "PROPR00", "PROPR00_PESSONAME____");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl ProprPhotogra => new BaseInputControl(driver, ContainerLocator, "container-PROPR00_PROPRPHOTOGRA", "#PROPR00_PROPRPHOTOGRA");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPR00_PSEUDNOVOGR01-container");

	/// <summary>
	/// Details
	/// </summary>
	public TabControl PseudPropr02 => new TabControl(driver, ContainerLocator, "#tab-container-PROPR00_PSEUDPROPR02_");

	/// <summary>
	/// Localization
	/// </summary>
	public TabControl PseudPropr01 => new TabControl(driver, ContainerLocator, "#tab-container-PROPR00_PSEUDPROPR01_");

	/// <summary>
	/// Description
	/// </summary>
	public TabControl PseudPropr03 => new TabControl(driver, ContainerLocator, "#tab-container-PROPR00_PSEUDPROPR03_");

	/// <summary>
	/// Bathroom
	/// </summary>
	public BaseInputControl Propr02ProprQtd_wc => new BaseInputControl(driver, ContainerLocator, "container-PROPR02_PROPRQTD_WC__", "#PROPR02_PROPRQTD_WC__");

	/// <summary>
	/// Quartos
	/// </summary>
	public BaseInputControl Propr02ProprQtdquart => new BaseInputControl(driver, ContainerLocator, "container-PROPR02_PROPRQTDQUART", "#PROPR02_PROPRQTDQUART");

	/// <summary>
	/// Square meters
	/// </summary>
	public BaseInputControl Propr02ProprM2 => new BaseInputControl(driver, ContainerLocator, "container-PROPR02_PROPRM2______", "#PROPR02_PROPRM2______");

	/// <summary>
	/// Available from
	/// </summary>
	public DateInputControl Propr02ProprDtdispon => new DateInputControl(driver, ContainerLocator, "#PROPR02_PROPRDTDISPON");

	/// <summary>
	/// Address
	/// </summary>
	public CollapsibleZoneControl Propr01PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPR01_PSEUDNOVOGR01-container");

	/// <summary>
	/// Address
	/// </summary>
	public BaseInputControl Propr01ProprEndereco => new BaseInputControl(driver, ContainerLocator, "container-PROPR01_PROPRENDERECO", "#PROPR01_PROPRENDERECO");

	/// <summary>
	/// Localization
	/// </summary>
	public BaseInputControl Propr01ProprLocalida => new BaseInputControl(driver, ContainerLocator, "container-PROPR01_PROPRLOCALIDA", "#PROPR01_PROPRLOCALIDA");

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl Propr01ProprPostalco => new BaseInputControl(driver, ContainerLocator, "container-PROPR01_PROPRPOSTALCO", "#PROPR01_PROPRPOSTALCO");

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl Propr01ProprPostallo => new BaseInputControl(driver, ContainerLocator, "container-PROPR01_PROPRPOSTALLO", "#PROPR01_PROPRPOSTALLO");

	/// <summary>
	/// Country
	/// </summary>
	public LookupControl Propr01CntryCountry => new LookupControl(driver, ContainerLocator, "container-PROPR01_CNTRYCOUNTRY_");
	public SeeMorePage Propr01CntryCountrySeeMorePage => new SeeMorePage(driver, "PROPR01", "PROPR01_CNTRYCOUNTRY_");

	/// <summary>
	/// Region
	/// </summary>
	public LookupControl Propr01RegioRegiao => new LookupControl(driver, ContainerLocator, "container-PROPR01_REGIOREGIAO__");
	public SeeMorePage Propr01RegioRegiaoSeeMorePage => new SeeMorePage(driver, "PROPR01", "PROPR01_REGIOREGIAO__");

	/// <summary>
	/// Geographic Coordinates
	/// </summary>
	public BaseInputControl Propr01ProprCoordgeo => new BaseInputControl(driver, ContainerLocator, "container-PROPR01_PROPRCOORDGEO", "#PROPR01_PROPRCOORDGEO");

	/// <summary>
	/// Description
	/// </summary>
	public IWebElement Propr03ProprDescript => throw new NotImplementedException();

	public Propr00Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PROPR00", containerLocator: containerLocator) { }
}
