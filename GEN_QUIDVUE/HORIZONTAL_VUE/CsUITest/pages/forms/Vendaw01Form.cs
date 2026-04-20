using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Vendaw01Form : Form
{
	/// <summary>
	/// Organization
	/// </summary>
	public LookupControl OrganOrganiza => new LookupControl(driver, ContainerLocator, "container-VENDAW01ORGANORGANIZA" + IdSuffix);
	public SeeMorePage OrganOrganizaSeeMorePage => new SeeMorePage(driver, "VENDAW01", "VENDAW01ORGANORGANIZA" + IdSuffix);

	/// <summary>
	/// Prospecting
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#VENDAW01PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Identification of business opportunity
	/// </summary>
	public BaseInputControl SaleIdentifi => new BaseInputControl(driver, ContainerLocator, "container-VENDAW01SALE_IDENTIFI" + IdSuffix, "#VENDAW01SALE_IDENTIFI" + IdSuffix);

	/// <summary>
	/// Potential buyers
	/// </summary>
	public BaseInputControl SalePotcompr => new BaseInputControl(driver, ContainerLocator, "container-VENDAW01SALE_POTCOMPR" + IdSuffix, "#VENDAW01SALE_POTCOMPR" + IdSuffix);

	/// <summary>
	/// Prospecting carried out
	/// </summary>
	public CheckboxInputControl SaleProspecc => new CheckboxInputControl(driver, ContainerLocator, "#container-VENDAW01SALE_PROSPECC" + IdSuffix);

	public Vendaw01Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "VENDAW01", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
