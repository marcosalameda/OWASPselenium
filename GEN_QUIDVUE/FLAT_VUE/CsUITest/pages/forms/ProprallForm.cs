using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ProprallForm : Form
{
	/// <summary>
	/// Photo
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPRALLPSEUDNOVOGR03" + IdSuffix + "-container");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl ProprPhotogra => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRPHOTOGRA" + IdSuffix, "#PROPRALLPROPRPHOTOGRA" + IdSuffix);

	/// <summary>
	/// Identification
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPRALLPSEUDNOVOGR02" + IdSuffix + "-container");

	/// <summary>
	/// real estate
	/// </summary>
	public BaseInputControl ProprName => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRNAME____" + IdSuffix, "#PROPRALLPROPRNAME____" + IdSuffix);

	/// <summary>
	/// Estimated price
	/// </summary>
	public BaseInputControl ProprPrecoest => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRPRECOEST" + IdSuffix, "#PROPRALLPROPRPRECOEST" + IdSuffix);

	/// <summary>
	/// Property Type
	/// </summary>
	public LookupControl TpproTppropri => new LookupControl(driver, ContainerLocator, "container-PROPRALLTPPROTPPROPRI" + IdSuffix);
	public SeeMorePage TpproTppropriSeeMorePage => new SeeMorePage(driver, "PROPRALL", "PROPRALLTPPROTPPROPRI" + IdSuffix);

	/// <summary>
	/// Localization
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPRALLPSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Furnished
	/// </summary>
	public CheckboxInputControl ProprMobilada => new CheckboxInputControl(driver, ContainerLocator, "#container-PROPRALLPROPRMOBILADA" + IdSuffix);

	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, ContainerLocator, "container-PROPRALLCNTRYCOUNTRY_" + IdSuffix);
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "PROPRALL", "PROPRALLCNTRYCOUNTRY_" + IdSuffix);

	/// <summary>
	/// Region
	/// </summary>
	public LookupControl RegioRegiao => new LookupControl(driver, ContainerLocator, "container-PROPRALLREGIOREGIAO__" + IdSuffix);
	public SeeMorePage RegioRegiaoSeeMorePage => new SeeMorePage(driver, "PROPRALL", "PROPRALLREGIOREGIAO__" + IdSuffix);

	/// <summary>
	/// Address
	/// </summary>
	public BaseInputControl ProprEndereco => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRENDERECO" + IdSuffix, "#PROPRALLPROPRENDERECO" + IdSuffix);

	/// <summary>
	/// Localization
	/// </summary>
	public BaseInputControl ProprLocalida => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRLOCALIDA" + IdSuffix, "#PROPRALLPROPRLOCALIDA" + IdSuffix);

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl ProprPostalco => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRPOSTALCO" + IdSuffix, "#PROPRALLPROPRPOSTALCO" + IdSuffix);

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl ProprPostallo => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRPOSTALLO" + IdSuffix, "#PROPRALLPROPRPOSTALLO" + IdSuffix);

	/// <summary>
	/// Bathroom
	/// </summary>
	public BaseInputControl ProprQtd_wc => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRQTD_WC__" + IdSuffix, "#PROPRALLPROPRQTD_WC__" + IdSuffix);

	/// <summary>
	/// Rooms
	/// </summary>
	public BaseInputControl ProprQtdquart => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRQTDQUART" + IdSuffix, "#PROPRALLPROPRQTDQUART" + IdSuffix);

	/// <summary>
	/// Square meters
	/// </summary>
	public BaseInputControl ProprM2 => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRM2______" + IdSuffix, "#PROPRALLPROPRM2______" + IdSuffix);

	/// <summary>
	/// Available from
	/// </summary>
	public DateInputControl ProprDtdispon => new DateInputControl(driver, ContainerLocator, "#PROPRALLPROPRDTDISPON" + IdSuffix);

	/// <summary>
	/// Description
	/// </summary>
	public IWebElement ProprDescript => throw new NotImplementedException();

	/// <summary>
	/// Geographic Coordinates
	/// </summary>
	public BaseInputControl ProprCoordgeo => new BaseInputControl(driver, ContainerLocator, "container-PROPRALLPROPRCOORDGEO" + IdSuffix, "#PROPRALLPROPRCOORDGEO" + IdSuffix);

	/// <summary>
	/// Seller
	/// </summary>
	public LookupControl PessoName => new LookupControl(driver, ContainerLocator, "container-PROPRALLPESSONAME____" + IdSuffix);
	public SeeMorePage PessoNameSeeMorePage => new SeeMorePage(driver, "PROPRALL", "PROPRALLPESSONAME____" + IdSuffix);

	public ProprallForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PROPRALL", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
