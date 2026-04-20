using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FacilfexForm : Form
{
	/// <summary>
	/// Entity legal name
	/// </summary>
	public LookupControl EntitName => new LookupControl(driver, ContainerLocator, "container-FACILFEXENTITNAME____" + IdSuffix);
	public SeeMorePage EntitNameSeeMorePage => new SeeMorePage(driver, "FACILFEX", "FACILFEXENTITNAME____" + IdSuffix);

	/// <summary>
	/// Incorporation
	/// </summary>
	public DateInputControl FacilIncorpor => new DateInputControl(driver, ContainerLocator, "#FACILFEXFACILINCORPOR" + IdSuffix);

	/// <summary>
	/// Facility name
	/// </summary>
	public BaseInputControl FacilName => new BaseInputControl(driver, ContainerLocator, "container-FACILFEXFACILNAME____" + IdSuffix, "#FACILFEXFACILNAME____" + IdSuffix);

	/// <summary>
	/// Facility type
	/// </summary>
	public EnumControl FacilFaciltyp => new EnumControl(driver, ContainerLocator, "container-FACILFEXFACILFACILTYP" + IdSuffix);

	/// <summary>
	/// Facility type
	/// </summary>
	public LookupControl FactyType => new LookupControl(driver, ContainerLocator, "container-FACILFEXFACTYTYPE____" + IdSuffix);
	public SeeMorePage FactyTypeSeeMorePage => new SeeMorePage(driver, "FACILFEX", "FACILFEXFACTYTYPE____" + IdSuffix);

	/// <summary>
	/// Latitude
	/// </summary>
	public BaseInputControl FacilLatitude => new BaseInputControl(driver, ContainerLocator, "container-FACILFEXFACILLATITUDE" + IdSuffix, "#FACILFEXFACILLATITUDE" + IdSuffix);

	/// <summary>
	/// Longitude
	/// </summary>
	public BaseInputControl FacilLongitud => new BaseInputControl(driver, ContainerLocator, "container-FACILFEXFACILLONGITUD" + IdSuffix, "#FACILFEXFACILLONGITUD" + IdSuffix);

	/// <summary>
	/// Address
	/// </summary>
	public BaseInputControl FacilAddress => new BaseInputControl(driver, ContainerLocator, "container-FACILFEXFACILADDRESS_" + IdSuffix, "#FACILFEXFACILADDRESS_" + IdSuffix);

	public FacilfexForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "FACILFEX", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
