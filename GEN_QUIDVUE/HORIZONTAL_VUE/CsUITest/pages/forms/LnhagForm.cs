using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LnhagForm : Form
{
	/// <summary>
	/// No.
	/// </summary>
	public LookupControl PedidNrpedido => new LookupControl(driver, ContainerLocator, "container-LNHAG___PEDIDNRPEDIDO" + IdSuffix);
	public SeeMorePage PedidNrpedidoSeeMorePage => new SeeMorePage(driver, "LNHAG", "LNHAG___PEDIDNRPEDIDO" + IdSuffix);

	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl Tpeq1Tipoequi => new LookupControl(driver, ContainerLocator, "container-LNHAG___TPEQ1TIPOEQUI" + IdSuffix);
	public SeeMorePage Tpeq1TipoequiSeeMorePage => new SeeMorePage(driver, "LNHAG", "LNHAG___TPEQ1TIPOEQUI" + IdSuffix);

	/// <summary>
	/// Quantity
	/// </summary>
	public BaseInputControl LnhagQtdtpequ => new BaseInputControl(driver, ContainerLocator, "container-LNHAG___LNHAGQTDTPEQU" + IdSuffix, "#LNHAG___LNHAGQTDTPEQU" + IdSuffix);

	public LnhagForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "LNHAG", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
