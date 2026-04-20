using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Vendaw07Form : Form
{
	/// <summary>
	/// Sale closing
	/// </summary>
	public CollapsibleZoneControl PseudNovogr07 => new CollapsibleZoneControl(driver, ContainerLocator, "#VENDAW07PSEUDNOVOGR07" + IdSuffix + "-container");

	/// <summary>
	/// Closing attempts
	/// </summary>
	public DateInputControl SaleTentfech => new DateInputControl(driver, ContainerLocator, "#VENDAW07SALE_TENTFECH" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Sale closing
	/// </summary>
	public DateInputControl SaleDtvenda => new DateInputControl(driver, ContainerLocator, "#VENDAW07SALE_DTVENDA_" + IdSuffix, "dd/MM/yyyy HH:mm");

	public Vendaw07Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "VENDAW07", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
