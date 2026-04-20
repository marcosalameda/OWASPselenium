using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FacilForm : Form
{
	/// <summary>
	/// Legal name
	/// </summary>
	public LookupControl EntitName => new LookupControl(driver, ContainerLocator, "container-FACIL___ENTITNAME____" + IdSuffix);
	public SeeMorePage EntitNameSeeMorePage => new SeeMorePage(driver, "FACIL", "FACIL___ENTITNAME____" + IdSuffix);

	/// <summary>
	/// Incorporation
	/// </summary>
	public DateInputControl FacilIncorpor => new DateInputControl(driver, ContainerLocator, "#FACIL___FACILINCORPOR" + IdSuffix);

	/// <summary>
	/// Facility name
	/// </summary>
	public BaseInputControl FacilName => new BaseInputControl(driver, ContainerLocator, "container-FACIL___FACILNAME____" + IdSuffix, "#FACIL___FACILNAME____" + IdSuffix);

	/// <summary>
	/// Facility type
	/// </summary>
	public EnumControl FacilFaciltyp => new EnumControl(driver, ContainerLocator, "container-FACIL___FACILFACILTYP" + IdSuffix);

	/// <summary>
	/// Facility type
	/// </summary>
	public LookupControl FactyType => new LookupControl(driver, ContainerLocator, "container-FACIL___FACTYTYPE____" + IdSuffix);
	public SeeMorePage FactyTypeSeeMorePage => new SeeMorePage(driver, "FACIL", "FACIL___FACTYTYPE____" + IdSuffix);

	/// <summary>
	/// Address
	/// </summary>
	public BaseInputControl FacilAddress => new BaseInputControl(driver, ContainerLocator, "container-FACIL___FACILADDRESS_" + IdSuffix, "#FACIL___FACILADDRESS_" + IdSuffix);

	/// <summary>
	/// Image
	/// </summary>
	public BaseInputControl FacilImage => new BaseInputControl(driver, ContainerLocator, "container-FACIL___FACILIMAGE___" + IdSuffix, "#FACIL___FACILIMAGE___" + IdSuffix);

	/// <summary>
	/// GPS input
	/// </summary>
	public RadiobuttonControl FacilGpsinput => new RadiobuttonControl(driver, ContainerLocator, "container-FACIL___FACILGPSINPUT" + IdSuffix);

	/// <summary>
	/// Latitude
	/// </summary>
	public BaseInputControl FacilLatitude => new BaseInputControl(driver, ContainerLocator, "container-FACIL___FACILLATITUDE" + IdSuffix, "#FACIL___FACILLATITUDE" + IdSuffix);

	/// <summary>
	/// Longitude
	/// </summary>
	public BaseInputControl FacilLongitud => new BaseInputControl(driver, ContainerLocator, "container-FACIL___FACILLONGITUD" + IdSuffix, "#FACIL___FACILLONGITUD" + IdSuffix);

	/// <summary>
	/// Geographical coordinate
	/// </summary>
	public BaseInputControl FacilGeocoori => new BaseInputControl(driver, ContainerLocator, "container-FACIL___FACILGEOCOORI" + IdSuffix, "#FACIL___FACILGEOCOORI" + IdSuffix);

	public FacilForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "FACIL", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
