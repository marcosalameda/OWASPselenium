using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArmapessForm : Form
{
	/// <summary>
	/// Employee Number
	/// </summary>
	public BaseInputControl WpessNfunc => new BaseInputControl(driver, ContainerLocator, "container-ARMAPESSWPESSNFUNC___", "#ARMAPESSWPESSNFUNC___");

	/// <summary>
	/// Profille picture
	/// </summary>
	public BaseInputControl WpessPfoto => new BaseInputControl(driver, ContainerLocator, "container-ARMAPESSWPESSPFOTO___", "#ARMAPESSWPESSPFOTO___");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl WpessName => new BaseInputControl(driver, ContainerLocator, "container-ARMAPESSWPESSNAME____", "#ARMAPESSWPESSNAME____");

	/// <summary>
	/// Birth date
	/// </summary>
	public DateInputControl WpessDate => new DateInputControl(driver, ContainerLocator, "#ARMAPESSWPESSDATE____");

	/// <summary>
	/// Sex
	/// </summary>
	public EnumControl WpessSex => new EnumControl(driver, ContainerLocator, "container-ARMAPESSWPESSSEX_____");

	/// <summary>
	/// Country of Birth
	/// </summary>
	public BaseInputControl WpessNaturali => new BaseInputControl(driver, ContainerLocator, "container-ARMAPESSWPESSNATURALI", "#ARMAPESSWPESSNATURALI");

	/// <summary>
	/// Nationality
	/// </summary>
	public BaseInputControl WpessNacional => new BaseInputControl(driver, ContainerLocator, "container-ARMAPESSWPESSNACIONAL", "#ARMAPESSWPESSNACIONAL");

	/// <summary>
	/// Adress
	/// </summary>
	public BaseInputControl WpessAdress => new BaseInputControl(driver, ContainerLocator, "container-ARMAPESSWPESSADRESS__", "#ARMAPESSWPESSADRESS__");

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl WpessZipcode => new BaseInputControl(driver, ContainerLocator, "container-ARMAPESSWPESSZIPCODE_", "#ARMAPESSWPESSZIPCODE_");

	/// <summary>
	/// Country
	/// </summary>
	public BaseInputControl WpessCountry => new BaseInputControl(driver, ContainerLocator, "container-ARMAPESSWPESSCOUNTRY_", "#ARMAPESSWPESSCOUNTRY_");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl WpessEmail => new BaseInputControl(driver, ContainerLocator, "container-ARMAPESSWPESSEMAIL___", "#ARMAPESSWPESSEMAIL___");

	/// <summary>
	/// Cellphone
	/// </summary>
	public BaseInputControl WpessCellphon => new BaseInputControl(driver, ContainerLocator, "container-ARMAPESSWPESSCELLPHON", "#ARMAPESSWPESSCELLPHON");

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-ARMAPESSWAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "ARMAPESS", "ARMAPESSWAREHWAREHDES");

	public ArmapessForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ARMAPESS", containerLocator: containerLocator) { }
}
