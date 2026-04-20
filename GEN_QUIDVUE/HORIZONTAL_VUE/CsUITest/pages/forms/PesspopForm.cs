using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PesspopForm : PopupForm
{
	/// <summary>
	/// Employee Number
	/// </summary>
	public BaseInputControl WpessNfunc => new BaseInputControl(driver, ContainerLocator, "container-PESSPOP_WPESSNFUNC___" + IdSuffix, "#PESSPOP_WPESSNFUNC___" + IdSuffix);

	/// <summary>
	/// Profille picture
	/// </summary>
	public BaseInputControl WpessPfoto => new BaseInputControl(driver, ContainerLocator, "container-PESSPOP_WPESSPFOTO___" + IdSuffix, "#PESSPOP_WPESSPFOTO___" + IdSuffix);

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl WpessName => new BaseInputControl(driver, ContainerLocator, "container-PESSPOP_WPESSNAME____" + IdSuffix, "#PESSPOP_WPESSNAME____" + IdSuffix);

	/// <summary>
	/// Birth date
	/// </summary>
	public DateInputControl WpessDate => new DateInputControl(driver, ContainerLocator, "#PESSPOP_WPESSDATE____" + IdSuffix);

	/// <summary>
	/// Sex
	/// </summary>
	public EnumControl WpessSex => new EnumControl(driver, ContainerLocator, "container-PESSPOP_WPESSSEX_____" + IdSuffix);

	/// <summary>
	/// Country of Birth
	/// </summary>
	public BaseInputControl WpessNaturali => new BaseInputControl(driver, ContainerLocator, "container-PESSPOP_WPESSNATURALI" + IdSuffix, "#PESSPOP_WPESSNATURALI" + IdSuffix);

	/// <summary>
	/// Nationality
	/// </summary>
	public BaseInputControl WpessNacional => new BaseInputControl(driver, ContainerLocator, "container-PESSPOP_WPESSNACIONAL" + IdSuffix, "#PESSPOP_WPESSNACIONAL" + IdSuffix);

	/// <summary>
	/// Adress
	/// </summary>
	public BaseInputControl WpessAdress => new BaseInputControl(driver, ContainerLocator, "container-PESSPOP_WPESSADRESS__" + IdSuffix, "#PESSPOP_WPESSADRESS__" + IdSuffix);

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl WpessZipcode => new BaseInputControl(driver, ContainerLocator, "container-PESSPOP_WPESSZIPCODE_" + IdSuffix, "#PESSPOP_WPESSZIPCODE_" + IdSuffix);

	/// <summary>
	/// Country
	/// </summary>
	public BaseInputControl WpessCountry => new BaseInputControl(driver, ContainerLocator, "container-PESSPOP_WPESSCOUNTRY_" + IdSuffix, "#PESSPOP_WPESSCOUNTRY_" + IdSuffix);

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl WpessEmail => new BaseInputControl(driver, ContainerLocator, "container-PESSPOP_WPESSEMAIL___" + IdSuffix, "#PESSPOP_WPESSEMAIL___" + IdSuffix);

	/// <summary>
	/// Cellphone
	/// </summary>
	public BaseInputControl WpessCellphon => new BaseInputControl(driver, ContainerLocator, "container-PESSPOP_WPESSCELLPHON" + IdSuffix, "#PESSPOP_WPESSCELLPHON" + IdSuffix);

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-PESSPOP_WAREHWAREHDES" + IdSuffix);
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "PESSPOP", "PESSPOP_WAREHWAREHDES" + IdSuffix);

	public PesspopForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PESSPOP", usePkInId: usePkInId) { }
}
