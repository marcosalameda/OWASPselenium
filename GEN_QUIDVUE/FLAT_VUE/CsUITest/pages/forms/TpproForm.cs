using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TpproForm : Form
{
	/// <summary>
	/// Property type
	/// </summary>
	public BaseInputControl TpproTppropri => new BaseInputControl(driver, ContainerLocator, "container-TPPRO___TPPROTPPROPRI" + IdSuffix, "#TPPRO___TPPROTPPROPRI" + IdSuffix);

	public TpproForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "TPPRO", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
