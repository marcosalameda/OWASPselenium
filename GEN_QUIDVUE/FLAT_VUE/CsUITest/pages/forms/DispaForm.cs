using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DispaForm : Form
{
	/// <summary>
	/// Dispatch date
	/// </summary>
	public DateInputControl DispaDispadt => new DateInputControl(driver, ContainerLocator, "#DISPA___DISPADISPADT_" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Dispatch number
	/// </summary>
	public BaseInputControl DispaDispanr => new BaseInputControl(driver, ContainerLocator, "container-DISPA___DISPADISPANR_" + IdSuffix, "#DISPA___DISPADISPANR_" + IdSuffix);

	/// <summary>
	/// Status
	/// </summary>
	public BaseInputControl DispaStatus => new BaseInputControl(driver, ContainerLocator, "container-DISPA___DISPASTATUS__" + IdSuffix, "#DISPA___DISPASTATUS__" + IdSuffix);

	/// <summary>
	/// Customer
	/// </summary>
	public LookupControl EntitName => new LookupControl(driver, ContainerLocator, "container-DISPA___ENTITNAME____" + IdSuffix);
	public SeeMorePage EntitNameSeeMorePage => new SeeMorePage(driver, "DISPA", "DISPA___ENTITNAME____" + IdSuffix);

	/// <summary>
	/// Is prepared
	/// </summary>
	public CheckboxInputControl DispaIsprepar => new CheckboxInputControl(driver, ContainerLocator, "#container-DISPA___DISPAISPREPAR" + IdSuffix);

	/// <summary>
	/// Prepared
	/// </summary>
	public DateInputControl DispaPrepared => new DateInputControl(driver, ContainerLocator, "#DISPA___DISPAPREPARED" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Prepared by
	/// </summary>
	public LookupControl PersoName => new LookupControl(driver, ContainerLocator, "container-DISPA___PERSONAME____" + IdSuffix);
	public SeeMorePage PersoNameSeeMorePage => new SeeMorePage(driver, "DISPA", "DISPA___PERSONAME____" + IdSuffix);

	/// <summary>
	/// Items
	/// </summary>
	public ListControl PseudDispatch => new ListControl(driver, ContainerLocator, "#DISPA___PSEUDDISPATCH" + IdSuffix);

	public DispaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "DISPA", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
