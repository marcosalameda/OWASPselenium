using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DilinForm : Form
{
	/// <summary>
	/// Dispatch number
	/// </summary>
	public LookupControl DispaDispanr => new LookupControl(driver, ContainerLocator, "container-DILIN___DISPADISPANR_" + IdSuffix);
	public SeeMorePage DispaDispanrSeeMorePage => new SeeMorePage(driver, "DILIN", "DILIN___DISPADISPANR_" + IdSuffix);

	/// <summary>
	/// Line
	/// </summary>
	public BaseInputControl DilinLinenumb => new BaseInputControl(driver, ContainerLocator, "container-DILIN___DILINLINENUMB" + IdSuffix, "#DILIN___DILINLINENUMB" + IdSuffix);

	/// <summary>
	/// Product
	/// </summary>
	public LookupControl ProduProduct => new LookupControl(driver, ContainerLocator, "container-DILIN___PRODUPRODUCT_" + IdSuffix);
	public SeeMorePage ProduProductSeeMorePage => new SeeMorePage(driver, "DILIN", "DILIN___PRODUPRODUCT_" + IdSuffix);

	/// <summary>
	/// Ordered
	/// </summary>
	public BaseInputControl DilinOrdered => new BaseInputControl(driver, ContainerLocator, "container-DILIN___DILINORDERED_" + IdSuffix, "#DILIN___DILINORDERED_" + IdSuffix);

	/// <summary>
	/// Delivered
	/// </summary>
	public BaseInputControl DilinDelivere => new BaseInputControl(driver, ContainerLocator, "container-DILIN___DILINDELIVERE" + IdSuffix, "#DILIN___DILINDELIVERE" + IdSuffix);

	/// <summary>
	/// Outstanding
	/// </summary>
	public BaseInputControl DilinOutstand => new BaseInputControl(driver, ContainerLocator, "container-DILIN___DILINOUTSTAND" + IdSuffix, "#DILIN___DILINOUTSTAND" + IdSuffix);

	public DilinForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "DILIN", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
