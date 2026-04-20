using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TabprForm : Form
{
	/// <summary>
	/// TABLE PRICE
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#TABPR___PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl TpequTipoequi => new LookupControl(driver, ContainerLocator, "container-TABPR___TPEQUTIPOEQUI" + IdSuffix);
	public SeeMorePage TpequTipoequiSeeMorePage => new SeeMorePage(driver, "TABPR", "TABPR___TPEQUTIPOEQUI" + IdSuffix);

	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl TabprSince => new DateInputControl(driver, ContainerLocator, "#TABPR___TABPRSINCE___" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Price per hour:
	/// </summary>
	public BaseInputControl TabprPrecohor => new BaseInputControl(driver, ContainerLocator, "container-TABPR___TABPRPRECOHOR" + IdSuffix, "#TABPR___TABPRPRECOHOR" + IdSuffix);

	public TabprForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "TABPR", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
