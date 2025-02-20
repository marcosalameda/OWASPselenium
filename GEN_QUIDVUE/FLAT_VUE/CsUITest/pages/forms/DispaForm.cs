using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DispaForm : Form
{
	/// <summary>
	/// Dispatch date
	/// </summary>
	public DateInputControl DispaDispadt => new DateInputControl(driver, ContainerLocator, "#DISPA___DISPADISPADT_", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Dispatch number
	/// </summary>
	public BaseInputControl DispaDispanr => new BaseInputControl(driver, ContainerLocator, "container-DISPA___DISPADISPANR_", "#DISPA___DISPADISPANR_");

	/// <summary>
	/// Status
	/// </summary>
	public LookupControl DisstStatus => new LookupControl(driver, ContainerLocator, "container-DISPA___DISSTSTATUS__");
	public SeeMorePage DisstStatusSeeMorePage => new SeeMorePage(driver, "DISPA", "DISPA___DISSTSTATUS__");

	/// <summary>
	/// Status
	/// </summary>
	public BaseInputControl DispaStatus => new BaseInputControl(driver, ContainerLocator, "container-DISPA___DISPASTATUS__", "#DISPA___DISPASTATUS__");

	/// <summary>
	/// Cliente
	/// </summary>
	public LookupControl EntitName => new LookupControl(driver, ContainerLocator, "container-DISPA___ENTITNAME____");
	public SeeMorePage EntitNameSeeMorePage => new SeeMorePage(driver, "DISPA", "DISPA___ENTITNAME____");

	/// <summary>
	/// Is prepared
	/// </summary>
	public CheckboxInputControl DispaIsprepar => new CheckboxInputControl(driver, ContainerLocator, "#container-DISPA___DISPAISPREPAR");

	/// <summary>
	/// Prepared
	/// </summary>
	public DateInputControl DispaPrepared => new DateInputControl(driver, ContainerLocator, "#DISPA___DISPAPREPARED", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Prepared by
	/// </summary>
	public LookupControl PersoName => new LookupControl(driver, ContainerLocator, "container-DISPA___PERSONAME____");
	public SeeMorePage PersoNameSeeMorePage => new SeeMorePage(driver, "DISPA", "DISPA___PERSONAME____");

	/// <summary>
	/// Items
	/// </summary>
	public ListControl PseudDispatch => new ListControl(driver, ContainerLocator, "#DISPA___PSEUDDISPATCH");

	public DispaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "DISPA", containerLocator: containerLocator) { }
}
