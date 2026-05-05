using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FacilForm : Form
{
	/// <summary>
	/// Legal name
	/// </summary>
	public LookupControl EntitName => new LookupControl(driver, ContainerLocator, "container-FACIL___ENTITNAME____");
	public SeeMorePage EntitNameSeeMorePage => new SeeMorePage(driver, "FACIL", "FACIL___ENTITNAME____");

	/// <summary>
	/// Incorporation
	/// </summary>
	public DateInputControl FacilIncorpor => new DateInputControl(driver, ContainerLocator, "#FACIL___FACILINCORPOR");

	/// <summary>
	/// Facility name
	/// </summary>
	public BaseInputControl FacilName => new BaseInputControl(driver, ContainerLocator, "container-FACIL___FACILNAME____", "#FACIL___FACILNAME____");

	/// <summary>
	/// Facility type
	/// </summary>
	public EnumControl FacilFaciltyp => new EnumControl(driver, ContainerLocator, "container-FACIL___FACILFACILTYP");

	/// <summary>
	/// Facility type
	/// </summary>
	public LookupControl FactyType => new LookupControl(driver, ContainerLocator, "container-FACIL___FACTYTYPE____");
	public SeeMorePage FactyTypeSeeMorePage => new SeeMorePage(driver, "FACIL", "FACIL___FACTYTYPE____");

	/// <summary>
	/// Address
	/// </summary>
	public BaseInputControl FacilAddress => new BaseInputControl(driver, ContainerLocator, "container-FACIL___FACILADDRESS_", "#FACIL___FACILADDRESS_");

	/// <summary>
	/// Image
	/// </summary>
	public BaseInputControl FacilImage => new BaseInputControl(driver, ContainerLocator, "container-FACIL___FACILIMAGE___", "#FACIL___FACILIMAGE___");

	/// <summary>
	/// GPS input
	/// </summary>
	public RadiobuttonControl FacilGpsinput => new RadiobuttonControl(driver, ContainerLocator, "container-FACIL___FACILGPSINPUT");

	/// <summary>
	/// Latitude
	/// </summary>
	public BaseInputControl FacilLatitude => new BaseInputControl(driver, ContainerLocator, "container-FACIL___FACILLATITUDE", "#FACIL___FACILLATITUDE");

	/// <summary>
	/// Longitude
	/// </summary>
	public BaseInputControl FacilLongitud => new BaseInputControl(driver, ContainerLocator, "container-FACIL___FACILLONGITUD", "#FACIL___FACILLONGITUD");

	/// <summary>
	/// Geographical coordinate
	/// </summary>
	public BaseInputControl FacilGeocoori => new BaseInputControl(driver, ContainerLocator, "container-FACIL___FACILGEOCOORI", "#FACIL___FACILGEOCOORI");

	public FacilForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FACIL", containerLocator: containerLocator) { }
}
