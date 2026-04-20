using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LnhpdForm : Form
{
	/// <summary>
	/// Order no:
	/// </summary>
	public LookupControl PedidNrpedido => new LookupControl(driver, ContainerLocator, "container-LNHPD___PEDIDNRPEDIDO" + IdSuffix);
	public SeeMorePage PedidNrpedidoSeeMorePage => new SeeMorePage(driver, "LNHPD", "LNHPD___PEDIDNRPEDIDO" + IdSuffix);

	/// <summary>
	/// Line
	/// </summary>
	public BaseInputControl LnhpdLine => new BaseInputControl(driver, ContainerLocator, "container-LNHPD___LNHPDLINE____" + IdSuffix, "#LNHPD___LNHPDLINE____" + IdSuffix);

	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl TpequTipoequi => new LookupControl(driver, ContainerLocator, "container-LNHPD___TPEQUTIPOEQUI" + IdSuffix);
	public SeeMorePage TpequTipoequiSeeMorePage => new SeeMorePage(driver, "LNHPD", "LNHPD___TPEQUTIPOEQUI" + IdSuffix);

	/// <summary>
	/// Breaks down
	/// </summary>
	public ButtonControl PseudDesconju => new ButtonControl(driver, ContainerLocator, "#LNHPD___PSEUDDESCONJU" + IdSuffix);

	/// <summary>
	/// Quantity
	/// </summary>
	public BaseInputControl LnhpdQuantida => new BaseInputControl(driver, ContainerLocator, "container-LNHPD___LNHPDQUANTIDA" + IdSuffix, "#LNHPD___LNHPDQUANTIDA" + IdSuffix);

	/// <summary>
	/// Amount
	/// </summary>
	public BaseInputControl LnhpdQuantdec => new BaseInputControl(driver, ContainerLocator, "container-LNHPD___LNHPDQUANTDEC" + IdSuffix, "#LNHPD___LNHPDQUANTDEC" + IdSuffix);

	/// <summary>
	/// Breakdown:
	/// </summary>
	public ListControl PseudDesagreg => new ListControl(driver, ContainerLocator, "#LNHPD___PSEUDDESAGREG" + IdSuffix);

	public LnhpdForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "LNHPD", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
