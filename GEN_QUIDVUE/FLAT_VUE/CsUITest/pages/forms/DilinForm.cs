using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DilinForm : Form
{
	/// <summary>
	/// Dispatch number
	/// </summary>
	public LookupControl DispaDispanr => new LookupControl(driver, ContainerLocator, "container-DILIN___DISPADISPANR_");
	public SeeMorePage DispaDispanrSeeMorePage => new SeeMorePage(driver, "DILIN", "DILIN___DISPADISPANR_");

	/// <summary>
	/// Line
	/// </summary>
	public BaseInputControl DilinLinenumb => new BaseInputControl(driver, ContainerLocator, "#DILIN___DILINLINENUMB");

	/// <summary>
	/// Product
	/// </summary>
	public LookupControl ProduProduct => new LookupControl(driver, ContainerLocator, "container-DILIN___PRODUPRODUCT_");
	public SeeMorePage ProduProductSeeMorePage => new SeeMorePage(driver, "DILIN", "DILIN___PRODUPRODUCT_");

	/// <summary>
	/// Ordered
	/// </summary>
	public BaseInputControl DilinOrdered => new BaseInputControl(driver, ContainerLocator, "#DILIN___DILINORDERED_");

	/// <summary>
	/// Delivered
	/// </summary>
	public BaseInputControl DilinDelivere => new BaseInputControl(driver, ContainerLocator, "#DILIN___DILINDELIVERE");

	/// <summary>
	/// Outstanding
	/// </summary>
	public BaseInputControl DilinOutstand => new BaseInputControl(driver, ContainerLocator, "#DILIN___DILINOUTSTAND");

	public DilinForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "DILIN", containerLocator: containerLocator) { }
}
