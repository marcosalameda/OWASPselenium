using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LnhdeForm : Form
{
	/// <summary>
	/// Order no:
	/// </summary>
	public LookupControl PedidNrpedido => new LookupControl(driver, ContainerLocator, "container-LNHDE___PEDIDNRPEDIDO" + IdSuffix);
	public SeeMorePage PedidNrpedidoSeeMorePage => new SeeMorePage(driver, "LNHDE", "LNHDE___PEDIDNRPEDIDO" + IdSuffix);

	/// <summary>
	/// Order line:
	/// </summary>
	public LookupControl LnhpdLine => new LookupControl(driver, ContainerLocator, "container-LNHDE___LNHPDLINE____" + IdSuffix);
	public SeeMorePage LnhpdLineSeeMorePage => new SeeMorePage(driver, "LNHDE", "LNHDE___LNHPDLINE____" + IdSuffix);

	/// <summary>
	/// Order
	/// </summary>
	public BaseInputControl LnhdeOrdem => new BaseInputControl(driver, ContainerLocator, "container-LNHDE___LNHDEORDEM___" + IdSuffix, "#LNHDE___LNHDEORDEM___" + IdSuffix);

	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl Tpeq1Tipoequi => new LookupControl(driver, ContainerLocator, "container-LNHDE___TPEQ1TIPOEQUI" + IdSuffix);
	public SeeMorePage Tpeq1TipoequiSeeMorePage => new SeeMorePage(driver, "LNHDE", "LNHDE___TPEQ1TIPOEQUI" + IdSuffix);

	/// <summary>
	/// Quantity:
	/// </summary>
	public BaseInputControl LnhdeQuantida => new BaseInputControl(driver, ContainerLocator, "container-LNHDE___LNHDEQUANTIDA" + IdSuffix, "#LNHDE___LNHDEQUANTIDA" + IdSuffix);

	/// <summary>
	/// Amount
	/// </summary>
	public BaseInputControl LnhdeQuantdec => new BaseInputControl(driver, ContainerLocator, "container-LNHDE___LNHDEQUANTDEC" + IdSuffix, "#LNHDE___LNHDEQUANTDEC" + IdSuffix);

	/// <summary>
	/// Código
	/// </summary>
	public BaseInputControl LnhdeCode => new BaseInputControl(driver, ContainerLocator, "container-LNHDE___LNHDECODE____" + IdSuffix, "#LNHDE___LNHDECODE____" + IdSuffix);

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl LnhdeDescript => new BaseInputControl(driver, ContainerLocator, "container-LNHDE___LNHDEDESCRIPT" + IdSuffix, "#LNHDE___LNHDEDESCRIPT" + IdSuffix);

	/// <summary>
	/// Site
	/// </summary>
	public BaseInputControl LnhdeUrl => new BaseInputControl(driver, ContainerLocator, "container-LNHDE___LNHDEURL_____" + IdSuffix, "#LNHDE___LNHDEURL_____" + IdSuffix);

	/// <summary>
	/// Equipment groupings
	/// </summary>
	public ListControl PseudLnprops => new ListControl(driver, ContainerLocator, "#LNHDE___PSEUDLNPROPS_" + IdSuffix);

	public LnhdeForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "LNHDE", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
