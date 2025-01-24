using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TabprForm : Form
{
	/// <summary>
	/// TABLE PRICE
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#TABPR___PSEUDNOVOGR01-container");

	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl TpequTipoequi => new LookupControl(driver, ContainerLocator, "container-TABPR___TPEQUTIPOEQUI");
	public SeeMorePage TpequTipoequiSeeMorePage => new SeeMorePage(driver, "TABPR", "TABPR___TPEQUTIPOEQUI");

	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl TabprSince => new DateInputControl(driver, ContainerLocator, "#TABPR___TABPRSINCE___", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Price per hour:
	/// </summary>
	public BaseInputControl TabprPrecohor => new BaseInputControl(driver, ContainerLocator, "#TABPR___TABPRPRECOHOR");

	public TabprForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "TABPR", containerLocator: containerLocator) { }
}
