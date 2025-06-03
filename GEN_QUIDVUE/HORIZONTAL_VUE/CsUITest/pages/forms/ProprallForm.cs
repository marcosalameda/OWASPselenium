using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ProprallForm : Form
{
	/// <summary>
	/// Photo
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPRALLPSEUDNOVOGR03-container");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl ProprPhotogra => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRPHOTOGRA", "#PROPRALLPROPRPHOTOGRA");

	/// <summary>
	/// Identification
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPRALLPSEUDNOVOGR02-container");

	/// <summary>
	/// real estate
	/// </summary>
	public BaseInputControl ProprName => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRNAME____", "#PROPRALLPROPRNAME____");

	/// <summary>
	/// Estimated price
	/// </summary>
	public BaseInputControl ProprPrecoest => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRPRECOEST", "#PROPRALLPROPRPRECOEST");

	/// <summary>
	/// Property Type
	/// </summary>
	public LookupControl TpproTppropri => new LookupControl(driver, ContainerLocator, "container-PROPRALLTPPROTPPROPRI");
	public SeeMorePage TpproTppropriSeeMorePage => new SeeMorePage(driver, "PROPRALL", "PROPRALLTPPROTPPROPRI");

	/// <summary>
	/// Localization
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPRALLPSEUDNOVOGR01-container");

	/// <summary>
	/// Furnished
	/// </summary>
	public CheckboxInputControl ProprMobilada => new CheckboxInputControl(driver, ContainerLocator, "#container-PROPRALLPROPRMOBILADA");

	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, ContainerLocator, "container-PROPRALLCNTRYCOUNTRY_");
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "PROPRALL", "PROPRALLCNTRYCOUNTRY_");

	/// <summary>
	/// Region
	/// </summary>
	public LookupControl RegioRegiao => new LookupControl(driver, ContainerLocator, "container-PROPRALLREGIOREGIAO__");
	public SeeMorePage RegioRegiaoSeeMorePage => new SeeMorePage(driver, "PROPRALL", "PROPRALLREGIOREGIAO__");

	/// <summary>
	/// Address
	/// </summary>
	public BaseInputControl ProprEndereco => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRENDERECO", "#PROPRALLPROPRENDERECO");

	/// <summary>
	/// Localization
	/// </summary>
	public BaseInputControl ProprLocalida => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRLOCALIDA", "#PROPRALLPROPRLOCALIDA");

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl ProprPostalco => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRPOSTALCO", "#PROPRALLPROPRPOSTALCO");

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl ProprPostallo => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRPOSTALLO", "#PROPRALLPROPRPOSTALLO");

	/// <summary>
	/// Bathroom
	/// </summary>
	public BaseInputControl ProprQtd_wc => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRQTD_WC__", "#PROPRALLPROPRQTD_WC__");

	/// <summary>
	/// Rooms
	/// </summary>
	public BaseInputControl ProprQtdquart => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRQTDQUART", "#PROPRALLPROPRQTDQUART");

	/// <summary>
	/// Square meters
	/// </summary>
	public BaseInputControl ProprM2 => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRM2______", "#PROPRALLPROPRM2______");

	/// <summary>
	/// Available from
	/// </summary>
	public DateInputControl ProprDtdispon => new DateInputControl(driver, ContainerLocator, "#PROPRALLPROPRDTDISPON");

	/// <summary>
	/// Description
	/// </summary>
	public IWebElement ProprDescript => throw new NotImplementedException();

	/// <summary>
	/// Geographic Coordinates
	/// </summary>
	public BaseInputControl ProprCoordgeo => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRCOORDGEO", "#PROPRALLPROPRCOORDGEO");

	/// <summary>
	/// Seller
	/// </summary>
	public LookupControl PessoName => new LookupControl(driver, ContainerLocator, "container-PROPRALLPESSONAME____");
	public SeeMorePage PessoNameSeeMorePage => new SeeMorePage(driver, "PROPRALL", "PROPRALLPESSONAME____");

	public ProprallForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PROPRALL", containerLocator: containerLocator) { }
}
