using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LocatForm : Form
{
	/// <summary>
	/// Location
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#LOCAT___PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Legal name
	/// </summary>
	public LookupControl EntitName => new LookupControl(driver, ContainerLocator, "container-LOCAT___ENTITNAME____" + IdSuffix);
	public SeeMorePage EntitNameSeeMorePage => new SeeMorePage(driver, "LOCAT", "LOCAT___ENTITNAME____" + IdSuffix);

	/// <summary>
	/// Facility name
	/// </summary>
	public LookupControl FacilName => new LookupControl(driver, ContainerLocator, "container-LOCAT___FACILNAME____" + IdSuffix);
	public SeeMorePage FacilNameSeeMorePage => new SeeMorePage(driver, "LOCAT", "LOCAT___FACILNAME____" + IdSuffix);

	/// <summary>
	/// Global Location Number
	/// </summary>
	public BaseInputControl LocatGln => new BaseInputControl(driver, ContainerLocator, "container-LOCAT___LOCATGLN_____" + IdSuffix, "#LOCAT___LOCATGLN_____" + IdSuffix);

	/// <summary>
	/// Location Extension Components
	/// </summary>
	public ListControl PseudLocalext => new ListControl(driver, ContainerLocator, "#LOCAT___PSEUDLOCALEXT" + IdSuffix);

	public LocatForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "LOCAT", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
