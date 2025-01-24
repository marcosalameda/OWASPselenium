using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LnhpdForm : Form
{
	/// <summary>
	/// Order no:
	/// </summary>
	public LookupControl PedidNrpedido => new LookupControl(driver, ContainerLocator, "container-LNHPD___PEDIDNRPEDIDO");
	public SeeMorePage PedidNrpedidoSeeMorePage => new SeeMorePage(driver, "LNHPD", "LNHPD___PEDIDNRPEDIDO");

	/// <summary>
	/// Line
	/// </summary>
	public BaseInputControl LnhpdLine => new BaseInputControl(driver, ContainerLocator, "#LNHPD___LNHPDLINE____");

	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl TpequTipoequi => new LookupControl(driver, ContainerLocator, "container-LNHPD___TPEQUTIPOEQUI");
	public SeeMorePage TpequTipoequiSeeMorePage => new SeeMorePage(driver, "LNHPD", "LNHPD___TPEQUTIPOEQUI");

	/// <summary>
	/// Breaks down
	/// </summary>
	public ButtonControl PseudDesconju => new ButtonControl(driver, ContainerLocator, "#LNHPD___PSEUDDESCONJU");

	/// <summary>
	/// Quantity
	/// </summary>
	public BaseInputControl LnhpdQuantida => new BaseInputControl(driver, ContainerLocator, "#LNHPD___LNHPDQUANTIDA");

	/// <summary>
	/// Amount
	/// </summary>
	public BaseInputControl LnhpdQuantdec => new BaseInputControl(driver, ContainerLocator, "#LNHPD___LNHPDQUANTDEC");

	/// <summary>
	/// Breakdown:
	/// </summary>
	public ListControl PseudDesagreg => new ListControl(driver, ContainerLocator, "#LNHPD___PSEUDDESAGREG");

	public LnhpdForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "LNHPD", containerLocator: containerLocator) { }
}
