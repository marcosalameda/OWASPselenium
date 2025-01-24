using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArmapessForm : Form
{
	/// <summary>
	/// Employee Number
	/// </summary>
	public BaseInputControl WpessNfunc => new BaseInputControl(driver, ContainerLocator, "#ARMAPESSWPESSNFUNC___");

	/// <summary>
	/// Profille picture
	/// </summary>
	public BaseInputControl WpessPfoto => new BaseInputControl(driver, ContainerLocator, "#ARMAPESSWPESSPFOTO___");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl WpessName => new BaseInputControl(driver, ContainerLocator, "#ARMAPESSWPESSNAME____");

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
	public BaseInputControl WpessNaturali => new BaseInputControl(driver, ContainerLocator, "#ARMAPESSWPESSNATURALI");

	/// <summary>
	/// Nationality
	/// </summary>
	public BaseInputControl WpessNacional => new BaseInputControl(driver, ContainerLocator, "#ARMAPESSWPESSNACIONAL");

	/// <summary>
	/// Adress
	/// </summary>
	public BaseInputControl WpessAdress => new BaseInputControl(driver, ContainerLocator, "#ARMAPESSWPESSADRESS__");

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl WpessZipcode => new BaseInputControl(driver, ContainerLocator, "#ARMAPESSWPESSZIPCODE_");

	/// <summary>
	/// Country
	/// </summary>
	public BaseInputControl WpessCountry => new BaseInputControl(driver, ContainerLocator, "#ARMAPESSWPESSCOUNTRY_");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl WpessEmail => new BaseInputControl(driver, ContainerLocator, "#ARMAPESSWPESSEMAIL___");

	/// <summary>
	/// Cellphone
	/// </summary>
	public BaseInputControl WpessCellphon => new BaseInputControl(driver, ContainerLocator, "#ARMAPESSWPESSCELLPHON");

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-ARMAPESSWAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "ARMAPESS", "ARMAPESSWAREHWAREHDES");

	public ArmapessForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ARMAPESS", containerLocator: containerLocator) { }
}
