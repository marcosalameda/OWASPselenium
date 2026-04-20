using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArmapessForm : Form
{
	/// <summary>
	/// Employee Number
	/// </summary>
	public BaseInputControl WpessNfunc => new BaseInputControl(driver, ContainerLocator, "container-ARMAPESSWPESSNFUNC___" + IdSuffix, "#ARMAPESSWPESSNFUNC___" + IdSuffix);

	/// <summary>
	/// Profille picture
	/// </summary>
	public BaseInputControl WpessPfoto => new BaseInputControl(driver, ContainerLocator, "container-ARMAPESSWPESSPFOTO___" + IdSuffix, "#ARMAPESSWPESSPFOTO___" + IdSuffix);

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl WpessName => new BaseInputControl(driver, ContainerLocator, "container-ARMAPESSWPESSNAME____" + IdSuffix, "#ARMAPESSWPESSNAME____" + IdSuffix);

	/// <summary>
	/// Birth date
	/// </summary>
	public DateInputControl WpessDate => new DateInputControl(driver, ContainerLocator, "#ARMAPESSWPESSDATE____" + IdSuffix);

	/// <summary>
	/// Sex
	/// </summary>
	public EnumControl WpessSex => new EnumControl(driver, ContainerLocator, "container-ARMAPESSWPESSSEX_____" + IdSuffix);

	/// <summary>
	/// Country of Birth
	/// </summary>
	public BaseInputControl WpessNaturali => new BaseInputControl(driver, ContainerLocator, "container-ARMAPESSWPESSNATURALI" + IdSuffix, "#ARMAPESSWPESSNATURALI" + IdSuffix);

	/// <summary>
	/// Nationality
	/// </summary>
	public BaseInputControl WpessNacional => new BaseInputControl(driver, ContainerLocator, "container-ARMAPESSWPESSNACIONAL" + IdSuffix, "#ARMAPESSWPESSNACIONAL" + IdSuffix);

	/// <summary>
	/// Adress
	/// </summary>
	public BaseInputControl WpessAdress => new BaseInputControl(driver, ContainerLocator, "container-ARMAPESSWPESSADRESS__" + IdSuffix, "#ARMAPESSWPESSADRESS__" + IdSuffix);

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl WpessZipcode => new BaseInputControl(driver, ContainerLocator, "container-ARMAPESSWPESSZIPCODE_" + IdSuffix, "#ARMAPESSWPESSZIPCODE_" + IdSuffix);

	/// <summary>
	/// Country
	/// </summary>
	public BaseInputControl WpessCountry => new BaseInputControl(driver, ContainerLocator, "container-ARMAPESSWPESSCOUNTRY_" + IdSuffix, "#ARMAPESSWPESSCOUNTRY_" + IdSuffix);

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl WpessEmail => new BaseInputControl(driver, ContainerLocator, "container-ARMAPESSWPESSEMAIL___" + IdSuffix, "#ARMAPESSWPESSEMAIL___" + IdSuffix);

	/// <summary>
	/// Cellphone
	/// </summary>
	public BaseInputControl WpessCellphon => new BaseInputControl(driver, ContainerLocator, "container-ARMAPESSWPESSCELLPHON" + IdSuffix, "#ARMAPESSWPESSCELLPHON" + IdSuffix);

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-ARMAPESSWAREHWAREHDES" + IdSuffix);
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "ARMAPESS", "ARMAPESSWAREHWAREHDES" + IdSuffix);

	public ArmapessForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ARMAPESS", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
