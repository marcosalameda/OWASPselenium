using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Vendaw01Form : Form
{
	/// <summary>
	/// Organization
	/// </summary>
	public LookupControl OrganOrganiza => new LookupControl(driver, ContainerLocator, "container-VENDAW01ORGANORGANIZA");
	public SeeMorePage OrganOrganizaSeeMorePage => new SeeMorePage(driver, "VENDAW01", "VENDAW01ORGANORGANIZA");

	/// <summary>
	/// Prospecting
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#VENDAW01PSEUDNOVOGR01-container");

	/// <summary>
	/// Identification of business opportunity
	/// </summary>
	public BaseInputControl SaleIdentifi => new BaseInputControl(driver, ContainerLocator, "#VENDAW01SALE_IDENTIFI");

	/// <summary>
	/// Potential buyers
	/// </summary>
	public BaseInputControl SalePotcompr => new BaseInputControl(driver, ContainerLocator, "#VENDAW01SALE_POTCOMPR");

	/// <summary>
	/// Prospecting carried out
	/// </summary>
	public CheckboxInputControl SaleProspecc => new CheckboxInputControl(driver, ContainerLocator, "#container-VENDAW01SALE_PROSPECC");

	public Vendaw01Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "VENDAW01", containerLocator: containerLocator) { }
}
