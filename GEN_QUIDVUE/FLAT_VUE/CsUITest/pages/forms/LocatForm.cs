using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LocatForm : Form
{
	/// <summary>
	/// Location
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#LOCAT___PSEUDNOVOGR01-container");

	/// <summary>
	/// Legal name
	/// </summary>
	public LookupControl EntitName => new LookupControl(driver, ContainerLocator, "container-LOCAT___ENTITNAME____");
	public SeeMorePage EntitNameSeeMorePage => new SeeMorePage(driver, "LOCAT", "LOCAT___ENTITNAME____");

	/// <summary>
	/// Facility name
	/// </summary>
	public LookupControl FacilName => new LookupControl(driver, ContainerLocator, "container-LOCAT___FACILNAME____");
	public SeeMorePage FacilNameSeeMorePage => new SeeMorePage(driver, "LOCAT", "LOCAT___FACILNAME____");

	/// <summary>
	/// Global Location Number
	/// </summary>
	public BaseInputControl LocatGln => new BaseInputControl(driver, ContainerLocator, "#LOCAT___LOCATGLN_____");

	/// <summary>
	/// Location Extension Components
	/// </summary>
	public ListControl PseudLocalext => new ListControl(driver, ContainerLocator, "#LOCAT___PSEUDLOCALEXT");

	public LocatForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "LOCAT", containerLocator: containerLocator) { }
}
