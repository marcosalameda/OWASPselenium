using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Wid_iequForm : Form
{
	/// <summary>
	/// Sequential no.
	/// </summary>
	public BaseInputControl EquipSequennr => new BaseInputControl(driver, ContainerLocator, "container-WID_IEQUEQUIPSEQUENNR", "#WID_IEQUEQUIPSEQUENNR");

	/// <summary>
	/// No. register
	/// </summary>
	public BaseInputControl EquipRegistnr => new BaseInputControl(driver, ContainerLocator, "container-WID_IEQUEQUIPREGISTNR", "#WID_IEQUEQUIPREGISTNR");

	/// <summary>
	/// TYPE OF EQUIPMENT
	/// </summary>
	public LookupControl TpequTipoequi => new LookupControl(driver, ContainerLocator, "container-WID_IEQUTPEQUTIPOEQUI");
	public SeeMorePage TpequTipoequiSeeMorePage => new SeeMorePage(driver, "WID_IEQU", "WID_IEQUTPEQUTIPOEQUI");

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-WID_IEQUWAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "WID_IEQU", "WID_IEQUWAREHWAREHDES");

	/// <summary>
	/// Total value
	/// </summary>
	public BaseInputControl EquipValortot => new BaseInputControl(driver, ContainerLocator, "container-WID_IEQUEQUIPVALORTOT", "#WID_IEQUEQUIPVALORTOT");

	/// <summary>
	/// Acquisition
	/// </summary>
	public DateInputControl EquipDtaquisi => new DateInputControl(driver, ContainerLocator, "#WID_IEQUEQUIPDTAQUISI");

	/// <summary>
	/// Decomission
	/// </summary>
	public DateInputControl EquipDtdeco => new DateInputControl(driver, ContainerLocator, "#WID_IEQUEQUIPDTDECO__");

	/// <summary>
	/// Bought
	/// </summary>
	public CheckboxInputControl EquipBought => new CheckboxInputControl(driver, ContainerLocator, "#container-WID_IEQUEQUIPBOUGHT__");

	public Wid_iequForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "WID_IEQU", containerLocator: containerLocator) { }
}
