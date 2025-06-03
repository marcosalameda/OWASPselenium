using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FacilfexForm : Form
{
	/// <summary>
	/// Entity legal name
	/// </summary>
	public LookupControl EntitName => new LookupControl(driver, ContainerLocator, "container-FACILFEXENTITNAME____");
	public SeeMorePage EntitNameSeeMorePage => new SeeMorePage(driver, "FACILFEX", "FACILFEXENTITNAME____");

	/// <summary>
	/// Incorporation
	/// </summary>
	public DateInputControl FacilIncorpor => new DateInputControl(driver, ContainerLocator, "#FACILFEXFACILINCORPOR");

	/// <summary>
	/// Facility name
	/// </summary>
	public BaseInputControl FacilName => new BaseInputControl(driver, ContainerLocator, "container-FACILFEXFACILNAME____", "#FACILFEXFACILNAME____");

	/// <summary>
	/// Facility type
	/// </summary>
	public EnumControl FacilFaciltyp => new EnumControl(driver, ContainerLocator, "container-FACILFEXFACILFACILTYP");

	/// <summary>
	/// Facility type
	/// </summary>
	public LookupControl FactyType => new LookupControl(driver, ContainerLocator, "container-FACILFEXFACTYTYPE____");
	public SeeMorePage FactyTypeSeeMorePage => new SeeMorePage(driver, "FACILFEX", "FACILFEXFACTYTYPE____");

	/// <summary>
	/// Latitude
	/// </summary>
	public BaseInputControl FacilLatitude => new BaseInputControl(driver, ContainerLocator, "container-FACILFEXFACILLATITUDE", "#FACILFEXFACILLATITUDE");

	/// <summary>
	/// Longitude
	/// </summary>
	public BaseInputControl FacilLongitud => new BaseInputControl(driver, ContainerLocator, "container-FACILFEXFACILLONGITUD", "#FACILFEXFACILLONGITUD");

	/// <summary>
	/// Address
	/// </summary>
	public BaseInputControl FacilAddress => new BaseInputControl(driver, ContainerLocator, "container-FACILFEXFACILADDRESS_", "#FACILFEXFACILADDRESS_");

	public FacilfexForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FACILFEX", containerLocator: containerLocator) { }
}
