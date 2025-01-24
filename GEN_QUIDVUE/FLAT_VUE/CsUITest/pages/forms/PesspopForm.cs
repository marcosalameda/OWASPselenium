using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PesspopForm : PopupForm
{
	/// <summary>
	/// Employee Number
	/// </summary>
	public BaseInputControl WpessNfunc => new BaseInputControl(driver, ContainerLocator, "#PESSPOP_WPESSNFUNC___");

	/// <summary>
	/// Profille picture
	/// </summary>
	public BaseInputControl WpessPfoto => new BaseInputControl(driver, ContainerLocator, "#PESSPOP_WPESSPFOTO___");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl WpessName => new BaseInputControl(driver, ContainerLocator, "#PESSPOP_WPESSNAME____");

	/// <summary>
	/// Birth date
	/// </summary>
	public DateInputControl WpessDate => new DateInputControl(driver, ContainerLocator, "#PESSPOP_WPESSDATE____");

	/// <summary>
	/// Sex
	/// </summary>
	public EnumControl WpessSex => new EnumControl(driver, ContainerLocator, "container-PESSPOP_WPESSSEX_____");

	/// <summary>
	/// Country of Birth
	/// </summary>
	public BaseInputControl WpessNaturali => new BaseInputControl(driver, ContainerLocator, "#PESSPOP_WPESSNATURALI");

	/// <summary>
	/// Nationality
	/// </summary>
	public BaseInputControl WpessNacional => new BaseInputControl(driver, ContainerLocator, "#PESSPOP_WPESSNACIONAL");

	/// <summary>
	/// Adress
	/// </summary>
	public BaseInputControl WpessAdress => new BaseInputControl(driver, ContainerLocator, "#PESSPOP_WPESSADRESS__");

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl WpessZipcode => new BaseInputControl(driver, ContainerLocator, "#PESSPOP_WPESSZIPCODE_");

	/// <summary>
	/// Country
	/// </summary>
	public BaseInputControl WpessCountry => new BaseInputControl(driver, ContainerLocator, "#PESSPOP_WPESSCOUNTRY_");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl WpessEmail => new BaseInputControl(driver, ContainerLocator, "#PESSPOP_WPESSEMAIL___");

	/// <summary>
	/// Cellphone
	/// </summary>
	public BaseInputControl WpessCellphon => new BaseInputControl(driver, ContainerLocator, "#PESSPOP_WPESSCELLPHON");

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-PESSPOP_WAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "PESSPOP", "PESSPOP_WAREHWAREHDES");

	public PesspopForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PESSPOP") { }
}
