using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LnhdeForm : Form
{
	/// <summary>
	/// Order no:
	/// </summary>
	public LookupControl PedidNrpedido => new LookupControl(driver, ContainerLocator, "container-LNHDE___PEDIDNRPEDIDO");
	public SeeMorePage PedidNrpedidoSeeMorePage => new SeeMorePage(driver, "LNHDE", "LNHDE___PEDIDNRPEDIDO");

	/// <summary>
	/// Order line:
	/// </summary>
	public LookupControl LnhpdLine => new LookupControl(driver, ContainerLocator, "container-LNHDE___LNHPDLINE____");
	public SeeMorePage LnhpdLineSeeMorePage => new SeeMorePage(driver, "LNHDE", "LNHDE___LNHPDLINE____");

	/// <summary>
	/// Order
	/// </summary>
	public BaseInputControl LnhdeOrdem => new BaseInputControl(driver, ContainerLocator, "container-LNHDE___LNHDEORDEM___", "#LNHDE___LNHDEORDEM___");

	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl Tpeq1Tipoequi => new LookupControl(driver, ContainerLocator, "container-LNHDE___TPEQ1TIPOEQUI");
	public SeeMorePage Tpeq1TipoequiSeeMorePage => new SeeMorePage(driver, "LNHDE", "LNHDE___TPEQ1TIPOEQUI");

	/// <summary>
	/// Quantity:
	/// </summary>
	public BaseInputControl LnhdeQuantida => new BaseInputControl(driver, ContainerLocator, "container-LNHDE___LNHDEQUANTIDA", "#LNHDE___LNHDEQUANTIDA");

	/// <summary>
	/// Amount
	/// </summary>
	public BaseInputControl LnhdeQuantdec => new BaseInputControl(driver, ContainerLocator, "container-LNHDE___LNHDEQUANTDEC", "#LNHDE___LNHDEQUANTDEC");

	/// <summary>
	/// Código
	/// </summary>
	public BaseInputControl LnhdeCode => new BaseInputControl(driver, ContainerLocator, "container-LNHDE___LNHDECODE____", "#LNHDE___LNHDECODE____");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl LnhdeDescript => new BaseInputControl(driver, ContainerLocator, "container-LNHDE___LNHDEDESCRIPT", "#LNHDE___LNHDEDESCRIPT");

	/// <summary>
	/// Site
	/// </summary>
	public BaseInputControl LnhdeUrl => new BaseInputControl(driver, ContainerLocator, "container-LNHDE___LNHDEURL_____", "#LNHDE___LNHDEURL_____");

	/// <summary>
	/// Equipment groupings
	/// </summary>
	public ListControl PseudLnprops => new ListControl(driver, ContainerLocator, "#LNHDE___PSEUDLNPROPS_");

	public LnhdeForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "LNHDE", containerLocator: containerLocator) { }
}
