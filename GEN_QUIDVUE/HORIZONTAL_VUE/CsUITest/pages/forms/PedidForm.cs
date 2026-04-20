using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PedidForm : Form
{
	/// <summary>
	/// Date:
	/// </summary>
	public DateInputControl PedidDtpedido => new DateInputControl(driver, ContainerLocator, "#PEDID___PEDIDDTPEDIDO" + IdSuffix);

	/// <summary>
	/// Number
	/// </summary>
	public BaseInputControl PedidNrpedido => new BaseInputControl(driver, ContainerLocator, "container-PEDID___PEDIDNRPEDIDO" + IdSuffix, "#PEDID___PEDIDNRPEDIDO" + IdSuffix);

	/// <summary>
	/// Motive:
	/// </summary>
	public BaseInputControl PedidMotivo => new BaseInputControl(driver, ContainerLocator, "container-PEDID___PEDIDMOTIVO__" + IdSuffix, "#PEDID___PEDIDMOTIVO__" + IdSuffix);

	/// <summary>
	/// Lines
	/// </summary>
	public ListControl PseudLinhas => new ListControl(driver, ContainerLocator, "#PEDID___PSEUDLINHAS__" + IdSuffix);

	/// <summary>
	/// Breakdown:
	/// </summary>
	public ListControl PseudDesagreg => new ListControl(driver, ContainerLocator, "#PEDID___PSEUDDESAGREG" + IdSuffix);

	/// <summary>
	/// Grouping of Equipment Types
	/// </summary>
	public ListControl PseudAgrupame => new ListControl(driver, ContainerLocator, "#PEDID___PSEUDAGRUPAME" + IdSuffix);

	public PedidForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PEDID", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
