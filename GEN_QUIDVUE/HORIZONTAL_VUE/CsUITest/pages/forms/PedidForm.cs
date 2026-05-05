using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PedidForm : Form
{
	/// <summary>
	/// Date:
	/// </summary>
	public DateInputControl PedidDtpedido => new DateInputControl(driver, ContainerLocator, "#PEDID___PEDIDDTPEDIDO");

	/// <summary>
	/// Number
	/// </summary>
	public BaseInputControl PedidNrpedido => new BaseInputControl(driver, ContainerLocator, "container-PEDID___PEDIDNRPEDIDO", "#PEDID___PEDIDNRPEDIDO");

	/// <summary>
	/// Motive:
	/// </summary>
	public BaseInputControl PedidMotivo => new BaseInputControl(driver, ContainerLocator, "container-PEDID___PEDIDMOTIVO__", "#PEDID___PEDIDMOTIVO__");

	/// <summary>
	/// Lines
	/// </summary>
	public ListControl PseudLinhas => new ListControl(driver, ContainerLocator, "#PEDID___PSEUDLINHAS__");

	/// <summary>
	/// Breakdown:
	/// </summary>
	public ListControl PseudDesagreg => new ListControl(driver, ContainerLocator, "#PEDID___PSEUDDESAGREG");

	/// <summary>
	/// Grouping of Equipment Types
	/// </summary>
	public ListControl PseudAgrupame => new ListControl(driver, ContainerLocator, "#PEDID___PSEUDAGRUPAME");

	public PedidForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PEDID", containerLocator: containerLocator) { }
}
